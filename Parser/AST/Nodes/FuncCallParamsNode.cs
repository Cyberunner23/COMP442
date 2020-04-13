using Parser.ASTVisitor;
using System.Collections.Generic;

namespace Parser.AST.Nodes
{
    public class FuncCallParamsNode : ASTNodeBase
    {
        public List<(string, List<int>)> ParamsTypes { get; set; }

        public List<string> ParamTempVarNames { get; set; }

        public FuncCallParamsNode()
        {
            ParamsTypes = new List<(string, List<int>)>();
            ParamTempVarNames = new List<string>();
        }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            return new FuncCallParamsNode();
        }
    }
}
