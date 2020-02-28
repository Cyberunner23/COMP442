using System.IO;

using Parser.AST;
using Parser.AST.Nodes;
using Parser.Utils;

namespace Parser.ASTVisitor.Visitors
{
    public class DOTPrinterVisitor : IVisitor
    {
        private StreamWriter _stream;

        public DOTPrinterVisitor(StreamWriter outputStream)
        {
            _stream = outputStream;
        }

        #region Utils
        
        private void PrintDOTIDLabel(ASTNodeBase node)
        {
            var stringifiedType = TypePrintUtils.StringifyType(node.GetType());
            _stream.WriteLine($"{node.ID}[label=\"{node.ID}:{stringifiedType}\"]");
        }

        private void PrintDOTIDLabel(ASTNodeBase node, string data)
        {
            var stringifiedType = TypePrintUtils.StringifyType(node.GetType());
            _stream.WriteLine($"{node.ID}[label=\"{node.ID}:{stringifiedType}\\n{data}\"]");
        }

        private void PrintDOTParentChild(ASTNodeBase node)
        {
            var parent = node.ParentNode;
            _stream.WriteLine($"{parent.ID} -> {node.ID}");
        }

        #endregion Utils

        public void Visit(ProgramNode n)
        {
            _stream.WriteLine("digraph G {");
            PrintDOTIDLabel(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
            _stream.WriteLine("}");
        }

        public void Visit(ClassDeclsNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(ClassDeclNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncDefsNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(NullNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(MemberDeclsNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(IdentifierNode n)
        {
            PrintDOTIDLabel(n, n.Token.Lexeme);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(InheritListNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncDefNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(TypeNode n)
        {
            PrintDOTIDLabel(n, n.Token.TokenType.ToString());
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncParamListNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(ArrayDimListNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(ArrayDimNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(IntNumNode n)
        {
            PrintDOTIDLabel(n, n.Value.ToString());
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(LocalScopeNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncBodyNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(StatementsNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(VarDeclNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(IfNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(BoolExpressionNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(CompareOpNode n)
        {
            PrintDOTIDLabel(n, n.CompareOpType.ToString());
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void Visit(WhileNode n)
        {
            PrintDOTIDLabel(n);
            PrintDOTParentChild(n);
            foreach (var child in n.GetChildren())
            {
                child.Accept(this);
            }
        }
    }
}
