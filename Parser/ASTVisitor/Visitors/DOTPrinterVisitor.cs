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
    }
}
