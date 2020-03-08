using Lexer;
using System.Collections.Generic;

namespace Parser.SymbolTable.Class
{
    public class ClassSymbolTableEntryFunctionParam
    {
        public ClassSymbolTableEntryFunction Parent { get; set; }

        public Token Type { get; set; }
        public string Name { get; set; }
        public List<int> ArrayDims {get; set;}
    }
}
