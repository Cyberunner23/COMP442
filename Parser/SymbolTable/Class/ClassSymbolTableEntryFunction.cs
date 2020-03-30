using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.SymbolTable.Class
{
    public class ClassSymbolTableEntryFunction : ClassSymbolTableEntryBase
    {
        public List<ClassSymbolTableEntryFunctionParam> ParamsTable { get; private set; }

        public ClassSymbolTableEntryFunction()
        {
            ParamsTable = new List<ClassSymbolTableEntryFunctionParam>();
        }

        public void AddEntry(ClassSymbolTableEntryFunctionParam entry)
        {
            entry.Parent = this;
            ParamsTable.Add(entry);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"Function: {Visibility} {Name}({ToStringParams()}) -> {Type.Lexeme}");

            return builder.ToString();
        }

        public string ToStringParams()
        {
            StringBuilder builder = new StringBuilder();

            if (ParamsTable.Count != 0)
            {
                for (int i = 0; i < ParamsTable.Count - 1; ++i)
                {
                    builder.Append($"{ParamsTable[i]}, ");
                }

                builder.Append(ParamsTable.Last().ToString());
            }

            return builder.ToString();
        }

        public string ToStringSignatureNoReturn()
        {
            StringBuilder builder = new StringBuilder();
            
            var scopeSpec = ((ClassSymbolTable)Parent).ClassName;
            if (!string.IsNullOrEmpty(scopeSpec))
            {
                builder.Append($"{scopeSpec}::{Name}(");
            }
            else
            {
                builder.Append($"{Name}(");
            }

            if (ParamsTable.Count != 0)
            {
                for (int i = 0; i < ParamsTable.Count - 1; ++i)
                {
                    builder.Append($"{ParamsTable[i]}, ");
                }

                builder.Append(ParamsTable.Last().ToString());
            }

            builder.Append($")");

            return builder.ToString();
        }
    }
}
