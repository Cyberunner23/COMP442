using System;
using System.Collections.Generic;
using System.Linq;
using Parser.AST;
using Parser.AST.Nodes;
using Parser.SymbolTable;
using Parser.SymbolTable.Class;
using Parser.Utils;

namespace Parser.ASTVisitor.Visitors
{
    public class SymbolTableVisitor : IVisitor
    {
        public GlobalSymbolTable GlobalSymbolTable { get; private set; }

        public SymbolTableVisitor()
        {
            GlobalSymbolTable = new GlobalSymbolTable();
        }

        public void Visit(ProgramNode n)
        {
            var children = n.GetChildren();
            foreach(var child in children)
            {
                child.Accept(this);
            }
        }

        #region Class Tables
        public void Visit(ClassDeclsNode n)
        {
            var children = n.GetChildren().Cast<ClassDeclNode>();
            foreach (var child in children)
            {
                child.Table = new ClassSymbolTable(GlobalSymbolTable);
                child.Accept(this);

                GlobalSymbolTable.AddClassSymbolTable(child.Table);
            }
        }

        public void Visit(ClassDeclNode n)
        {
            var children = n.GetChildren();
            n.Table.ClassName = children[0].Token.Lexeme;

            var inheritList = children[1].GetChildren().Select(x => x.Token.Lexeme);
            n.Table.Inherits.AddRange(inheritList);

            var memberDecls = children.GetCast<MemberDeclsNode>(2);
            memberDecls.Table = n.Table;
            memberDecls.Accept(this);
        }

        public void Visit(MemberDeclsNode n)
        {
            var children = n.GetChildren().Cast<MemberDeclNode>();
            foreach (var child in children)
            {
                child.Table = n.Table;
                child.Accept(this);
            }
        }

        private void HandleMemberDeclVariable(MemberDeclNode n)
        {
            var children = n.GetChildren();
            
            var visibility = children.GetCast<VisibilityNode>(0).Visibility;
            var type = children[1].Token;
            var name = children[2].Token.Lexeme;
            var arrayDims = NodeUtils.ExtractArrayDimListNode(children.GetCast<ArrayDimListNode>(3));

            var tableEntry = new ClassSymbolTableEntryVariable()
            {
                Visibility = visibility,
                Type = type,
                Name = name,
                ArrayDims = arrayDims
            };

            n.Table.AddEntry(tableEntry);
        }

        private void HandleMemberDeclFunction(MemberDeclNode n)
        {
            var children = n.GetChildren();

            var visibility = children.GetCast<VisibilityNode>(0).Visibility;
            var name = children[1].Token.Lexeme;
            var funcParamList = children[2].GetChildren();
            var type = children[3].Token;

            var tableEntry = new ClassSymbolTableEntryFunction()
            {
                Visibility = visibility,
                Name = name,
                Type = type
            };

            for (int i = 0; i < funcParamList.Count; i += 3)
            {
                var paramType = funcParamList[i + 0].Token;
                var paramName = funcParamList[i + 1].Token.Lexeme;
                var arrayDims = NodeUtils.ExtractArrayDimListNode(funcParamList.GetCast<ArrayDimListNode>(i + 2));

                var entry = new ClassSymbolTableEntryFunctionParam()
                {
                    Type = paramType,
                    Name = paramName,
                    ArrayDims = arrayDims,
                };

                tableEntry.AddEntry(entry);
            }

            n.Table.AddEntry(tableEntry);
        }

        public void Visit(MemberDeclNode n)
        {
            switch (n.DeclType)
            {
                case DeclType.Function:
                    HandleMemberDeclFunction(n);
                    break;
                case DeclType.Variable:
                    HandleMemberDeclVariable(n);
                    break;
                default:
                    throw new InvalidOperationException("Invalid DeclType found.");
            }
        }
        #endregion





        public void Visit(FuncDefsNode n)
        {
            //throw new NotImplementedException();
        }

        public void Visit(MainFuncNode n)
        {
            //throw new NotImplementedException();
        }

        public void Visit(NullNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(IdentifierNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(InheritListNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(FuncDefNode n)
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

        public void Visit(FuncBodyNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(LocalScopeNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(StatementsNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(VarDeclNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(IfNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(BoolExpressionNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(CompareOpNode n)
        {
            throw new NotImplementedException();
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

        public void Visit(NotNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(SignNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(AddOpNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(MultOpNode n)
        {
            throw new NotImplementedException();
        }

        public void Visit(ArithExprNode n)
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
    }
}
