using Lexer;
using Parser.AST.Nodes;

namespace Parser.SymbolTable.Class
{
    public class ClassSymbolTableEntryBase : SymbolTableEntryBase
    {
        public Visibility Visibility { get; set; }
        public Token Type { get; set; }
        public string Name { get; set; }

        public ClassSymbolTableEntryBase() { }
    }
}
