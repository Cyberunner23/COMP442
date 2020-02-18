using Parser.AST;
using Parser.AST.Nodes;

namespace Parser.ASTBuilder.SemanticRules.MakeNodeRules
{
    class MakeClassDeclsNodeRule : MakeNodeRule
    {
        protected override ASTNodeBase CreateNode()
        {
            return new ClassDeclsNode();
        }
    }
}
