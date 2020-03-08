
using Parser.ASTVisitor;

namespace Parser.AST.Nodes
{
    public class IntNumNode : ASTNodeBase
    {
        public int Value { get; set; }

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
