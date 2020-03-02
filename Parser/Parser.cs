using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Lexer;
using Parser.AST;
using Parser.ASTBuilder.SemanticRules;
using Parser.Grammar;

namespace Parser
{
    public class Parser
    {
        private List<Token> _tokens;
        private int _currentLookaheadIndex = 0;
        private Token _previousPreviousLookahead;
        private Token _previousLookahead;
        private Token _lookahead;
        private Dictionary<NonTerminal, GrammarRule> _grammar;
        bool _hasRHSErrors = false;

        StreamWriter _syntaxErrorStream;
        StreamWriter _derivationsStream;
        StreamWriter _astStream;

        ASTBuilder.ASTBuilder _astBuilder;

        public Parser(List<Token> tokens, StreamWriter syntaxErrorStream, StreamWriter derivationsStream, StreamWriter astStream)
        {
            _tokens = tokens;
            _grammar = GrammarFactory.CreateGrammar();

            _lookahead = _tokens[_currentLookaheadIndex];

            _syntaxErrorStream = syntaxErrorStream;
            _derivationsStream = derivationsStream;
            _astStream = astStream;

            _astBuilder = new ASTBuilder.ASTBuilder();
        }

        #region Parsing
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

            if (entry.IsTerminalRule)
            {
                PrintTerminalRule(entry);
                var result = Match(entry.FirstSet.First());
                return result;
            }
            
            if (!entry.FirstSet.Contains(_lookahead.TokenType))
            {
                var result = entry.IsNullable && entry.FollowSet.Contains(_lookahead.TokenType);
                //ErrorExpectedTokens(entry.FirstSet, currentLookahead.StartLine, currentLookahead.StartColumn);
                return result;
            }

            List<IRule> satisfiableRHS = null;
            foreach (var rhs in entry.RHSSet)
            {
                var grammarRules = rhs.Where(x => x is GrammarRule); // Filter out semantic rules
                var firstRule = grammarRules.First() as GrammarRule;
                if (firstRule.FirstSet.Contains(_lookahead.TokenType) || (firstRule.IsNullable && firstRule.FollowSet.Contains(_lookahead.TokenType)))
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
                var semanticRule = symbol as ISemanticRule;

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
                    _astBuilder.HandleSemanticRule(semanticRule, _lookahead, _previousLookahead, _previousPreviousLookahead);
                }
                else
                {
                    _syntaxErrorStream.WriteLine("Unhandled production type");
                    Environment.Exit(-1);
                }
            }

            return true;
        }

        private void PrintSatisfiableRHS(GrammarRule entry, List<IRule> satisfiableRHS)
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
            bool matches = _lookahead.TokenType == tokenType;
            if (matches)
            {
                ShiftForwardLookaheadToken();
            }
            else
            {
                _syntaxErrorStream.WriteLine($"[{_lookahead.StartLine}:{_lookahead.StartColumn}] Expected token: {tokenType}, saw: {_lookahead.TokenType}");
            }

            return matches;
        }

        private bool ShiftForwardLookaheadToken()
        {
            ++_currentLookaheadIndex;
            if (_currentLookaheadIndex >= _tokens.Count)
            {
                return false;
            }

            _previousPreviousLookahead = _previousLookahead;
            _previousLookahead = _lookahead;
            _lookahead = _tokens[_currentLookaheadIndex];
            return true;
        }

        private bool SkipErrors(GrammarRule entry)
        {
            if (entry.IsTerminalRule)
            {
                return true;
            }

            if (entry.FirstSet.Contains(_lookahead.TokenType) || (entry.IsNullable && entry.FollowSet.Contains(_lookahead.TokenType)))
            {
                return true;
            }
            else
            {
                // Write error
                _syntaxErrorStream.WriteLine($"Syntax error: [{_lookahead.StartLine}:{_lookahead.StartColumn}]");
                var firstAndFollow = entry.FirstSet.Concat(entry.FollowSet ?? new List<TokenType>()).ToList();
                while (!firstAndFollow.Contains(_lookahead.TokenType))
                {
                    if (!ShiftForwardLookaheadToken()) return false;
                    if (entry.IsNullable && entry.FollowSet.Contains(_lookahead.TokenType))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        #endregion Parsing

        #region AST Building
        public ASTNodeBase GetASTTree()
        {
            return _astBuilder.GetASTTree();
        }
        #endregion
    }
}
