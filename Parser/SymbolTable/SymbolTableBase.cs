using System.Collections.Generic;

namespace Parser.SymbolTable
{
    public class SymbolTableBase
    {
        public GlobalSymbolTable Parent { get; set; }
        public List<SymbolTableEntryBase> Entries { get; private set; }

        public SymbolTableBase()
        {
            Entries = new List<SymbolTableEntryBase>();
        }

        public void AddEntry(SymbolTableEntryBase entry)
        {
            entry.Parent = this;
            Entries.Add(entry);
        }
    }
}
