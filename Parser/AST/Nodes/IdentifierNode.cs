using Lexer;
using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public class IdentifierNode : ASTNodeBase
    {
        public string Name { get { return Token.Lexeme; } }

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
