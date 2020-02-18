using System;
using System.Collections.Generic;
using Lexer;
using Parser.AST;
using Parser.AST.Nodes;
using Parser.ASTBuilder.SemanticRules;

namespace Parser.ASTBuilder
{
    public class ASTBuilder
    {
        public Stack<ASTNodeBase> BottomScope { get { return _semanticScopeStack.Peek(); } }
        public Token Lookahead { get; private set; }

        private Stack<Stack<ASTNodeBase>> _semanticScopeStack;

        public ASTBuilder()
        {
            _semanticScopeStack = new Stack<Stack<ASTNodeBase>>();
            GoDownScopeLevel(); // 0th level scope
        }

        public ProgramNode GetASTTree()
        {
            if (_semanticScopeStack.Count != 1)
            {
                throw new InvalidOperationException("Semantic stack is not at the 0th level.");
            }

            var bottomLevelScope = _semanticScopeStack.Peek();
            if (bottomLevelScope.Count != 1)
            {
                throw new InvalidOperationException("The 0th level scope does not have exactly one node.");
            }

            var programNode = bottomLevelScope.Peek() as ProgramNode;
            if (programNode == null)
            {
                throw new InvalidOperationException("The node in the 0th level scope is not a program node.");
            }

            return programNode;
        }

        public Stack<ASTNodeBase> GoUpScopeLevel()
        {
            var removedStack = _semanticScopeStack.Pop();
            if (removedStack.Count != 1)
            {
                throw new InvalidOperationException("Current scope does not have exactly one node in it.");
            }

            var node = removedStack.Pop();
            BottomScope.Push(node);

            return BottomScope;
        }

        public Stack<ASTNodeBase> GoDownScopeLevel()
        {
            var newScope = new Stack<ASTNodeBase>();
            _semanticScopeStack.Push(newScope);
            return newScope;
        }

        public void HandleSemanticRule(ISemanticRule semanticRule, Token lookahead)
        {
            Lookahead = lookahead;
            semanticRule.ExecuteRule(this);
        }
    }
}
