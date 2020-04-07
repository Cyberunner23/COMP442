using CodeGen.Phases;
using Parser.AST;
using Parser.SymbolTable;
using System.IO;

namespace CodeGen
{
    public class CodeGen
    {

        private ASTNodeBase _astTree;
        private GlobalSymbolTable _globalSymbolTable;
        private StreamWriter _codeStream;

        private SizeCalculator _sizeCalculator;

        public CodeGen(ASTNodeBase astTree, GlobalSymbolTable globalSymbolTable, StreamWriter codeStream)
        {
            _astTree = astTree;
            _globalSymbolTable = globalSymbolTable;
            _codeStream = codeStream;

            _sizeCalculator = new SizeCalculator(_astTree, _globalSymbolTable);
        }

        public void GenerateCode()
        {
            _sizeCalculator.Calculate();
        }

        



    }
}
