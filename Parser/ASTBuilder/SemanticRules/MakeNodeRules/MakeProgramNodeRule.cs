using Parser.AST;
using Parser.AST.Nodes;

namespace Parser.ASTBuilder.SemanticRules.MakeNodeRules
{
    class MakeProgramNodeRule : MakeNodeRule
    {
        protected override ASTNodeBase CreateNode()
        {
            return new ProgramNode();
        }
    }
}
