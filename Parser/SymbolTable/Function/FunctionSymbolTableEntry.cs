using CodeGenUtils;
using Lexer;
using Parser.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.SymbolTable.Function
{
    public class FunctionSymbolTableEntry : SymbolTableEntryBase
    {
        public string ScopeSpec { get; set; }
        public string Name { get; set; }
        public Token ReturnType { get; set; }
        public List<FunctionSymbolTableEntryParam> Params { get; set; }
        public List<FunctionSymbolTableEntryLocalScope> LocalScope { get; set; }

        public FrameMemoryLayout MemoryLayout { get; private set; }

        public FunctionSymbolTableEntry()
        {
            Params = new List<FunctionSymbolTableEntryParam>();
            LocalScope = new List<FunctionSymbolTableEntryLocalScope>();
            MemoryLayout = new FrameMemoryLayout();
        }

        public void AddParamEntry(FunctionSymbolTableEntryParam param)
        {
            param.Parent = this;
            Params.Add(param);
        }

        public void AddLocalScopeEntry(FunctionSymbolTableEntryLocalScope param)
        {
            param.Parent = this;
            LocalScope.Add(param);
        }

        // Type <-> dim
        public Dictionary<string, int> GetParamTypes()
        {
            var paramTypes = new Dictionary<string, int>();

            foreach (var param in Params)
            {
                paramTypes.Add(param.Name, param.ArrayDims.Count());
            }

            return paramTypes;
        }

        // name <-> (type <-> dims)
        public Dictionary<string, (string, List<int>)> GetVariablesInScope()
        {
            var variables = new Dictionary<string, (string, List<int>)>();

            foreach (var paramVar in Params)
            {
                variables.Add(paramVar.Name, paramVar.Type);
            }

            foreach (var localVar in LocalScope.DedupeBy(x => x.Name))
            {
                variables.Add(localVar.Name, (localVar.Type.Lexeme, localVar.ArrayDims));
            }

            if (!string.IsNullOrEmpty(ScopeSpec))
            {
                var classTable = ((FunctionSymbolTable)Parent).Parent.GetClassSymbolTableByName(ScopeSpec);
                classTable.GetVariablesInScope();
            }
            

            return variables;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("+===========================================================");
            builder.AppendLine("+ Function Table");

            builder.Append($"+    {ToStringSignatureNoReturn()}");
            
            if (ReturnType != null)
            {
                builder.Append($" -> {ReturnType.Lexeme}");
            }

            builder.AppendLine();
            builder.AppendLine("+");

            foreach (var param in Params)
            {
                builder.AppendLine($"+    Parameter: {param.Type.type} {param.Name}");
            }

            builder.AppendLine("+");
            builder.AppendLine("+===========================================================");
            builder.AppendLine("+ Local Table");

            foreach (var local in LocalScope)
            {
                builder.AppendLine($"+    Local: {local.ToString()}");
            }

            builder.AppendLine("+");
            builder.AppendLine("+===========================================================");

            return builder.ToString();
        }

        public string ToStringSignature()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"{ToStringSignatureNoReturn()}");

            if (ReturnType != null)
            {
                builder.Append($" -> {ReturnType.Lexeme}");
            }

            return builder.ToString();
        }

        public string ToStringSignatureNoReturn(bool includeScope = true)
        {
            StringBuilder builder = new StringBuilder();

            if (!string.IsNullOrEmpty(ScopeSpec) && includeScope)
            {
                builder.Append($"{ScopeSpec}::{Name}(");
            }
            else
            {
                builder.Append($"{Name}(");
            }

            if (Params.Count != 0)
            {
                for (int i = 0; i < Params.Count - 1; ++i)
                {
                    builder.Append($"{Params[i]}, ");
                }

                builder.Append(Params.Last().ToString());
            }

            builder.Append($")");

            return builder.ToString();
        }
    }
}
