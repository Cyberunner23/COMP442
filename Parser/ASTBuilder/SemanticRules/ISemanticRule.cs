using Lexer;

namespace Parser.ASTBuilder.SemanticRules
{
    public interface ISemanticRule : IRule
    {
        void ExecuteRule(ASTBuilder builder);
    }
}
