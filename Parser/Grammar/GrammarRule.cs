using System.Collections.Generic;

using Lexer;

namespace Parser.Grammar
{
    class GrammarRule : RuleBase
    {
        public GrammarRule(NonTerminal nonTerminal, bool isNullable = false, bool isTerminalRule = false)
        {
            Symbol = nonTerminal;
            FirstSet = new List<TokenType>();
            FollowSet = new List<TokenType>();
            RHSSet = new List<List<RuleBase>>();
            IsNullable = isNullable;
            IsTerminalRule = isTerminalRule;
        }

        // X -> AB, Symbol = X
        public NonTerminal Symbol { get; set; }

        public List<TokenType> FirstSet { get; set; }
        public List<TokenType> FollowSet { get; set; }

        // X -> AB
        // X -> CD
        // Rules = { {A, B}, {C, D} } which maps to -> AB | CD
        public List<List<RuleBase>> RHSSet { get; set; }

        // Is epsilon in the first set
        public bool IsNullable { get; set; }

        // Is a rule of form F -> TokenType.If
        public bool IsTerminalRule { get; set; }
    }
}
