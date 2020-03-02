using Lexer;
using Parser.ASTVisitor;
using System;

namespace Parser.AST.Nodes
{
    public enum Sign
    {
        Plus,
        Minus
    }

    public class SignNode : ASTNodeBase
    {
        public Sign Sign { get; set; }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            Sign sign;
            switch (PreviousPreviousLookahead.TokenType)
            {
                case TokenType.Plus:
                    sign = Sign.Plus;
                    break;
                case TokenType.Minus:
                    sign = Sign.Minus;
                    break;
                default:
                    throw new InvalidOperationException("Invalid use of the _CreateSignNodeRule_");
            }

            return new SignNode() { Sign = sign };
        }
    }
}
