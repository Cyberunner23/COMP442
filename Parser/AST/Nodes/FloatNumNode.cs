using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public class FloatNumNode : ASTNodeBase
    {
        public float Value { get; set; }

        public const string TYPE = "float";

        public FloatNumNode()
        {
            ExprType = TYPE;
        }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            string value = PreviousLookahead.Lexeme;
            float floatVal = float.Parse(value);
            return new FloatNumNode() { Token = PreviousLookahead, Value = floatVal };
        }
    }
}
