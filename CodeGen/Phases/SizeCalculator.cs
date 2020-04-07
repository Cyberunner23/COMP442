using System;
using System.Collections.Generic;
using System.Linq;

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

            var currentOffset = 0;
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
                        break;
                    case TokenType.Float:
                        variableEntry.MemSize = multiplier * TypeConstants.FloatTypeSize;
                        break;
                    case TokenType.Identifier:
                        {
                            var varClassTable = _globalSymbolTable.GetClassSymbolTableByName(type.Lexeme);
                            if (varClassTable.MemSize == 0)
                            {
                                CalculateClassSize(varClassTable);
                            }

                            variableEntry.MemSize = multiplier * varClassTable.MemSize;

                            break;
                        }
                }

                variableEntry.MemOffset = currentOffset;
                currentOffset += variableEntry.MemSize;
                classTable.MemSize += variableEntry.MemSize;
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
            const int returnOffset = 4; // Room for return address

            int currentFrameOffset = -returnOffset;
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
                    parameter.MemSize += multiplier * TypeConstants.IntTypeSize;
                }
                else if (string.Equals(type.type, TypeConstants.FloatType))
                {
                    parameter.MemSize += multiplier * TypeConstants.FloatTypeSize;
                }
                else
                {
                    var varClassTable = _globalSymbolTable.GetClassSymbolTableByName(type.type);
                    if (varClassTable.MemSize == 0)
                    {
                        CalculateClassSize(varClassTable);
                    }

                    parameter.MemSize += multiplier * varClassTable.MemSize;
                }

                currentFrameOffset -= parameter.MemSize;
                parameter.MemOffset = currentFrameOffset;
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
                        break;
                    case TokenType.Float:
                        variable.MemSize += multiplier * TypeConstants.FloatTypeSize;
                        break;
                    case TokenType.Identifier:
                        {
                            var varClassTable = _globalSymbolTable.GetClassSymbolTableByName(type.Lexeme);
                            if (varClassTable.MemSize == 0)
                            {
                                CalculateClassSize(varClassTable);
                            }

                            variable.MemSize += multiplier * varClassTable.MemSize;

                            break;
                        }
                }

                currentFrameOffset -= variable.MemSize;
                variable.MemOffset = currentFrameOffset;
            }

            functionTable.FrameSize = -currentFrameOffset;
        }

        private void CalculateFunctionFrameSizesWithIntermediates()
        {
            
        }
    }
}
