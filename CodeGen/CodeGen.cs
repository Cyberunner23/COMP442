
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

        }

        private void GenerateFooter()
        {
            _writer.WriteComment("Program footer");
            _writer.WriteInstruction(Instructions.Hlt);
            _writer.WriteTag(Tags.BaseAddr);
        }

        private void Generate()
        {
            var visitor = new CodeGeneratorVisitor(_writer, _globalSymbolTable);
            _astTree.Accept(visitor);
        }
    }
}
