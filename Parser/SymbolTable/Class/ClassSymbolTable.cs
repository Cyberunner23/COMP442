using Lexer;
using Parser.SymbolTable.Function;
using Parser.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.SymbolTable.Class
{
    public class ClassSymbolTable : SymbolTableBase
    {
        public string ClassName { get; set; }
        public List<string> Inherits { get; private set; }
        public int MemSize { get; set; } = 0;

        public ClassSymbolTable()
        {
            Inherits = new List<string>();
        }

        public Dictionary<string, (string, List<int>)> GetVariablesInScope(List<string> visitedClasses = null)
        {
            if (visitedClasses == null)
            {
                visitedClasses = new List<string>() { ClassName };
            }


            var variables = new Dictionary<string, (string, List<int>)>();
            foreach (var classVar in Entries.Where(x => x is ClassSymbolTableEntryVariable).Cast<ClassSymbolTableEntryVariable>())
            {
                variables.Add(classVar.Name, (classVar.Type.Lexeme, classVar.ArrayDims));
            }

            foreach (var inherit in Inherits)
            {
                var classTable = Parent.GetClassSymbolTableByName(inherit);
                if (visitedClasses.Contains(classTable.ClassName))
                {
                    continue;
                }

                var extraVars = classTable.GetVariablesInScope(visitedClasses);
                variables = variables.Concat(extraVars).ToDictionary(x => x.Key, x => x.Value);
                visitedClasses.Add(classTable.ClassName);
            }

            return variables;
        }

        public List<FunctionSymbolTableEntry> GetFunctions(List<string> visitedClasses = null)
        {
            if (visitedClasses == null)
            {
                visitedClasses = new List<string>() { ClassName };
            }

            var functions = new List<FunctionSymbolTableEntry>();
            foreach (var function in Parent.FunctionSymbolTable.Entries.Cast<FunctionSymbolTableEntry>().Where(x => string.Equals(x.ScopeSpec, this.ClassName)))
            {
                functions.Add(function);
            }

            foreach (var inherit in Inherits)
            {
                var classTable = Parent.GetClassSymbolTableByName(inherit);
                if (visitedClasses.Contains(classTable.ClassName))
                {
                    continue;
                }

                var extraFuncs = classTable.GetFunctions(visitedClasses);
                functions = functions.Concat(extraFuncs).ToList();
                visitedClasses.Add(classTable.ClassName);
            }

            return functions;
        }

        public List<string> GetFunctionNamesInScope(List<string> visitedClasses = null)
        {
            if (visitedClasses == null)
            {
                visitedClasses = new List<string>() { ClassName };
            }

            var functions = new List<string>();
            foreach (var function in Entries.Where(x => x is ClassSymbolTableEntryFunction).Cast<ClassSymbolTableEntryFunction>())
            {
                functions.Add(function.Name);
            }

            foreach (var inherit in Inherits)
            {
                var classTable = Parent.GetClassSymbolTableByName(inherit);
                if (visitedClasses.Contains(classTable.ClassName))
                {
                    continue;
                }

                visitedClasses.Add(classTable.ClassName);
                functions.Concat(classTable.GetFunctionNamesInScope(visitedClasses));
            }

            return functions.DedupeBy(x => x);
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

            builder.AppendLine($"* MemSize = {MemSize}");
            builder.AppendLine("*===========================================================");
            builder.AppendLine("*");

            foreach (var entry in Entries)
            {
                var text = entry.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var line in text)
                {
                    builder.AppendLine($"{line}");
                }
            }

            builder.AppendLine("*");
            builder.AppendLine("*===========================================================");

            return builder.ToString();
        }

        public List<string> GetDataMemberTypes()
        {
            var dataMembers = Entries.Where(x => x is ClassSymbolTableEntryVariable).Cast<ClassSymbolTableEntryVariable>();
            var dataMemberTypes = dataMembers.Select(x => x.Type).Where(x => x.TokenType == TokenType.Identifier).Select(x => x.Lexeme).ToList();
            return dataMemberTypes;
        }

    }
}
