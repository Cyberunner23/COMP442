using System.Collections.Generic;
using System.Linq;

namespace Parser.AST
{
    public class ASTNodeBase
    {
        public int ID { get; private set; }
        public ASTNodeBase ParentNode { get; private set; }
        public ASTNodeBase LeftmostSiblingNode { get; private set; }
        public ASTNodeBase LeftmostChildNode { get; private set; }
        public ASTNodeBase RightSiblingNode { get; private set; }

        private static int _idCtr = 0;

        public ASTNodeBase()
        {
            ID = _idCtr++;
        }

        // makeSibling in the slides
        public ASTNodeBase AddSibling(ASTNodeBase node)
        {
            var xsibs = this;
            while (xsibs.RightSiblingNode != null)
            {
                xsibs = xsibs.RightSiblingNode;
            }

            var ysibs = node.LeftmostSiblingNode;
            xsibs.RightSiblingNode = ysibs;

            ysibs.LeftmostSiblingNode = xsibs.LeftmostSiblingNode;
            ysibs.ParentNode = xsibs.ParentNode;

            while (ysibs.RightSiblingNode != null)
            {
                ysibs = ysibs.RightSiblingNode;
                ysibs.LeftmostSiblingNode = LeftmostSiblingNode;
                ysibs.ParentNode = ParentNode;
            }

            return ysibs;
        }

        public void AdoptChildren(ASTNodeBase child)
        {
            if (LeftmostChildNode != null)
            {
                LeftmostChildNode.AddSibling(child);
            }
            else
            {
                var ysibs = child.LeftmostSiblingNode ?? child;
                LeftmostChildNode = ysibs;
                while (ysibs != null)
                {
                    ysibs.ParentNode = this;
                    ysibs = ysibs.RightSiblingNode;
                }
            }
        }

        public void MakeFamily(List<ASTNodeBase> children)
        {
            if (!children.Any())
            {
                return;
            }

            var firstChild = children.First();
            foreach (var child in children.Skip(1))
            {
                firstChild.AddSibling(child);
            }

            AdoptChildren(firstChild);
        }
    }
}
