using System.Collections.Generic;
using System.Text;

namespace Parser.SymbolTable.Class
{
    public class ClassSymbolTableEntryVariable : ClassSymbolTableEntryBase
    {
        public List<int> ArrayDims { get; set; }
        public int MemSize { get; set; } = 0;
        public int MemOffset { get; set; } = 0;

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

            builder.AppendLine();
            builder.Append($"*        MemSize: {MemSize}, MemOffset: {MemOffset}");

            return builder.ToString();
        }
    }
}
