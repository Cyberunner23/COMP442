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

    }
}
