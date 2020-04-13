using System;
using System.Linq;
using Lexer;
using Parser.AST.Nodes;
using Parser.ASTVisitor;
using Parser.SymbolTable;
using Parser.SymbolTable.Class;
using Parser.SymbolTable.Function;
using Parser.Utils;

namespace CodeGen.ASTVisitors
{
    class IntermediateSizeCalculatorVisitor : IVisitor
    {
        private GlobalSymbolTable _globalSymbolTable;

        public IntermediateSizeCalculatorVisitor(GlobalSymbolTable table)
        {
            _globalSymbolTable = table;
        }

        private int GetSize(Token token)
        {
            int size;
            switch (token.TokenType)
            {
                case TokenType.Integer:
                    size = TypeConstants.IntTypeSize;
                    break;
                case TokenType.Float:
                    size = TypeConstants.FloatTypeSize;
                    break;
                case TokenType.Identifier:
                    var table = _globalSymbolTable.GetClassSymbolTableByName(token.Lexeme);
                    size = table.MemoryLayout.TotalSize;
                    break;
                default:
                    throw new InvalidOperationException("Unknown type.");
            }

            return size;
        }


        public void Visit(ProgramNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ClassDeclsNode n)
        {
        }

        public void Visit(ClassDeclNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncDefsNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(NullNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(MemberDeclsNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(IdentifierNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(InheritListNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncDefNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(TypeNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncParamListNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ArrayDimListNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ArrayDimNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(IntNumNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            n.TemporaryVariableName = table.MemoryLayout.AddTemporaryVariable();
        }

        public void Visit(FloatNumNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            n.TemporaryVariableName = table.MemoryLayout.AddTemporaryVariable();
        }

        public void Visit(FuncBodyNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(LocalScopeNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(StatementsNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(VarDeclNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(IfNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(BoolExpressionNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            n.TemporaryVariableName = table.MemoryLayout.AddTemporaryVariable();

            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(CompareOpNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(WhileNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ReadNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(WriteNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ReturnNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncCallNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(AssignmentNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(SubFuncCallNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }

            var returnValSize = Utils.GetTypeFullSize(_globalSymbolTable, n.ExprType);
            var table = (FunctionSymbolTableEntry)n.CallerTable;
            n.TemporaryVariableName = table.MemoryLayout.AddTemporaryVariable(returnValSize);
        }

        public void Visit(SubVarCallNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(VarFuncCallNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }

            var table = (FunctionSymbolTableEntry)n.SymTable;
            var last = children.Last();
            var size = Utils.GetTypeFullSize(_globalSymbolTable, last.ExprType);

            n.TemporaryVariableName = table.MemoryLayout.AddTemporaryVariable(size);
        }

        public void Visit(IndicesNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncCallParamsNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ExpressionNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(NotNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            n.TemporaryVariableName = table.MemoryLayout.AddTemporaryVariable();

            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(SignNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            n.TemporaryVariableName = table.MemoryLayout.AddTemporaryVariable();

            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(AddOpNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            n.TemporaryVariableName = table.MemoryLayout.AddTemporaryVariable();

            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(MultOpNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            n.TemporaryVariableName = table.MemoryLayout.AddTemporaryVariable();

            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ArithExprNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        

        public void Visit(VisibilityNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(MemberDeclNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(MainFuncNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }
    }
}
