using System.Collections.Generic;

namespace Parser.SymbolTable.Class
{
    public class ClassSymbolTable : SymbolTableBase
    {
        public string ClassName { get; set; }
        public List<string> Inherits { get; private set; }

        public ClassSymbolTable(GlobalSymbolTable parent) : base(parent)
        {
            Inherits = new List<string>(); ;
        }
    }
}
