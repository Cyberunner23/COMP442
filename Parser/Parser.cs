using System;
using System.Collections.Generic;
using System.Linq;
using Lexer;
using Parser.Grammar;

namespace Parser
{
    public class Parser
    {
        private List<Token> _tokens;
        private int _currentLookaheadTokenIndex = 0;
        private Dictionary<NonTerminal, GrammarRule> _grammar;

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
            _grammar = GrammarFactory.CreateGrammar();
        }

        public bool Parse()
        {
            return Parse(NonTerminal.Start) && Match(TokenType.EOF);
        }


        // Explanation based on slide 11 of slides SyntaxII
        public bool Parse(NonTerminal nonTerminal)
        {
            GrammarRule entry = _grammar[nonTerminal];

            if (entry.IsTerminalRule)
            {
                return Match(entry.FirstSet.First());
            }

            TokenType currentLookahead = GetCurrentLookaheadToken().TokenType;
            if (entry.FirstSet.Contains(currentLookahead))
            {
                return entry.IsNullable && entry.FollowSet.Contains(currentLookahead);
            }




            foreach (var rhs in entry.RHSSet)
            {
                foreach(var production in rhs) // Going through all the RHS
                {
                    var grammarRule = production as GrammarRule;
                    var semanticRule = production as SemanticRule;

                    if (grammarRule != null) // Is a Grammar rule
                    {
                        if (grammarRule.IsTerminalRule)
                        {
                            return Match(grammarRule.FirstSet.First());
                        }
                        else
                        {
                            
                        }
                    }
                    else if (semanticRule != null) // Is a Semantic Rule
                    {
                        // Do semantic rule stuff
                    }
                    else
                    {
                        Console.WriteLine("Unhandled production type");
                        Environment.Exit(-1);
                    }
                }

                // Went through all the RSHs without returning... if LHS -> EPSILON exists, return true
                if (entry.IsNullable)
                {
                    //TODO(AFL) Write ("LHS->ε")
                    return true;
                }
            }

            return false;
        }

        private bool Match(TokenType tokenType)
        {
            bool matches = GetCurrentLookaheadToken().TokenType == tokenType;
            if (matches)
            {
                ShiftForwardLookaheadToken();
            }

            return matches;
        }

        private Token GetCurrentLookaheadToken()
        {
            return _tokens[_currentLookaheadTokenIndex];
        }

        private void ShiftForwardLookaheadToken()
        {
            _currentLookaheadTokenIndex++;
        }

      
    }
}
