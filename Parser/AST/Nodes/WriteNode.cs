using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public class WriteNode : ASTNodeBase
    {
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new WriteNode();
        }
    }
}
