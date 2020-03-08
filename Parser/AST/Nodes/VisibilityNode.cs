using Lexer;
using Parser.ASTVisitor;
using System;

namespace Parser.AST.Nodes
{
    public enum Visibility
    {
        Public,
        Private
    }

    public class VisibilityNode : ASTNodeBase
    {
        public Visibility Visibility { get; set; }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            Visibility visibility;
            if (PreviousLookahead.TokenType == TokenType.Private)
            {
                visibility = Visibility.Private;
            }
            else if (PreviousLookahead.TokenType == TokenType.Public)
            {
                visibility = Visibility.Public;
            }
            else
            {
                throw new InvalidOperationException("Invalid use of the _CreateVisibilityNodeRule_");
            }

            return new VisibilityNode() { Token = PreviousLookahead, Visibility = visibility };
        }
    }
}
