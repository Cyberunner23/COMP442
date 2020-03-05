using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public enum DeclType
    {
        Function,
        Variable
    }

    public class MemberDeclNode : ASTNodeBase
    {
        public DeclType DeclType { get; set; }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new MemberDeclNode() { DeclType = DeclType };
        }
    }
}
