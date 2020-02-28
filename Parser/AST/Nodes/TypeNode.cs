using Lexer;
using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public class TypeNode : ASTNodeBase
    {
        public Token Token { get; set; }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new TypeNode() { Token = PreviousLookahead };
        }
    }
}
