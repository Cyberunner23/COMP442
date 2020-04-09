using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public class NotNode : ASTNodeBase
    { 
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new NotNode() { Token = PreviousPreviousLookahead };
        }
    }
}
