using Lexer;
using System;

namespace Parser.ASTBuilder.SemanticRules
{
    class UpScopeLevelRule : ISemanticRule
    {
        public void ExecuteRule(ASTBuilder builder)
        {
            builder.GoUpScopeLevel();
        }
    }
}
