using Lexer;
using Parser.ASTVisitor;
using System;

namespace Parser.AST.Nodes
{
    public enum AddOp
    {
        Add,
        Subtract,
        Or
    }

    public class AddOpNode : ASTNodeBase
    {
        public AddOp Op { get; set; }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            AddOp op;
            switch (PreviousLookahead.TokenType)
            {
                case TokenType.Plus:
                    op = AddOp.Add;
                    break;
                case TokenType.Minus:
                    op = AddOp.Subtract;
                    break;
                case TokenType.Or:
                    op = AddOp.Or;
                    break;
                default:
                    throw new InvalidOperationException("Invalid use of the _CreateAddOpNodeRule_");
            }

            return new AddOpNode() { Op = op };
        }
    }
}
