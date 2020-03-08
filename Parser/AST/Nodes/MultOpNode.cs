using System;
using Lexer;
using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public enum MultOp
    {
        Multiply,
        Divide,
        And
    }

    public class MultOpNode : ASTNodeBase
    {
        public MultOp Op { get; set; }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            MultOp op;
            switch(PreviousLookahead.TokenType)
            {
                case TokenType.Asterix:
                    op = MultOp.Multiply;
                    break;
                case TokenType.FwdSlash:
                    op = MultOp.Divide;
                    break;
                case TokenType.And:
                    op = MultOp.And;
                    break;
                default:
                    throw new InvalidOperationException("Invalid use of the _CreateMultOpNodeRule_");
            }

            return new MultOpNode() { Token = PreviousLookahead, Op = op };
        }
    }
}
