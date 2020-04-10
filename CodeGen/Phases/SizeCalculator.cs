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
            foreach (var variableEntry in classTable.Entries.Where(x => x is ClassSymbolTableEntryVariable).Cast<ClassSymbolTableEntryVariable>())
            {
                var multiplier = 1;
                foreach (var dim in variableEntry.ArrayDims)
                {
                    multiplier *= dim;
                }

                var type = variableEntry.Type;
                switch (type.TokenType)
                {
                    case TokenType.Integer:
                        variableEntry.MemSize = multiplier * TypeConstants.IntTypeSize;
                        classTable.MemoryLayout.AddEntry((TypeConstants.IntType, variableEntry.ArrayDims), variableEntry.Name, TypeConstants.IntTypeSize, variableEntry.MemSize);
                        break;
                    case TokenType.Float:
                        variableEntry.MemSize = multiplier * TypeConstants.FloatTypeSize;
                        classTable.MemoryLayout.AddEntry((TypeConstants.FloatType, variableEntry.ArrayDims), variableEntry.Name, TypeConstants.FloatTypeSize, variableEntry.MemSize);
                        break;
                    case TokenType.Identifier:
                        {
                            var varClassTable = _globalSymbolTable.GetClassSymbolTableByName(type.Lexeme);
                            if (varClassTable.MemoryLayout.TotalSize == 0)
                            {
                                CalculateClassSize(varClassTable);
                            }

                            variableEntry.MemSize = multiplier * varClassTable.MemoryLayout.TotalSize;
                            classTable.MemoryLayout.AddEntry((varClassTable.ClassName, variableEntry.ArrayDims), variableEntry.Name, varClassTable.MemoryLayout.TotalSize, variableEntry.MemSize);

                            break;
                        }
                }

                variableEntry.MemOffset = classTable.MemoryLayout.GetOffset(variableEntry.Name);
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
            var visitor = new IntermediateSizeCalculatorVisitor();
            _astTree.Accept(visitor);
        }
    }
}
