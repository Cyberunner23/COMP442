﻿using Parser.SymbolTable.Class;
using Parser.SymbolTable.Function;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Parser.SymbolTable
{
    public class GlobalSymbolTable
    {
        public List<ClassSymbolTable> ClassSymbolTables { get; private set; }
        public FunctionSymbolTable FunctionSymbolTable { get; private set; }

        StreamWriter _errorStream;

        public GlobalSymbolTable(StreamWriter errorStream)
        {
            _errorStream = errorStream;

            ClassSymbolTables = new List<ClassSymbolTable>();
            FunctionSymbolTable = new FunctionSymbolTable();
        }

        public void AddClassSymbolTable(ClassSymbolTable table)
        {
            table.Parent = this;
            ClassSymbolTables.Add(table);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("|===========================================================");
            builder.AppendLine("| Global Table");
            builder.AppendLine("|===========================================================");
            builder.AppendLine("|");

            foreach (var classTable in ClassSymbolTables)
            {
                var text = classTable.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var line in text)
                {
                    builder.AppendLine($"|    {line}");
                }

                builder.AppendLine("|");
            }

            foreach (var functionTableEntry in FunctionSymbolTable.Entries)
            {
                var text = functionTableEntry.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var line in text)
                {
                    builder.AppendLine($"|    {line}");
                }

                builder.AppendLine("|");
            }

            builder.AppendLine("|===========================================================");

            return builder.ToString();
        }

        public void Validate()
        {
            CheckDeclAndDefn();
            CheckDuplicateDecls();
            CheckFunctionOverloads();
        }


        //NOTE(AFL): I'm running out of time, this is not implemented the best way...
        #region Validation Steps

        // #5 in assignment
        public void CheckShadowedMembers()
        {

        }

        // #6 in the assignment
        public void CheckDeclAndDefn()
        {
            // Check definition exists
            foreach (var classTable in ClassSymbolTables)
            {
                var functionDecls = classTable.Entries.Where(x => x is ClassSymbolTableEntryFunction).Cast<ClassSymbolTableEntryFunction>();
                foreach (var functionDecl in functionDecls)
                {
                    if (!FunctionDefnFound(functionDecl))
                    {
                        _errorStream.WriteLine($"No definition for declared member function: {functionDecl} in class {classTable.ClassName}");
                    }
                }
            }

            // Check decl exists
            foreach (var entry in FunctionSymbolTable.Entries.Cast<FunctionSymbolTableEntry>())
            {
                if (!string.IsNullOrEmpty(entry.ScopeSpec))
                {
                    var classTable = ClassSymbolTables.FirstOrDefault(x => string.Equals(x.ClassName, entry.ScopeSpec));
                    if (classTable == null)
                    {
                        _errorStream.WriteLine($"function definition provided for undeclared class: \"{entry.ScopeSpec}\" | {entry.ToStringSignature()}");
                        continue;
                    }

                    var decls = classTable.Entries.Where(x => x is ClassSymbolTableEntryFunction).Cast<ClassSymbolTableEntryFunction>();
                    bool declExists = FunctionDeclFound(decls, entry);
                    if (!declExists)
                    {
                        _errorStream.WriteLine($"function definition provided for undeclared member function: \"{entry.ToStringSignature()}\"");
                        continue;
                    }
                }
            }
        }
        
        //#8 in the assignment
        public void CheckDuplicateDecls()
        {
            // Classes
            ClassSymbolTables.GroupBy(x => x.ClassName)
                             .Where(x => x.Count() > 1)
                             .Select(x => x.Key)
                             .ToList()
                             .ForEach(x => 
                             {
                                 _errorStream.WriteLine($"Multiple declaration of class: \"{x}\"");
                             });

            // Data Member
            foreach (var classTable in ClassSymbolTables)
            {
                var varDecls = classTable.Entries.Where(x => x is ClassSymbolTableEntryVariable).Cast<ClassSymbolTableEntryVariable>();
                varDecls.GroupBy(x => x.Name)
                        .Where(x => x.Count() > 1)
                        .Select(x => x.Key)
                        .ToList()
                        .ForEach(x =>
                        {
                            _errorStream.WriteLine($"Multiple declaration of variable: \"{x}\" in class \"{classTable.ClassName}\"");
                        });
            }

            // Functions
            var funcDefns = FunctionSymbolTable.Entries.Cast<FunctionSymbolTableEntry>();
            funcDefns.GroupBy(x => x.ToStringSignatureNoReturn())
                     .Where(x => x.Count() > 1)
                     .Select(x => x.Key)
                     .ToList()
                     .ForEach(x =>
                     {
                         _errorStream.WriteLine($"Multiple function definitions for function {x}");
                     });


            // Locals
            foreach (var funcDefn in funcDefns)
            {
                var locals = funcDefn.LocalScope;
                locals.GroupBy(x => x.ToString(), StringComparer.Ordinal)
                      .Where(x => x.Count() > 1)
                      .Select(x => x.Key)
                      .ToList()
                      .ForEach(x =>
                      {
                          _errorStream.WriteLine($"Multiple declaration of local variable: \"{x}\" in function definition \"{funcDefn.ToStringSignature()}\"");
                      });
            }


        }

        // #9 in the assignment
        public void CheckFunctionOverloads()
        {
            var functions = FunctionSymbolTable.Entries.Cast<FunctionSymbolTableEntry>().ToList();
            var scopeGroups = functions.GroupBy(x => x.ScopeSpec).ToDictionary(x => x.Key ?? "NULL", x => x.ToList());

            foreach (var scopeGroup in scopeGroups)
            {
                var scopeName = scopeGroup.Key;
                var scopeEntries = scopeGroup.Value;

                var funcsWithSameName = scopeEntries.GroupBy(x => x.Name).Where(x => x.Count() > 1).ToDictionary(x => x.Key, x => x.ToList());
                foreach (var duplicateFuncName in funcsWithSameName)
                {
                    duplicateFuncName.Value.GroupBy(x => x.ToStringSignatureNoReturn())
                                           .Where(x => x.Count() == 1)
                                           .ToList()
                                           .ForEach(x =>
                                           {
                                               _errorStream.WriteLine($"WARNING: Function: \"{x.First().ToStringSignature()}\" has an overload." );
                                           });
                }
            }
        }
        

        #region Helpers        
        private bool FunctionDefnDeclParamsMatch(List<ClassSymbolTableEntryFunctionParam> declParams, List<FunctionSymbolTableEntryParam> defnParams)
        {
            if (declParams.Count != defnParams.Count)
            {
                return false;
            }

            for (int i = 0; i < declParams.Count; ++i)
            {
                if (!string.Equals(declParams[i].Name, defnParams[i].Name))
                {
                    return false;
                }

                if (declParams[i].Type.TokenType != defnParams[i].Type.TokenType)
                {
                    return false;
                }

                if (declParams[i].ArrayDims.Count != defnParams[i].ArrayDims.Count)
                {
                    return false;
                }

                for (int j = 0; j < declParams[i].ArrayDims.Count; ++j)
                {
                    if (declParams[i].ArrayDims[j] != defnParams[i].ArrayDims[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool FunctionDefnFound(ClassSymbolTableEntryFunction decl)
        {
            bool found = false;
            foreach (var defn in FunctionSymbolTable.Entries.Cast<FunctionSymbolTableEntry>())
            {
                if (string.Equals(defn.ScopeSpec, ((ClassSymbolTable)decl.Parent).ClassName)
                    && string.Equals(defn.Name, decl.Name)
                    && FunctionDefnDeclParamsMatch(decl.ParamsTable, defn.Params))
                {
                    found = true;
                }
            }

            return found;
        }

        private bool FunctionDeclFound(IEnumerable<ClassSymbolTableEntryFunction> decls, FunctionSymbolTableEntry defn)
        {
            bool found = false;

            foreach (var decl in decls)
            {
                if (string.Equals(defn.ScopeSpec, ((ClassSymbolTable)decl.Parent).ClassName)
                    && string.Equals(defn.Name, decl.Name)
                    && FunctionDefnDeclParamsMatch(decl.ParamsTable, defn.Params))
                {
                    found = true;
                }
            }

            return found;
        }
        #endregion
        #endregion
    }
}
