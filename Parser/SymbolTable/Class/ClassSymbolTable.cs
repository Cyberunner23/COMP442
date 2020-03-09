using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.SymbolTable.Class
{
    public class ClassSymbolTable : SymbolTableBase
    {
        public string ClassName { get; set; }
        public List<string> Inherits { get; private set; }

        public ClassSymbolTable()
        {
            Inherits = new List<string>(); ;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("*===========================================================");
            builder.AppendLine("* Class Table");
            builder.AppendLine($"* Name: {ClassName}");
            builder.AppendLine($"* Inherits:");

            foreach (var inherit in Inherits)
            {
                builder.AppendLine($"*    {inherit}");
            }

            builder.AppendLine("*===========================================================");
            builder.AppendLine("*");

            foreach (var entry in Entries)
            {
                var text = entry.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var line in text)
                {
                    builder.AppendLine($"*    {line}");
                }
            }

            builder.AppendLine("*");
            builder.AppendLine("*===========================================================");

            return builder.ToString();
        }
    }
}
