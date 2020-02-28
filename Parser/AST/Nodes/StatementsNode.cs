using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public class StatementsNode : ASTNodeBase
    {
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new StatementsNode();
        }
    }
}
