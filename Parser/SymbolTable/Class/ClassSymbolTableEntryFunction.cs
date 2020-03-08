using System.Collections.Generic;

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
    }
}
