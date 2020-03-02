using System;
using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public class SubVarCallNode : ASTNodeBase
    {
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new SubVarCallNode();
        }
    }
}
