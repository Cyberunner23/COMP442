using Parser.SymbolTable.Class;
using System.Collections.Generic;

namespace Parser.SymbolTable
{
    public class GlobalSymbolTable
    {
        public List<ClassSymbolTable> ClassSymbolTables { get; private set; }
        public List<FunctionSymbolTable> FunctionSymbolTables { get; private set; }

        public GlobalSymbolTable()
        {
            ClassSymbolTables = new List<ClassSymbolTable>();
            FunctionSymbolTables = new List<FunctionSymbolTable>();
        }

        public void AddClassSymbolTable(ClassSymbolTable table)
        {
            table.Parent = this;
            ClassSymbolTables.Add(table);
        }

        public void AddFunctionSymbolTable(FunctionSymbolTable table)
        {
            table.Parent = this;
            FunctionSymbolTables.Add(table);
        }
    }
}
