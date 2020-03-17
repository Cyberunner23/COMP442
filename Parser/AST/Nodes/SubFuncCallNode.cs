using Parser.ASTVisitor;
using System.Collections.Generic;

namespace Parser.AST.Nodes
{
    public class SubFuncCallNode : ASTNodeBase
    {
        public string FuncName { get; set; }
        public KeyValuePair<string, int> ReturnType { get; set; }
        public List<KeyValuePair<string, int>> ParamTypes { get; set; }

        public SubFuncCallNode()
        {
            ParamTypes = new List<KeyValuePair<string, int>>();
        }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new SubFuncCallNode();
        }
    }
}
