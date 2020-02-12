using Lexer;
using System.Collections.Generic;

namespace Parser
{
    public class Parser
    {

        private bool Program()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.Main, 
                TokenType.Class, 
                TokenType.Identifier 
            };

            List<TokenType> followSet = new List<TokenType>();



            return false;
        }

        private bool ClassDecls()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool FuncDefs()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool MemberDecls()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool MemberDecl()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool FuncOrVarDecl()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool Visibility()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool StatementBlock()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool StatementVarOrFuncCall()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool StatementVar()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool VarExt()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool FuncCallExt()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool AssignStatementOrFuncCall()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool OptionalInherits()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool BoolExpr()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool FuncDecl()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool LocalScope()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool BoolExprOrNone()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool Statement()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool Statements()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool AddOp()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool RightArithExpr()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool FuncSigNamespace()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool FuncParams()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool FuncParamsRest()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool InheritedClasses()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool CompareOp()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool ArrayDims()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool VarDecls()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool Sign()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool ArithExpr()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool Indices()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool FactorVar()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool FactorFuncCall()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool VarOrFuncCall()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool MultOp()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool Factor()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool RightTerm()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool TypeOrVoid()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool Type()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool TypeNoID()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool OptionalInt()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool FuncCallParams()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool Expression()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }

        private bool FuncParamRest()
        {
            List<TokenType> firstSet = new List<TokenType>() { };
            List<TokenType> followSet = new List<TokenType>() { };
            return false;
        }
    }
}
