using Lexer;
using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public class CompareOpNode : ASTNodeBase
    {
        public TokenType CompareOpType { get; set; }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new CompareOpNode() { CompareOpType = PreviousLookahead.TokenType };
        }
    }
}
