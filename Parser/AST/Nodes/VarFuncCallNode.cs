using Parser.ASTVisitor;
using System;
using System.Collections.Generic;

namespace Parser.AST.Nodes
{
    public enum CallType
    {
        VarCall,
        FuncCall
    }

    public class VarFuncCallNode : ASTNodeBase
    {
        public CallType CallType { get; set; }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        protected override ASTNodeBase CreateNode()
        {
            var bottomScope = Builder.BottomScope;

            // NOTE: Hacky hack hack
            // NOTE: For some reason, if a VarFuncCall chain ends with a var, 
            //       it doesnt reach the indices part of the grammar
            if (bottomScope.Peek() is IdentifierNode)
            {
                var identifier = bottomScope.Pop();

                var subVarCallNode = new SubVarCallNode();
                subVarCallNode.MakeFamily(new List<ASTNodeBase>() { identifier, new IndicesNode() });

                bottomScope.Push(subVarCallNode);
            }

            if (bottomScope.Peek() is SubVarCallNode)
            {
                return new VarFuncCallNode() { CallType = CallType.VarCall };
            }
            else if (bottomScope.Peek() is SubFuncCallNode)
            {
                return new VarFuncCallNode() { CallType = CallType.FuncCall };
            }
            else
            {
                throw new InvalidOperationException("Invalid use of _CreateVarFuncCallNodeRule_");
            }
        }
    }
}
