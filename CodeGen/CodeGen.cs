
using System;
using CodeGen.ASTVisitors;
using CodeGen.Phases;
using Parser.AST;
using Parser.SymbolTable;

namespace CodeGen
{
    public class CodeGen
    {

        private ASTNodeBase _astTree;
        private GlobalSymbolTable _globalSymbolTable;
        private CodeWriter _writer;

        private SizeCalculator _sizeCalculator;

        public CodeGen(ASTNodeBase astTree, GlobalSymbolTable globalSymbolTable, CodeWriter codeStream)
        {
            _astTree = astTree;
            _globalSymbolTable = globalSymbolTable;
            _writer = codeStream;

            _sizeCalculator = new SizeCalculator(_astTree, _globalSymbolTable);
        }

        public void GenerateCode()
        {
            _sizeCalculator.Calculate();

            GenerateHeader();
            Generate();
            GenerateFooter();
        }

        private void GenerateHeader()
        {
            _writer.WriteComment("Start of the program");
            _writer.WriteInstruction(Instructions.Align);
            _writer.WriteInstruction(Instructions.Entry);
            _writer.WriteComment("Set stack pointer to initial value (baseaddr)");
            _writer.WriteInstruction(Instructions.Add, Registers.R14, Registers.R14, Tags.BaseAddr);
        }

        private void GenerateFooter()
        {
            _writer.WriteComment("Program footer");
            _writer.WriteTag(Tags.Zeroval);
            _writer.WriteInstruction(Instructions.Dw, "0");
            _writer.WriteTag(Tags.BaseAddr);
        }

        private void Generate()
        {
            var visitor = new CodeGeneratorVisitor(_writer);
            _astTree.Accept(visitor);
        }
    }
}
