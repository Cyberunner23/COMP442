using Lexer;
using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public class IdentifierNode : ASTNodeBase
    {
        public Token Token { get; private set; }

        public IdentifierNode()
        {

        }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new IdentifierNode() { Token = PreviousLookahead };
        }
    }
}
