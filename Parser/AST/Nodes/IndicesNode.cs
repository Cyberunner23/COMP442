using Parser.ASTVisitor;
using System.Collections.Generic;

namespace Parser.AST.Nodes
{
    public class IndicesNode : ASTNodeBase
    {
        public int NumDims { get { return GetChildren().Count; } }

        public List<string> TemporaryVariableNames { get; private set; } = new List<string>();

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new IndicesNode();
        }
    }
}
