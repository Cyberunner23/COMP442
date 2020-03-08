using System.Collections.Generic;

namespace Parser.SymbolTable.Class
{
    class ClassSymbolTableEntryVariable : ClassSymbolTableEntryBase
    {
        public List<int> ArrayDims { get; set; }

        public ClassSymbolTableEntryVariable()
        {
            ArrayDims = new List<int>();
        }
    }
}
