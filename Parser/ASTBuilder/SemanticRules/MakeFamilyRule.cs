using System;
using System.Linq;

namespace Parser.ASTBuilder.SemanticRules
{
    class MakeFamilyRule : ISemanticRule
    {
        private int _count;
        public MakeFamilyRule()
        {
            _count = 0;
        }

        public MakeFamilyRule(int count)
        {
            _count = count;
        }

        public void ExecuteRule(ASTBuilder builder)
        {
            var bottomScope = builder.BottomScope;
            if (bottomScope.Count < 1)
            {
                throw new InvalidOperationException("Can't make node family without at least a parent");
            }

            var parentNode = bottomScope.Pop();

            var skipNum = _count == 0 ? 0 : bottomScope.Count - _count;
            var childNodes = bottomScope.Reverse().Skip(Math.Max(0, skipNum)).ToList();
            if (skipNum == 0)
            {
                bottomScope.Clear();
            }
            else
            {
                for (var i = 0; i < _count; ++i)
                {
                    bottomScope.Pop();
                }

            }
            
            parentNode.MakeFamily(childNodes);
            bottomScope.Push(parentNode);
        }
    }
}
