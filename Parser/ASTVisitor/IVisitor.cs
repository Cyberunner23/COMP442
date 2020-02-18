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
    }
}
