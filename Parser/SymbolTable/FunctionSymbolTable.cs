namespace Parser.SymbolTable
{
    public class FunctionSymbolTable : SymbolTableBase
    {
        public string ClassName { get; set; }
        public string FunctionName { get; set; }
        public string ReturnType { get; set; }

        public FunctionSymbolTable(GlobalSymbolTable parent) : base(parent) { }
    }
}
