using Parser.AST;
using Parser.AST.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace Parser.Utils
{
    public static class NodeUtils
    {
        public static T GetCast<T>(this List<ASTNodeBase> collection, int index) where T : ASTNodeBase
        {
            return (T)collection[index];
        }

        public static List<int> ExtractArrayDimListNode(ArrayDimListNode n)
        {
            return n.GetChildren()
                    .Cast<ArrayDimNode>()
                    .Select(x => x.GetChildren().FirstOrDefault() ?? new IntNumNode() { Value = 0 } )
                    .Cast<IntNumNode>()
                    .Select(x => x.Value)
                    .ToList();
        }
    }
}
