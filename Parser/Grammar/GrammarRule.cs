using System.Collections.Generic;

using Lexer;

namespace Parser.Grammar
{
    class GrammarRule : RuleBase
    {
        // X -> AB, Symbol = X
        public string Symbol { get; set; }

        // X -> AB
        // X -> CD
        // Terminals = { {A, B}, {C, D} }
        public List<List<RuleBase>> Terminals { get; set; }

        // Is a rule of form F -> TokenType.If
        public bool IsTerminalRule { get; set; }

        // TokenType when IsTerminalRule == true
        public TokenType TerminalType { get; set; }
    }
}
