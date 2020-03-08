using Parser.ASTVisitor;
using Parser.SymbolTable;
using Parser.SymbolTable.Class;

namespace Parser.AST.Nodes
{
    public class MemberDeclsNode : ASTNodeBase
    {
        public ClassSymbolTable Table { get; set; }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new MemberDeclsNode();
        }
    }
}
