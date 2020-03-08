using Lexer;
using Parser.ASTVisitor;
using System;

namespace Parser.AST.Nodes
{
    public enum CompareOpType
    {
        Equals,
        NotEquals,
        LessThan,
        GreaterThan,
        LessThanEqual,
        GreaterThanEqual
    }

    public class CompareOpNode : ASTNodeBase
    {
        public CompareOpType CompareOpType { get; set; }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            CompareOpType opType;
            switch (PreviousLookahead.TokenType)
            {
                case TokenType.EqualEqual:
                    opType = CompareOpType.Equals;
                    break;
                case TokenType.LesserGreater:
                    opType = CompareOpType.NotEquals;
                    break;
                case TokenType.Lesser:
                    opType = CompareOpType.LessThan;
                    break;
                case TokenType.Greater:
                    opType = CompareOpType.GreaterThan;
                    break;
                case TokenType.LesserEqual:
                    opType = CompareOpType.LessThanEqual;
                    break;
                case TokenType.GreaterEqual:
                    opType = CompareOpType.GreaterThanEqual;
                    break;
                default:
                    throw new InvalidOperationException("Invalid use of _CreateCompareOpNodeRule_");
            }

            return new CompareOpNode() { Token = PreviousLookahead, CompareOpType = opType };
        }
    }
}
