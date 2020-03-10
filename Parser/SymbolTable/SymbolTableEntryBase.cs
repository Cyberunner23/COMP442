namespace Parser.SymbolTable
{
    public class SymbolTableEntryBase : ITable
    {
        public SymbolTableBase Parent { get; set; }

        public SymbolTableEntryBase() { }
    }
}
