using Parser.AST;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parser.ASTBuilder.SemanticRules
{
    class MakeFamilyRule : ISemanticRule
    {
        private int _count;
        private int _parentIndex;

        public MakeFamilyRule()
        {
            _count = 0;
            _parentIndex = 0;
        }

        public MakeFamilyRule(int count)
        {
            _count = count;
        }

        public MakeFamilyRule(int count, int parentIndex)
        {
            _count = count;
            _parentIndex = parentIndex;

            if (_parentIndex > _count)
            {
                throw new InvalidOperationException("Invalid!");
            }
        }

        public void ExecuteRule(ASTBuilder builder)
        {
            var bottomScope = builder.BottomScope;
            if (bottomScope.Count < 1)
            {
                throw new InvalidOperationException("Can't make node family without at least a parent");
            }


            if (_parentIndex == 0)
            {
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
            else
            {
                List<ASTNodeBase> childNodes = new List<ASTNodeBase>();

                int indexCtr = 0;
                int countCtr = 0;
                for (; countCtr < _count; countCtr++)
                {
                    if (indexCtr == _parentIndex)
                    {
                        break;
                    }

                    childNodes.Add(bottomScope.Pop());

                    indexCtr++;
                }

                var parentNode = bottomScope.Pop();

                for (int i = countCtr; i < _count; i++)
                {
                    childNodes.Add(bottomScope.Pop());
                }

                parentNode.MakeFamily(childNodes);
                bottomScope.Push(parentNode);
            }

            
        }
    }
}
