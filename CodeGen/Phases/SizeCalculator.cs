using System;
using System.Collections.Generic;
using System.Linq;
using CodeGen.ASTVisitors;
using Lexer;
using Parser.AST;
using Parser.SymbolTable;
using Parser.SymbolTable.Class;
using Parser.SymbolTable.Function;
using Parser.Utils;

namespace CodeGen.Phases
{
    // Calculates size of classes and function frames and adds them to the symbol table.
    class SizeCalculator
    {
        private ASTNodeBase _astTree;
        private GlobalSymbolTable _globalSymbolTable;

        public SizeCalculator(ASTNodeBase astTree, GlobalSymbolTable globalSymbolTable)
        {
            _astTree = astTree;
            _globalSymbolTable = globalSymbolTable;
        }

        // Computes size of classes and function frames and stores them in the Tables
        public void Calculate()
        {
            CalculateClassSizes();
            CalculateFunctionFrameSizes();
            CalculateFunctionFrameSizesWithIntermediates();
        }

        private void CalculateFunctionFrameSizes()
        {
            foreach (var funcTable in _globalSymbolTable.FunctionSymbolTable.Entries.Cast<FunctionSymbolTableEntry>())
            {
                CalculateFunctionFrameSize(funcTable);
            }
        }

        private void CalculateClassSize(ClassSymbolTable classTable)
        {
            var varsInScope = classTable.GetVariablesInScope();

            foreach (var varInScope in varsInScope)
            {
                var type = varInScope.Value;

                var multiplier = 1;
                foreach (var dim in type.dims)
                {
                    multiplier *= dim;
                }

                if (string.Equals(type.type, TypeConstants.IntType))
                {
                    classTable.MemoryLayout.AddEntry(type, varInScope.Key, TypeConstants.IntTypeSize, TypeConstants.IntTypeSize * multiplier);
                }
                else if (string.Equals(type.type, TypeConstants.FloatType))
                {
                    classTable.MemoryLayout.AddEntry(type, varInScope.Key, TypeConstants.FloatTypeSize, TypeConstants.FloatTypeSize * multiplier);
                }
                else
                {
                    var varClassTable = _globalSymbolTable.GetClassSymbolTableByName(type.type);
                    if (varClassTable.MemoryLayout.TotalSize == 0)
                    {
                        CalculateClassSize(varClassTable);
                    }

                    classTable.MemoryLayout.AddEntry(type, varInScope.Key, varClassTable.MemoryLayout.TotalSize, varClassTable.MemoryLayout.TotalSize * multiplier);
                }
            }
        }

        private void CalculateClassSizes()
        {
            foreach (var classTable in _globalSymbolTable.ClassSymbolTables)
            {
                CalculateClassSize(classTable);
            }
        }

        private void CalculateFunctionFrameSize(FunctionSymbolTableEntry functionTable)
        {
            var returnType = functionTable.ReturnType;
            var varType = "";
            var size = 0;
            if (returnType != null)
            {
                switch (returnType.TokenType)
                {
                    case TokenType.Integer:
                        varType = TypeConstants.IntType;
                        size = TypeConstants.IntTypeSize;
                        break;
                    case TokenType.Float:
                        varType = TypeConstants.FloatType;
                        size = TypeConstants.FloatTypeSize;
                        break;
                    case TokenType.Identifier:
                        {
                            var varClassTable = _globalSymbolTable.GetClassSymbolTableByName(returnType.Lexeme);
                            if (varClassTable.MemoryLayout.TotalSize == 0)
                            {
                                CalculateClassSize(varClassTable);
                            }

                            varType = varClassTable.ClassName;
                            size = varClassTable.MemoryLayout.TotalSize;

                            break;
                        }
                }
            }

            functionTable.MemoryLayout.AddReturnValueEntry((varType, new List<int>()), size, size);

            foreach (var parameter in functionTable.Params)
            {
                var type = parameter.Type;
                var multiplier = 1;
                foreach (var dim in type.dims)
                {
                    multiplier *= dim;
                }

                if (string.Equals(type.type, TypeConstants.IntType))
                {
                    parameter.MemSize = multiplier * TypeConstants.IntTypeSize;
                    functionTable.MemoryLayout.AddArgumentEntry(type, parameter.Name, TypeConstants.IntTypeSize, parameter.MemSize);
                }
                else if (string.Equals(type.type, TypeConstants.FloatType))
                {
                    parameter.MemSize = multiplier * TypeConstants.FloatTypeSize;
                    functionTable.MemoryLayout.AddArgumentEntry(type, parameter.Name, TypeConstants.FloatTypeSize, parameter.MemSize);
                }
                else
                {
                    var varClassTable = _globalSymbolTable.GetClassSymbolTableByName(type.type);
                    if (varClassTable.MemoryLayout.TotalSize == 0)
                    {
                        CalculateClassSize(varClassTable);
                    }

                    parameter.MemSize += multiplier * varClassTable.MemoryLayout.TotalSize;
                    functionTable.MemoryLayout.AddArgumentEntry(type, parameter.Name, varClassTable.MemoryLayout.TotalSize, parameter.MemSize);
                }
            }

            foreach (var variable in functionTable.LocalScope)
            {
                var multiplier = 1;
                foreach (var dim in variable.ArrayDims)
                {
                    multiplier *= dim;
                }

                var type = variable.Type;
                switch (type.TokenType)
                {
                    case TokenType.Integer:
                        variable.MemSize += multiplier * TypeConstants.IntTypeSize;
                        functionTable.MemoryLayout.AddVariableEntry((TypeConstants.IntType, variable.ArrayDims), variable.Name, TypeConstants.IntTypeSize, variable.MemSize);
                        break;
                    case TokenType.Float:
                        variable.MemSize += multiplier * TypeConstants.FloatTypeSize;
                        functionTable.MemoryLayout.AddVariableEntry((TypeConstants.FloatType, variable.ArrayDims), variable.Name, TypeConstants.IntTypeSize, variable.MemSize);
                        break;
                    case TokenType.Identifier:
                        {
                            var varClassTable = _globalSymbolTable.GetClassSymbolTableByName(type.Lexeme);
                            if (varClassTable.MemoryLayout.TotalSize == 0)
                            {
                                CalculateClassSize(varClassTable);
                            }

                            variable.MemSize += multiplier * varClassTable.MemoryLayout.TotalSize;
                            functionTable.MemoryLayout.AddVariableEntry((varClassTable.ClassName, variable.ArrayDims), variable.Name, varClassTable.MemoryLayout.TotalSize, variable.MemSize);

                            break;
                        }
                }
            }
        }

        private void CalculateFunctionFrameSizesWithIntermediates()
        {
            var visitor = new IntermediateSizeCalculatorVisitor(_globalSymbolTable);
            _astTree.Accept(visitor);
        }
    }
}
