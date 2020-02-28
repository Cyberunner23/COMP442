using Lexer;
using Parser.AST;

namespace Parser.ASTBuilder.SemanticRules
{
    public abstract class MakeNodeRule : ISemanticRule
    {
        protected Token PreviousLookahead { get; private set; }
        protected Token Lookahead { get; private set; }

        public void ExecuteRule(ASTBuilder builder)
        {
            PreviousLookahead = builder.PreviousLookahead;
            Lookahead = builder.Lookahead;
            var scope = builder.BottomScope;
            var node = CreateNode();
            scope.Push(node);
        }

        protected abstract ASTNodeBase CreateNode();
    }
}
