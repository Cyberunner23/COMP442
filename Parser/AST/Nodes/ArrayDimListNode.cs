using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public class ArrayDimListNode : ASTNodeBase
    {
        public int NumDims { get { return GetChildren().Count; } }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new ArrayDimListNode();
        }
    }
}
