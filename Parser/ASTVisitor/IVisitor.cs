using Parser.AST.Nodes;

namespace Parser.ASTVisitor
{
    public interface IVisitor
    {
        void Visit(ProgramNode n);
        void Visit(ClassDeclsNode n);
        void Visit(ClassDeclNode n);
        void Visit(FuncDefsNode n);
        void Visit(NullNode n);
        void Visit(MemberDeclsNode n);
        void Visit(IdentifierNode n);
        void Visit(InheritListNode n);
        void Visit(FuncDefNode n);
        void Visit(TypeNode n);
        void Visit(FuncParamListNode n);
        void Visit(ArrayDimListNode n);
        void Visit(ArrayDimNode n);
        void Visit(IntNumNode n);
        void Visit(FuncBodyNode n);
        void Visit(LocalScopeNode n);
        void Visit(StatementsNode n);
        void Visit(VarDeclNode n);
        void Visit(IfNode n);
        void Visit(BoolExpressionNode n);
        void Visit(CompareOpNode n);
        void Visit(WhileNode n);
        void Visit(ReadNode n);
        void Visit(WriteNode n);
        void Visit(ReturnNode n);

        void Visit(FuncCallNode n);
        void Visit(AssignmentNode n);
        void Visit(SubFuncCallNode n);
        void Visit(SubVarCallNode n);
        void Visit(IndicesNode n);
        void Visit(FuncCallParamsNode n);
        void Visit(ExpressionNode n);

        void Visit(FloatNumNode n);
        void Visit(NotNode n);
        void Visit(SignNode n);
        void Visit(AddOpNode n);
        void Visit(MultOpNode n);

    }
}
