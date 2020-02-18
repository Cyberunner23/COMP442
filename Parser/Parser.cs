using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Lexer;
using Parser.Grammar;

namespace Parser
{
    public class Parser
    {
        private List<Token> _tokens;
        private int _currentLookaheadTokenIndex = 0;
        private Dictionary<NonTerminal, GrammarRule> _grammar;
        bool _hasRHSErrors = false;

        StreamWriter _syntaxErrorStream;
        StreamWriter _derivationsStream;
        StreamWriter _astStream;


        public Parser(List<Token> tokens, StreamWriter syntaxErrorStream, StreamWriter derivationsStream, StreamWriter astStream)
        {
            _tokens = tokens;
            _grammar = GrammarFactory.CreateGrammar();

            _syntaxErrorStream = syntaxErrorStream;
            _derivationsStream = derivationsStream;
            _astStream = astStream;
        }

        public bool Parse()
        {
            var result = Parse(NonTerminal.Start);
            var result2 = Match(TokenType.EOF);
            return result && result2 && !_hasRHSErrors;
        }


        // Explanation based on slide 11 of slides SyntaxII
        public bool Parse(NonTerminal nonTerminal)
        {
            GrammarRule entry = _grammar[nonTerminal];

            if (!SkipErrors(entry))
            {
                return false;
            }

            Token currentLookahead = GetCurrentLookaheadToken();
            TokenType currentLookaheadType = GetCurrentLookaheadTokenType();

            if (entry.IsTerminalRule)
            {
                PrintTerminalRule(entry);
                var result = Match(entry.FirstSet.First());
                return result;
            }
            
            if (!entry.FirstSet.Contains(currentLookaheadType))
            {
                var result = entry.IsNullable && entry.FollowSet.Contains(currentLookaheadType);
                //ErrorExpectedTokens(entry.FirstSet, currentLookahead.StartLine, currentLookahead.StartColumn);
                return result;
            }

            List<RuleBase> satisfiableRHS = null;
            foreach (var rhs in entry.RHSSet)
            {
                var grammarRules = rhs.Where(x => x is GrammarRule); // Filter out semantic rules
                var firstRule = grammarRules.First() as GrammarRule;
                if (firstRule.FirstSet.Contains(currentLookaheadType) || (firstRule.IsNullable && firstRule.FollowSet.Contains(currentLookaheadType)))
                {
                    satisfiableRHS = rhs;
                    PrintSatisfiableRHS(entry, satisfiableRHS);
                    break;
                }
            }

            if (satisfiableRHS == null)
            {
                // ERROR
                Console.WriteLine("ASSERT: no satisfiable RHS");
                Environment.Exit(-2);
            }

            // Going through the RHS
            foreach (var symbol in satisfiableRHS)
            {
                var grammarRule = symbol as GrammarRule;
                var semanticRule = symbol as SemanticRule;

                if (grammarRule != null) // Is a Grammar rule
                { 
                    bool result = Parse(grammarRule.Symbol);
                    if (!result)
                    {
                        // Report error
                        _hasRHSErrors = true;
                    }
                }
                else if (semanticRule != null) // Is a Semantic Rule
                {
                    // Do semantic rule stuff
                }
                else
                {
                    _syntaxErrorStream.WriteLine("Unhandled production type");
                    Environment.Exit(-1);
                }
            }

            return true;
        }

        private void PrintSatisfiableRHS(GrammarRule entry, List<RuleBase> satisfiableRHS)
        {
            var LHS = entry.Symbol;
            var RHS = satisfiableRHS.OfType<GrammarRule>().Select(x => x.Symbol);
            StringBuilder b = new StringBuilder();
            b.Append($"{LHS} -> ");
            foreach (var symbol in RHS)
            {
                b.Append($"{symbol} ");
            }

            _derivationsStream.WriteLine(b.ToString());
        }

        private void PrintTerminalRule(GrammarRule entry)
        {
            var rhs = char.ToLower(entry.Symbol.ToString()[0]) + entry.Symbol.ToString().Substring(1);
            _derivationsStream.WriteLine($"{entry.Symbol} -> {rhs}");
        }

        private bool Match(TokenType tokenType)
        {
            var lookahead = GetCurrentLookaheadToken();
            bool matches = lookahead.TokenType == tokenType;
            if (matches)
            {
                ShiftForwardLookaheadToken();
            }
            else
            {
                _syntaxErrorStream.WriteLine($"[{lookahead.StartLine}:{lookahead.StartColumn}] Expected token: {tokenType}, saw: {lookahead.TokenType}");
            }

            return matches;
        }

        private Token GetCurrentLookaheadToken()
        {
            return _tokens[_currentLookaheadTokenIndex];
        }

        private TokenType GetCurrentLookaheadTokenType()
        {
            return GetCurrentLookaheadToken().TokenType;
        }

        private void ShiftForwardLookaheadToken()
        {
            _currentLookaheadTokenIndex++;
        }

        private bool SkipErrors(GrammarRule entry)
        {
            Token lookahead = GetCurrentLookaheadToken();
            if (entry.IsTerminalRule)
            {
                return true;
            }

            if (entry.FirstSet.Contains(lookahead.TokenType) || (entry.IsNullable && entry.FollowSet.Contains(lookahead.TokenType)))
            {
                return true;
            }
            else
            {
                // Write error
                _syntaxErrorStream.WriteLine($"Syntax error: [{lookahead.StartLine}:{lookahead.StartColumn}]");
                var firstAndFollow = entry.FirstSet.Concat(entry.FollowSet ?? new List<TokenType>()).ToList();
                while (!firstAndFollow.Contains(lookahead.TokenType))
                {
                    ShiftForwardLookaheadToken();
                    lookahead = GetCurrentLookaheadToken();
                    if (entry.IsNullable && entry.FollowSet.Contains(lookahead.TokenType))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
