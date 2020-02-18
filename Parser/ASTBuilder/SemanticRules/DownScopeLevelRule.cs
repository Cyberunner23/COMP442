using System.Collections.Generic;

namespace Parser.ASTBuilder.SemanticRules
{
    class DownScopeLevelRule : ISemanticRule
    {
        public void ExecuteRule(ASTBuilder builder)
        {
            builder.GoDownScopeLevel();
        }
    }
}
