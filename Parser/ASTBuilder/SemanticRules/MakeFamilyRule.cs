using System;
using System.Linq;

namespace Parser.ASTBuilder.SemanticRules
{
    class MakeFamilyRule : ISemanticRule
    {
        public void ExecuteRule(ASTBuilder builder)
        {
            var bottomScope = builder.BottomScope;
            if (bottomScope.Count < 1)
            {
                throw new InvalidOperationException("Can't make node family without at least a parent");
            }

            var parentNode = bottomScope.Pop();
            var childNodes = bottomScope.Reverse().ToList();
            bottomScope.Clear();
            parentNode.MakeFamily(childNodes);
            bottomScope.Push(parentNode);
        }
    }
}
