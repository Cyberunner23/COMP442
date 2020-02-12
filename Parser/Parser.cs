using Lexer;
using System.Collections.Generic;

namespace Parser
{
    public class Parser
    {

        private bool Start()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Main, TokenType.Class, TokenType.Identifier };
            List<TokenType> followSet = new List<TokenType>();



            return false;
        }

        private bool Program()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Main, TokenType.Class, TokenType.Identifier };
            List<TokenType> followSet = new List<TokenType>();



            return false;
        }

        private bool ClassDecls()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Class };
            List<TokenType> followSet = new List<TokenType>() { TokenType.Identifier, TokenType.Main };
            return false;
        }

        private bool FuncDefs()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Identifier };
            List<TokenType> followSet = new List<TokenType>() { TokenType.Main };
            return false;
        }

        private bool MemberDecls()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Public, TokenType.Private };
            List<TokenType> followSet = new List<TokenType>() { TokenType.CloseCurlyBrace };
            return false;
        }

        private bool MemberDecl()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Identifier, TokenType.Integer, TokenType.Float };
            List<TokenType> followSet = new List<TokenType>() { TokenType.Public, TokenType.Private, TokenType.CloseCurlyBrace };
            return false;
        }

        private bool FuncOrVarDecl()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Identifier, TokenType.OpenBrace };
            List<TokenType> followSet = new List<TokenType>() { TokenType.Public, TokenType.Private, TokenType.CloseCurlyBrace };
            return false;
        }

        private bool Visibility()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Public, TokenType.Private };
            List<TokenType> followSet = new List<TokenType>() { TokenType.Identifier, TokenType.Integer, TokenType.Float };
            return false;
        }

        private bool StatementBlock()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.Do,
                TokenType.If,
                TokenType.While,
                TokenType.Read,
                TokenType.Write,
                TokenType.Return,
                TokenType.Identifier
            };
            List<TokenType> followSet = new List<TokenType>() { TokenType.Else, TokenType.SemiColon };
            return false;
        }

        private bool StatementVarOrFuncCall()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            { 
                TokenType.OpenBrace,
                TokenType.OpenSquareBrace,
                TokenType.Identifier,
                TokenType.Period
            };
            List<TokenType> followSet = new List<TokenType>() { TokenType.CloseBrace };
            return false;
        }

        private bool StatementVar()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Identifier, TokenType.Period };
            List<TokenType> followSet = new List<TokenType>() { TokenType.CloseBrace };
            return false;
        }

        private bool VarOrFuncCallExt()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.OpenBrace,
                TokenType.OpenSquareBrace,
                TokenType.Equal,
                TokenType.Period
            };
            List<TokenType> followSet = new List<TokenType>()
            {
                TokenType.If,
                TokenType.While,
                TokenType.Read,
                TokenType.Write,
                TokenType.Return,
                TokenType.Identifier,
                TokenType.Else,
                TokenType.SemiColon,
                TokenType.End
            };
            return false;
        }

        private bool VarExt()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Equal, TokenType.Period };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.If,
                TokenType.While,
                TokenType.Read,
                TokenType.Write,
                TokenType.Return,
                TokenType.Identifier,
                TokenType.Else,
                TokenType.SemiColon,
                TokenType.End
            };
            return false;
        }

        private bool FuncCallExt()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.SemiColon, TokenType.Period };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.If,
                TokenType.While,
                TokenType.Read,
                TokenType.Write,
                TokenType.Return,
                TokenType.Identifier,
                TokenType.Else,
                TokenType.SemiColon,
                TokenType.End
            };
            return false;
        }

        private bool AssignStatementOrFuncCall()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Identifier };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.If,
                TokenType.While,
                TokenType.Read,
                TokenType.Write,
                TokenType.Return,
                TokenType.Identifier,
                TokenType.Else,
                TokenType.SemiColon,
                TokenType.End
            };
            return false;
        }

        private bool OptionalInherits()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Inherits };
            List<TokenType> followSet = new List<TokenType>() { TokenType.OpenBrace };
            return false;
        }

        private bool BoolExpr()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.Identifier,
                TokenType.IntNum,
                TokenType.FloatNum,
                TokenType.OpenBrace,
                TokenType.Not,
                TokenType.Plus,
                TokenType.Minus
            };
            List<TokenType> followSet = new List<TokenType>() { TokenType.CloseBrace };
            return false;
        }

        private bool FuncDecl()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.OpenBrace };
            List<TokenType> followSet = new List<TokenType>() 
            { 
                TokenType.Public, 
                TokenType.Private,
                TokenType.CloseCurlyBrace
            };
            return false;
        }

        private bool LocalScope()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Local };
            List<TokenType> followSet = new List<TokenType>() { TokenType.Do };
            return false;
        }

        private bool BoolExprOrNone()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.Equal,
                TokenType.LesserGreater,
                TokenType.Lesser,
                TokenType.Greater,
                TokenType.LesserEqual,
                TokenType.GreaterEqual
            };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.CloseBrace,
                TokenType.SemiColon,
                TokenType.Comma
            };
            return false;
        }

        private bool Statement()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.If,
                TokenType.While,
                TokenType.Read,
                TokenType.Write,
                TokenType.Return,
                TokenType.Identifier
            };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.If,
                TokenType.While,
                TokenType.Read,
                TokenType.Write,
                TokenType.Return,
                TokenType.Identifier,
                TokenType.Else,
                TokenType.SemiColon,
                TokenType.End
            };
            return false;
        }

        private bool Statements()
        {
            List<TokenType> firstSet = new List<TokenType>()
            {
                TokenType.If,
                TokenType.While,
                TokenType.Read,
                TokenType.Write,
                TokenType.Return,
                TokenType.Identifier
            };
            List<TokenType> followSet = new List<TokenType>() { TokenType.End };
            return false;
        }

        private bool AddOp()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.Plus,
                TokenType.Minus,
                TokenType.Or
            };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.Identifier,
                TokenType.IntNum,
                TokenType.FloatNum,
                TokenType.OpenBrace,
                TokenType.Not,
                TokenType.Plus,
                TokenType.Minus
            };
            return false;
        }

        private bool RightArithExpr()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.Plus,
                TokenType.Minus,
                TokenType.Or
            };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.Equal,
                TokenType.LesserGreater,
                TokenType.Lesser,
                TokenType.Greater,
                TokenType.LesserEqual,
                TokenType.GreaterEqual,
                TokenType.CloseSquareBrace,
                TokenType.SemiColon,
                TokenType.Comma,
                TokenType.CloseBrace
            };
            return false;
        }

        private bool FuncSigNamespace()
        {
            
            List<TokenType> firstSet = new List<TokenType>() { TokenType.OpenBrace, TokenType.ColonColon };
            List<TokenType> followSet = new List<TokenType>() { TokenType.Local, TokenType.Do };
            return false;
        }

        private bool FuncParams()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Identifier, TokenType.Integer, TokenType.Float };
            List<TokenType> followSet = new List<TokenType>() { TokenType.CloseBrace };
            return false;
        }

        private bool FuncParamsRest()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Comma };
            List<TokenType> followSet = new List<TokenType>() { TokenType.CloseBrace };
            return false;
        }

        private bool InheritedClasses()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Comma };
            List<TokenType> followSet = new List<TokenType>() { TokenType.OpenCurlyBrace };
            return false;
        }

        private bool CompareOp()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            { 
                TokenType.Equal,
                TokenType.LesserGreater,
                TokenType.Lesser,
                TokenType.Greater,
                TokenType.LesserEqual,
                TokenType.GreaterEqual
            };
            List<TokenType> followSet = new List<TokenType>() 
            { 
                TokenType.Identifier,
                TokenType.IntNum,
                TokenType.FloatNum,
                TokenType.OpenBrace,
                TokenType.Not,
                TokenType.Plus,
                TokenType.Minus
            };
            return false;
        }

        private bool ArrayDims()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.OpenSquareBrace };
            List<TokenType> followSet = new List<TokenType>() 
            { 
                TokenType.CloseBrace,
                TokenType.Comma,
                TokenType.SemiColon
            };
            return false;
        }

        private bool VarDecls()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Identifier };
            List<TokenType> followSet = new List<TokenType>() { TokenType.Do };
            return false;
        }

        private bool Sign()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Plus, TokenType.Minus };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.Identifier,
                TokenType.IntNum,
                TokenType.FloatNum,
                TokenType.OpenBrace,
                TokenType.Not,
                TokenType.Plus,
                TokenType.Minus
            };
            return false;
        }

        private bool ArithExpr()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.Identifier,
                TokenType.IntNum,
                TokenType.FloatNum,
                TokenType.OpenBrace,
                TokenType.Not,
                TokenType.Plus,
                TokenType.Minus
            };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.Equal,
                TokenType.LesserGreater,
                TokenType.Lesser,
                TokenType.Greater,
                TokenType.LesserEqual,
                TokenType.GreaterEqual,
                TokenType.CloseSquareBrace,
                TokenType.SemiColon,
                TokenType.Comma,
                TokenType.CloseBrace
            };
            return false;
        }

        private bool Indices()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.OpenSquareBrace };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.Plus,
                TokenType.Minus,
                TokenType.Or,
                TokenType.Asterix,
                TokenType.FwdSlash,
                TokenType.And,
                TokenType.LesserGreater,
                TokenType.Lesser,
                TokenType.Greater,
                TokenType.LesserEqual,
                TokenType.GreaterEqual,
                TokenType.CloseSquareBrace,
                TokenType.Identifier,
                TokenType.Equal,
                TokenType.Period,
                TokenType.SemiColon,
                TokenType.Comma,
                TokenType.CloseBrace
            };
            return false;
        }

        private bool FactorVar()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Period };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.Plus,
                TokenType.Minus,
                TokenType.Or,
                TokenType.Asterix,
                TokenType.FwdSlash,
                TokenType.And,
                TokenType.Equal,
                TokenType.LesserGreater,
                TokenType.Lesser,
                TokenType.Greater,
                TokenType.LesserEqual,
                TokenType.GreaterEqual,
                TokenType.CloseSquareBrace,
                TokenType.SemiColon,
                TokenType.Comma,
                TokenType.CloseBrace
            };
            return false;
        }

        private bool FactorFuncCall()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Period };
            List<TokenType> followSet = new List<TokenType>() {
                TokenType.Plus,
                TokenType.Minus,
                TokenType.Or,
                TokenType.Asterix,
                TokenType.FwdSlash,
                TokenType.And,
                TokenType.Equal,
                TokenType.LesserGreater,
                TokenType.Lesser,
                TokenType.Greater,
                TokenType.LesserEqual,
                TokenType.GreaterEqual,
                TokenType.CloseSquareBrace,
                TokenType.SemiColon,
                TokenType.Comma,
                TokenType.CloseBrace
            };
            return false;
        }

        private bool VarOrFuncCall()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.OpenBrace,
                TokenType.OpenSquareBrace,
                TokenType.Period
            };
            List<TokenType> followSet = new List<TokenType>() {
                TokenType.Plus,
                TokenType.Minus,
                TokenType.Or,
                TokenType.Asterix,
                TokenType.FwdSlash,
                TokenType.And,
                TokenType.Equal,
                TokenType.LesserGreater,
                TokenType.Lesser,
                TokenType.Greater,
                TokenType.LesserEqual,
                TokenType.GreaterEqual,
                TokenType.CloseSquareBrace,
                TokenType.SemiColon,
                TokenType.Comma,
                TokenType.CloseBrace
            };
            return false;
        }

        private bool MultOp()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.Asterix,
                TokenType.FwdSlash,
                TokenType.And
            };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.Identifier,
                TokenType.IntNum,
                TokenType.FloatNum,
                TokenType.OpenBrace,
                TokenType.Not,
                TokenType.Plus,
                TokenType.Minus
            };
            return false;
        }

        private bool Factor()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.Identifier,
                TokenType.IntNum,
                TokenType.FloatNum,
                TokenType.OpenBrace,
                TokenType.Not,
                TokenType.Plus,
                TokenType.Minus
            };
            List<TokenType> followSet = new List<TokenType>() {
                TokenType.Plus,
                TokenType.Minus,
                TokenType.Or,
                TokenType.Asterix,
                TokenType.FwdSlash,
                TokenType.And,
                TokenType.Equal,
                TokenType.LesserGreater,
                TokenType.Lesser,
                TokenType.Greater,
                TokenType.LesserEqual,
                TokenType.GreaterEqual,
                TokenType.CloseSquareBrace,
                TokenType.SemiColon,
                TokenType.Comma,
                TokenType.CloseBrace
            };
            return false;
        }

        private bool RightTerm()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.Asterix,
                TokenType.FwdSlash,
                TokenType.And
            };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.Plus,
                TokenType.Minus,
                TokenType.Or,
                TokenType.Equal,
                TokenType.LesserGreater,
                TokenType.Lesser,
                TokenType.Greater,
                TokenType.LesserEqual,
                TokenType.GreaterEqual,
                TokenType.CloseSquareBrace,
                TokenType.SemiColon,
                TokenType.Comma,
                TokenType.CloseBrace
            };
            return false;
        }

        private bool TypeOrVoid()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.Void,
                TokenType.Identifier,
                TokenType.Integer,
                TokenType.Float,
            };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.SemiColon,
                TokenType.Local,
                TokenType.Do
            };
            return false;
        }

        private bool Type()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.Identifier,
                TokenType.Integer,
                TokenType.Float
            };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.SemiColon,
                TokenType.Identifier,
                TokenType.Local,
                TokenType.Do
            };
            return false;
        }

        private bool TypeNoID()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Integer, TokenType.Float };
            List<TokenType> followSet = new List<TokenType>()
            {
                TokenType.SemiColon,
                TokenType.Identifier,
                TokenType.Local,
                TokenType.Do
            };
            return false;
        }

        private bool OptionalInt()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.IntNum };
            List<TokenType> followSet = new List<TokenType>() { TokenType.CloseSquareBrace };
            return false;
        }

        private bool FuncCallParams()
        {
            List<TokenType> firstSet = new List<TokenType>() 
            {
                TokenType.Identifier,
                TokenType.IntNum,
                TokenType.FloatNum,
                TokenType.OpenBrace,
                TokenType.Not,
                TokenType.Plus,
                TokenType.Minus
            };
            List<TokenType> followSet = new List<TokenType>() { TokenType.CloseBrace };
            return false;
        }

        private bool Expression()
        {
            List<TokenType> firstSet = new List<TokenType>()
            {
                TokenType.Identifier,
                TokenType.IntNum,
                TokenType.FloatNum,
                TokenType.OpenBrace,
                TokenType.Not,
                TokenType.Plus,
                TokenType.Minus
            };
            List<TokenType> followSet = new List<TokenType>() 
            {
                TokenType.CloseBrace,
                TokenType.SemiColon,
                TokenType.Comma
            };
            return false;
        }

        private bool FuncParamRest()
        {
            List<TokenType> firstSet = new List<TokenType>() { TokenType.Comma };
            List<TokenType> followSet = new List<TokenType>() { TokenType.CloseBrace };
            return false;
        }
    }
}
