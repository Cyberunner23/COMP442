using System.Collections.Generic;
using System.Text;

namespace Parser.SymbolTable.Class
{
    public class ClassSymbolTableEntryVariable : ClassSymbolTableEntryBase
    {
        public List<int> ArrayDims { get; set; }

        public ClassSymbolTableEntryVariable()
        {
            ArrayDims = new List<int>();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"*    Variable: {Visibility} {Type.Lexeme} {Name}");

            foreach (var dim in ArrayDims)
            {
                builder.Append($"[{dim}]");
            }

            return builder.ToString();
        }
    }
}
