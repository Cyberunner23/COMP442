using System.Collections.Generic;
using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public class SubVarCallNode : ASTNodeBase
    {

        // NOTE: This is whats in the tree,
        //       ExprType is the type found in the table
        public string VarName { get; set; }
        public int NumDims { get; set; }

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
