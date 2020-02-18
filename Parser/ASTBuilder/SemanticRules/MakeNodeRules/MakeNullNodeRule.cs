using Parser.AST;
using Parser.AST.Nodes;

namespace Parser.ASTBuilder.SemanticRules.MakeNodeRules
{
    class MakeNullNodeRule : MakeNodeRule
    {
        protected override ASTNodeBase CreateNode()
        {
            return new NullNode();
        }
    }
}
