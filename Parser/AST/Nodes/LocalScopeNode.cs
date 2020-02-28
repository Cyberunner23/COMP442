using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public class LocalScopeNode : ASTNodeBase
    {
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new LocalScopeNode();
        }
    }
}
