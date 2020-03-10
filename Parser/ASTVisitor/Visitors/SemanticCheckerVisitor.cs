using System;
using System.IO;
using System.Linq;
using Parser.AST.Nodes;

namespace Parser.ASTVisitor.Visitors
{
    public class SemanticCheckerVisitor : IVisitor
    {
        private StreamWriter _errorStream;

        public SemanticCheckerVisitor(StreamWriter errorStream)
        {
            _errorStream = errorStream;
        }

        public void Visit(ProgramNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ClassDeclsNode n) {  }

        public void Visit(ClassDeclNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(FuncDefsNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(IdentifierNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(FuncDefNode n)
        {
            var funcBody = (FuncBodyNode)n.GetChildren().Last();
            funcBody.SymTable = n.Table;
            funcBody.Accept(this);
        }

        public void Visit(FuncBodyNode n)
        {
            var statements = (StatementsNode)n.GetChildren().Last();
            statements.SymTable = n.SymTable;
            statements.Accept(this);
        }

        #region Statements
        public void Visit(StatementsNode n)
        {
            // TODO

            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(IfNode n)
        {
            //TODO 

            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(WhileNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(ReadNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(WriteNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(ReturnNode n)
        {
            throw new NotImplementedException();
        }
        #endregion


        public void Visit(BoolExpressionNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }

            // TODO(AFL): Type check
        }

        public void Visit(ArithExprNode n)
        {
            var child = n.GetChildren().Single();
            child.Accept(this);
            n.ExprType = child.ExprType;
        }

        public void Visit(NotNode n)
        {
            var child = n.GetChildren().Single();
            child.Accept(this);
            n.ExprType = child.ExprType;
        }

        public void Visit(SignNode n)
        {
            var child = n.GetChildren().Single();
            child.Accept(this);
            n.ExprType = child.ExprType;
        }

        public void Visit(AddOpNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(MultOpNode n)
        {
            throw new NotImplementedException();
        }







        public void Visit(NullNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(MemberDeclsNode n)
        {
            throw new NotImplementedException();
        }

        

        public void Visit(InheritListNode n)
        {
            throw new NotImplementedException();
        }

        

        public void Visit(TypeNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(FuncParamListNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(ArrayDimListNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(ArrayDimNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(IntNumNode n)
        {
            throw new NotImplementedException();
        }

        

        public void Visit(LocalScopeNode n)
        {
            throw new NotImplementedException();
        }

        

        public void Visit(VarDeclNode n)
        {
            throw new NotImplementedException();
        }


        

        public void Visit(CompareOpNode n)
        {
            throw new NotImplementedException();
        }

        

        

        

        

        public void Visit(FuncCallNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(AssignmentNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(SubFuncCallNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(SubVarCallNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(IndicesNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(FuncCallParamsNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(ExpressionNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(FloatNumNode n)
        {
            throw new NotImplementedException();
        }

        

        

        

        public void Visit(VarFuncCallNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(VisibilityNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(MemberDeclNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(MainFuncNode n)
        {
            throw new NotImplementedException();
        }
    }
}
