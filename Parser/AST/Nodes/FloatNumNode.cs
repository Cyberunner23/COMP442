using Parser.ASTVisitor;
using Parser.Utils;
using System.Collections.Generic;

namespace Parser.AST.Nodes
{
    public class FloatNumNode : ASTNodeBase
    {
        public float Value { get; set; }

        public FloatNumNode()
        {
            ExprType = (TypeConstants.FloatType, new List<int>() { 0 });
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
