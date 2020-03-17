
using Parser.ASTVisitor;
using Parser.Utils;
using System.Collections.Generic;

namespace Parser.AST.Nodes
{
    public class IntNumNode : ASTNodeBase
    {
        public int Value { get; set; }

        public IntNumNode()
        {
            ExprType = (TypeConstants.IntType, new List<int>() { 0 });
        }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            string value = PreviousLookahead.Lexeme;
            int intVal = int.Parse(value);
            return new IntNumNode() { Token = PreviousLookahead, Value = intVal };
        }
    }
}
