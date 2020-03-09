using Lexer;
using System.Collections.Generic;
using System.Text;

namespace Parser.SymbolTable.Function
{
    public class FunctionSymbolTableEntryParam
    {
        public FunctionSymbolTableEntry Parent { get; set; }

        public Token Type { get; set; }
        public string Name { get; set; }
        public List<int> ArrayDims {get; set;}

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"{Type.Lexeme} {Name}");

            foreach (var dim in ArrayDims)
            {
                builder.Append($"[{dim}]");
            }

            return builder.ToString();
        }
    }
}
