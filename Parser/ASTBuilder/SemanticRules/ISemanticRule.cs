using Lexer;

namespace Parser.ASTBuilder.SemanticRules
{
    interface ISemanticRule : IRule
    {
        void ExecuteRule(ASTBuilder builder);
    }
}
