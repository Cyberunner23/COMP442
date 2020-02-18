namespace Parser.ASTVisitor
{
    interface IVisitableNode
    {
        void Accept(IVisitor v);
    }
}
