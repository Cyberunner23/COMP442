using Lexer;
using System.Collections.Generic;

namespace Parser.Grammar
{
    class GrammarFactory
    {
        public static Dictionary<NonTerminal, GrammarRule> CreateGrammar()
        {
            var grammar = new Dictionary<NonTerminal, GrammarRule>();

            #region Terminal Rules

            var IntNum = new GrammarRule(NonTerminal.IntNum, false, true);
            var FloatNum = new GrammarRule(NonTerminal.FloatNum, false, true);
            var Integer = new GrammarRule(NonTerminal.Integer, false, true);
            var Float = new GrammarRule(NonTerminal.Float, false, true);
            var Identifier = new GrammarRule(NonTerminal.Identifier, false, true);
            var Void = new GrammarRule(NonTerminal.Void, false, true);
            var And = new GrammarRule(NonTerminal.And, false, true);
            var FwdSlash = new GrammarRule(NonTerminal.FwdSlash, false, true);
            var Asterix = new GrammarRule(NonTerminal.Asterix, false, true);
            var Period = new GrammarRule(NonTerminal.Period, false, true);
            var OpenSquareBrace = new GrammarRule(NonTerminal.OpenSquareBrace, false, true);
            var CloseSquareBrace = new GrammarRule(NonTerminal.CloseSquareBrace, false, true);
            var OpenBrace = new GrammarRule(NonTerminal.OpenBrace, false, true);
            var CloseBrace = new GrammarRule(NonTerminal.CloseBrace, false, true);
            var Not = new GrammarRule(NonTerminal.Not, false, true);
            var Plus = new GrammarRule(NonTerminal.Plus, false, true);
            var Minus = new GrammarRule(NonTerminal.Minus, false, true);
            var SemiColon = new GrammarRule(NonTerminal.SemiColon, false, true);
            var Equal = new GrammarRule(NonTerminal.Equal, false, true);
            var LesserGreater = new GrammarRule(NonTerminal.LesserGreater, false, true);
            var Lesser = new GrammarRule(NonTerminal.Lesser, false, true);
            var Greater = new GrammarRule(NonTerminal.Greater, false, true);
            var LesserEqual = new GrammarRule(NonTerminal.LesserEqual, false, true);
            var GreaterEqual = new GrammarRule(NonTerminal.GreaterEqual, false, true);
            var Comma = new GrammarRule(NonTerminal.Comma, false, true);
            var ColonColon = new GrammarRule(NonTerminal.ColonColon, false, true);
            var Colon = new GrammarRule(NonTerminal.Colon, false, true);
            var Local = new GrammarRule(NonTerminal.Local, false, true);
            var Inherits = new GrammarRule(NonTerminal.Inherits, false, true);
            var Or = new GrammarRule(NonTerminal.Or, false, true);
            var Do = new GrammarRule(NonTerminal.Do, false, true);
            var End = new GrammarRule(NonTerminal.End, false, true);
            var Public = new GrammarRule(NonTerminal.Public, false, true);
            var Private = new GrammarRule(NonTerminal.Private, false, true);
            var Main = new GrammarRule(NonTerminal.Main, false, true);
            var If = new GrammarRule(NonTerminal.If, false, true);
            var Then = new GrammarRule(NonTerminal.Then, false, true);
            var Else = new GrammarRule(NonTerminal.Else, false, true);
            var While = new GrammarRule(NonTerminal.While, false, true);
            var Read = new GrammarRule(NonTerminal.Read, false, true);
            var Write = new GrammarRule(NonTerminal.Write, false, true);
            var Return = new GrammarRule(NonTerminal.Return, false, true);
            var Class = new GrammarRule(NonTerminal.Class, false, true);
            var OpenCurlyBrace = new GrammarRule(NonTerminal.OpenCurlyBrace, false, true);
            var CloseCurlyBrace = new GrammarRule(NonTerminal.CloseCurlyBrace, false, true);
            var EqualEqual = new GrammarRule(NonTerminal.EqualEqual, false, true);

            grammar.Add(NonTerminal.IntNum, IntNum);
            grammar.Add(NonTerminal.FloatNum, FloatNum);
            grammar.Add(NonTerminal.Integer, Integer);
            grammar.Add(NonTerminal.Float, Float);
            grammar.Add(NonTerminal.Identifier, Identifier);
            grammar.Add(NonTerminal.Void, Void);
            grammar.Add(NonTerminal.And, And);
            grammar.Add(NonTerminal.FwdSlash, FwdSlash);
            grammar.Add(NonTerminal.Asterix, Asterix);
            grammar.Add(NonTerminal.Period, Period);
            grammar.Add(NonTerminal.OpenSquareBrace, OpenSquareBrace);
            grammar.Add(NonTerminal.CloseSquareBrace, CloseSquareBrace);
            grammar.Add(NonTerminal.OpenBrace, OpenBrace);
            grammar.Add(NonTerminal.CloseBrace, CloseBrace);
            grammar.Add(NonTerminal.Not, Not);
            grammar.Add(NonTerminal.Plus, Plus);
            grammar.Add(NonTerminal.Minus, Minus);
            grammar.Add(NonTerminal.SemiColon, SemiColon);
            grammar.Add(NonTerminal.Equal, Equal);
            grammar.Add(NonTerminal.LesserGreater, LesserGreater);
            grammar.Add(NonTerminal.Lesser, Lesser);
            grammar.Add(NonTerminal.Greater, Greater);
            grammar.Add(NonTerminal.LesserEqual, LesserEqual);
            grammar.Add(NonTerminal.GreaterEqual, GreaterEqual);
            grammar.Add(NonTerminal.Comma, Comma);
            grammar.Add(NonTerminal.ColonColon, ColonColon);
            grammar.Add(NonTerminal.Colon, Colon);
            grammar.Add(NonTerminal.Local, Local);
            grammar.Add(NonTerminal.Inherits, Inherits);
            grammar.Add(NonTerminal.Or, Or);
            grammar.Add(NonTerminal.Do, Do);
            grammar.Add(NonTerminal.End, End);
            grammar.Add(NonTerminal.Public, Public);
            grammar.Add(NonTerminal.Private, Private);
            grammar.Add(NonTerminal.Main, Main);
            grammar.Add(NonTerminal.If, If);
            grammar.Add(NonTerminal.Then, Then);
            grammar.Add(NonTerminal.Else, Else);
            grammar.Add(NonTerminal.While, While);
            grammar.Add(NonTerminal.Read, Read);
            grammar.Add(NonTerminal.Write, Write);
            grammar.Add(NonTerminal.Return, Return);
            grammar.Add(NonTerminal.Class, Class);
            grammar.Add(NonTerminal.OpenCurlyBrace, OpenCurlyBrace);
            grammar.Add(NonTerminal.CloseCurlyBrace, CloseCurlyBrace);
            grammar.Add(NonTerminal.EqualEqual, EqualEqual);

            IntNum.FirstSet.Add(TokenType.IntNum);
            FloatNum.FirstSet.Add(TokenType.FloatNum);
            Integer.FirstSet.Add(TokenType.Integer);
            Float.FirstSet.Add(TokenType.Float);
            Identifier.FirstSet.Add(TokenType.Identifier);
            Void.FirstSet.Add(TokenType.Void);
            And.FirstSet.Add(TokenType.And);
            FwdSlash.FirstSet.Add(TokenType.FwdSlash);
            Asterix.FirstSet.Add(TokenType.Asterix);
            Period.FirstSet.Add(TokenType.Period);
            OpenSquareBrace.FirstSet.Add(TokenType.OpenSquareBrace);
            CloseSquareBrace.FirstSet.Add(TokenType.CloseSquareBrace);
            OpenBrace.FirstSet.Add(TokenType.OpenBrace);
            CloseBrace.FirstSet.Add(TokenType.CloseBrace);
            Not.FirstSet.Add(TokenType.Not);
            Plus.FirstSet.Add(TokenType.Plus);
            Minus.FirstSet.Add(TokenType.Minus);
            SemiColon.FirstSet.Add(TokenType.SemiColon);
            Equal.FirstSet.Add(TokenType.Equal);
            LesserGreater.FirstSet.Add(TokenType.LesserGreater);
            Lesser.FirstSet.Add(TokenType.Lesser);
            Greater.FirstSet.Add(TokenType.Greater);
            LesserEqual.FirstSet.Add(TokenType.LesserEqual);
            GreaterEqual.FirstSet.Add(TokenType.GreaterEqual);
            Comma.FirstSet.Add(TokenType.Comma);
            ColonColon.FirstSet.Add(TokenType.ColonColon);
            Colon.FirstSet.Add(TokenType.Colon);
            Local.FirstSet.Add(TokenType.Local);
            Inherits.FirstSet.Add(TokenType.Inherits);
            Or.FirstSet.Add(TokenType.Or);
            Do.FirstSet.Add(TokenType.Do);
            End.FirstSet.Add(TokenType.End);
            Public.FirstSet.Add(TokenType.Public);
            Private.FirstSet.Add(TokenType.Private);
            Main.FirstSet.Add(TokenType.Main);
            If.FirstSet.Add(TokenType.If);
            Then.FirstSet.Add(TokenType.Then);
            Else.FirstSet.Add(TokenType.Else);
            While.FirstSet.Add(TokenType.While);
            Read.FirstSet.Add(TokenType.Read);
            Write.FirstSet.Add(TokenType.Write);
            Return.FirstSet.Add(TokenType.Return);
            Class.FirstSet.Add(TokenType.Class);
            OpenCurlyBrace.FirstSet.Add(TokenType.OpenCurlyBrace);
            CloseCurlyBrace.FirstSet.Add(TokenType.CloseCurlyBrace);
            EqualEqual.FirstSet.Add(TokenType.EqualEqual);

            #endregion Terminals

            #region NonTerminals

            var Start = new GrammarRule(NonTerminal.Start);
            var Program = new GrammarRule(NonTerminal.Program);
            var ClassDecls = new GrammarRule(NonTerminal.ClassDecls, true);
            var ClassDecl = new GrammarRule(NonTerminal.ClassDecl);
            var FuncDefs = new GrammarRule(NonTerminal.FuncDefs, true);
            var FuncDef = new GrammarRule(NonTerminal.FuncDef);
            var MemberDecls = new GrammarRule(NonTerminal.MemberDecls, true);
            var MemberDecl = new GrammarRule(NonTerminal.MemberDecl);
            var FuncOrVarDecl = new GrammarRule(NonTerminal.FuncOrVarDecl);
            var Visibility = new GrammarRule(NonTerminal.Visibility);
            var Statement = new GrammarRule(NonTerminal.Statement);
            var StatementVar = new GrammarRule(NonTerminal.StatementVar);
            var StatementVarOrFuncCall = new GrammarRule(NonTerminal.StatementVarOrFuncCall, true);
            var StatementVarExt = new GrammarRule(NonTerminal.StatementVarExt, true);
            var StatementFunctionCall = new GrammarRule(NonTerminal.StatementFunctionCall);
            var AssignStatementOrFuncCall = new GrammarRule(NonTerminal.AssignStatementOrFuncCall);
            var VarOrFuncCallExt = new GrammarRule(NonTerminal.VarOrFuncCallExt, true);
            var VarExt = new GrammarRule(NonTerminal.VarExt);
            var FuncCallExt = new GrammarRule(NonTerminal.FuncCallExt);
            var FuncParams = new GrammarRule(NonTerminal.FuncParams, true);
            var AddOp = new GrammarRule(NonTerminal.AddOp);
            var OptionalInherits = new GrammarRule(NonTerminal.OptionalInherits, true);
            var BoolExpr = new GrammarRule(NonTerminal.BoolExpr);
            var FuncDecl = new GrammarRule(NonTerminal.FuncDecl);
            var FuncCallParamsRests = new GrammarRule(NonTerminal.FuncCallParamsRests);
            var LocalScope = new GrammarRule(NonTerminal.LocalScope, true);
            var ArrayDims = new GrammarRule(NonTerminal.ArrayDims, true);
            var Expression = new GrammarRule(NonTerminal.Expression);
            var BoolExprOrNone = new GrammarRule(NonTerminal.BoolExprOrNone, true);
            var Statements = new GrammarRule(NonTerminal.Statements, true);
            var ArithExpr = new GrammarRule(NonTerminal.ArithExpr);
            var RightArithExpr = new GrammarRule(NonTerminal.RightArithExpr, true);
            var FuncSig = new GrammarRule(NonTerminal.FuncSig);
            var FuncSigNamespace = new GrammarRule(NonTerminal.FuncSigNamespace);
            var FuncSigExt = new GrammarRule(NonTerminal.FuncSigExt);
            var FuncParamsRests = new GrammarRule(NonTerminal.FuncParamsRests, true);
            var InheritedClasses = new GrammarRule(NonTerminal.InheritedClasses, true);
            var Sign = new GrammarRule(NonTerminal.Sign);
            var CompareOp = new GrammarRule(NonTerminal.CompareOp);
            var Index = new GrammarRule(NonTerminal.Index);
            var VarDecls = new GrammarRule(NonTerminal.VarDecls, true);
            var Factor = new GrammarRule(NonTerminal.Factor);
            var VarFuncCall = new GrammarRule(NonTerminal.VarFuncCall);
            var VarOrFuncCall = new GrammarRule(NonTerminal.VarOrFuncCall);
            var FactorVar = new GrammarRule(NonTerminal.FactorVar, true);
            var FactorFuncCall = new GrammarRule(NonTerminal.FactorFuncCall, true);
            var Term = new GrammarRule(NonTerminal.Term);
            var MultOp = new GrammarRule(NonTerminal.MultOp);
            var RightTerm = new GrammarRule(NonTerminal.RightTerm, true);
            var TypeOrVoid = new GrammarRule(NonTerminal.TypeOrVoid);
            var Type = new GrammarRule(NonTerminal.Type);
            var TypeNoID = new GrammarRule(NonTerminal.TypeNoID);
            var ArraySize = new GrammarRule(NonTerminal.ArraySize);
            var OptionalInt = new GrammarRule(NonTerminal.OptionalInt, true);
            var FuncCallParamsRest = new GrammarRule(NonTerminal.FuncCallParamsRest, true);
            var FuncCallParams = new GrammarRule(NonTerminal.FuncCallParams, true);
            var VarDecl = new GrammarRule(NonTerminal.VarDecl);
            var FuncBody = new GrammarRule(NonTerminal.FuncBody);
            var StatementBlock = new GrammarRule(NonTerminal.StatementBlock, true);
            var FuncParamsRest = new GrammarRule(NonTerminal.FuncParamsRest);
            var Indices = new GrammarRule(NonTerminal.Indices, true);

            grammar.Add(NonTerminal.Start, Start);
            grammar.Add(NonTerminal.Program, Program);
            grammar.Add(NonTerminal.ClassDecls, ClassDecls);
            grammar.Add(NonTerminal.ClassDecl, ClassDecl);
            grammar.Add(NonTerminal.FuncDefs, FuncDefs);
            grammar.Add(NonTerminal.FuncDef, FuncDef);
            grammar.Add(NonTerminal.MemberDecls, MemberDecls);
            grammar.Add(NonTerminal.MemberDecl, MemberDecl);
            grammar.Add(NonTerminal.FuncOrVarDecl, FuncOrVarDecl);
            grammar.Add(NonTerminal.Visibility, Visibility);
            grammar.Add(NonTerminal.Statement, Statement);
            grammar.Add(NonTerminal.StatementVar, StatementVar);
            grammar.Add(NonTerminal.StatementVarOrFuncCall, StatementVarOrFuncCall);
            grammar.Add(NonTerminal.StatementVarExt, StatementVarExt);
            grammar.Add(NonTerminal.StatementFunctionCall, StatementFunctionCall);
            grammar.Add(NonTerminal.AssignStatementOrFuncCall, AssignStatementOrFuncCall);
            grammar.Add(NonTerminal.VarOrFuncCallExt, VarOrFuncCallExt);
            grammar.Add(NonTerminal.VarExt, VarExt);
            grammar.Add(NonTerminal.FuncCallExt, FuncCallExt);
            grammar.Add(NonTerminal.FuncParams, FuncParams);
            grammar.Add(NonTerminal.AddOp, AddOp);
            grammar.Add(NonTerminal.OptionalInherits, OptionalInherits);
            grammar.Add(NonTerminal.BoolExpr, BoolExpr);
            grammar.Add(NonTerminal.FuncDecl, FuncDecl);
            grammar.Add(NonTerminal.FuncCallParamsRests, FuncCallParamsRests);
            grammar.Add(NonTerminal.LocalScope, LocalScope);
            grammar.Add(NonTerminal.ArrayDims, ArrayDims);
            grammar.Add(NonTerminal.Expression, Expression);
            grammar.Add(NonTerminal.BoolExprOrNone, BoolExprOrNone);
            grammar.Add(NonTerminal.Statements, Statements);
            grammar.Add(NonTerminal.ArithExpr, ArithExpr);
            grammar.Add(NonTerminal.RightArithExpr, RightArithExpr);
            grammar.Add(NonTerminal.FuncSig, FuncSig);
            grammar.Add(NonTerminal.FuncSigNamespace, FuncSigNamespace);
            grammar.Add(NonTerminal.FuncSigExt, FuncSigExt);
            grammar.Add(NonTerminal.FuncParamsRests, FuncParamsRests);
            grammar.Add(NonTerminal.InheritedClasses, InheritedClasses);
            grammar.Add(NonTerminal.Sign, Sign);
            grammar.Add(NonTerminal.CompareOp, CompareOp);
            grammar.Add(NonTerminal.Index, Index);
            grammar.Add(NonTerminal.VarDecls, VarDecls);
            grammar.Add(NonTerminal.Factor, Factor);
            grammar.Add(NonTerminal.VarFuncCall, VarFuncCall);
            grammar.Add(NonTerminal.VarOrFuncCall, VarOrFuncCall);
            grammar.Add(NonTerminal.FactorVar, FactorVar);
            grammar.Add(NonTerminal.FactorFuncCall, FactorFuncCall);
            grammar.Add(NonTerminal.Term, Term);
            grammar.Add(NonTerminal.MultOp, MultOp);
            grammar.Add(NonTerminal.RightTerm, RightTerm);
            grammar.Add(NonTerminal.TypeOrVoid, TypeOrVoid);
            grammar.Add(NonTerminal.Type, Type);
            grammar.Add(NonTerminal.TypeNoID, TypeNoID);
            grammar.Add(NonTerminal.ArraySize, ArraySize);
            grammar.Add(NonTerminal.OptionalInt, OptionalInt);
            grammar.Add(NonTerminal.FuncCallParamsRest, FuncCallParamsRest);
            grammar.Add(NonTerminal.FuncCallParams, FuncCallParams);
            grammar.Add(NonTerminal.VarDecl, VarDecl);
            grammar.Add(NonTerminal.FuncBody, FuncBody);
            grammar.Add(NonTerminal.StatementBlock, StatementBlock);
            grammar.Add(NonTerminal.FuncParamsRest, FuncParamsRest);
            grammar.Add(NonTerminal.Indices, Indices);

            Start.FirstSet.Add(TokenType.Main);
            Start.FirstSet.Add(TokenType.Class);
            Start.FirstSet.Add(TokenType.Identifier);

            Program.FirstSet.Add(TokenType.Main);
            Program.FirstSet.Add(TokenType.Class);
            Program.FirstSet.Add(TokenType.Identifier);

            ClassDecls.FirstSet.Add(TokenType.Class);
            ClassDecls.FollowSet.Add(TokenType.Identifier);
            ClassDecls.FollowSet.Add(TokenType.Main);

            ClassDecl.FirstSet.Add(TokenType.Class);

            FuncDefs.FirstSet.Add(TokenType.Identifier);
            FuncDefs.FollowSet.Add(TokenType.Main);

            FuncDef.FirstSet.Add(TokenType.Identifier);

            MemberDecls.FirstSet.Add(TokenType.Public);
            MemberDecls.FirstSet.Add(TokenType.Private);
            MemberDecls.FollowSet.Add(TokenType.CloseCurlyBrace);

            MemberDecl.FirstSet.Add(TokenType.Identifier);
            MemberDecl.FirstSet.Add(TokenType.Integer);
            MemberDecl.FirstSet.Add(TokenType.Float);

            FuncOrVarDecl.FirstSet.Add(TokenType.OpenBrace);
            FuncOrVarDecl.FirstSet.Add(TokenType.Identifier);

            Visibility.FirstSet.Add(TokenType.Public);
            Visibility.FirstSet.Add(TokenType.Private);

            StatementVarOrFuncCall.FirstSet.Add(TokenType.OpenBrace);
            StatementVarOrFuncCall.FirstSet.Add(TokenType.Period);
            StatementVarOrFuncCall.FirstSet.Add(TokenType.OpenSquareBrace);
            StatementVarOrFuncCall.FollowSet.Add(TokenType.CloseCurlyBrace);

            StatementVarExt.FirstSet.Add(TokenType.Period);
            StatementVarExt.FollowSet.Add(TokenType.CloseCurlyBrace);

            StatementFunctionCall.FirstSet.Add(TokenType.Period);

            StatementVar.FirstSet.Add(TokenType.Identifier);

            VarOrFuncCallExt.FirstSet.Add(TokenType.OpenBrace);
            VarOrFuncCallExt.FirstSet.Add(TokenType.Equal);
            VarOrFuncCallExt.FirstSet.Add(TokenType.Period);
            VarOrFuncCallExt.FirstSet.Add(TokenType.OpenSquareBrace);

            VarExt.FirstSet.Add(TokenType.Equal);
            VarExt.FirstSet.Add(TokenType.Period);

            FuncCallExt.FirstSet.Add(TokenType.SemiColon);
            FuncCallExt.FirstSet.Add(TokenType.Period);

            AssignStatementOrFuncCall.FirstSet.Add(TokenType.Identifier);

            OptionalInherits.FirstSet.Add(TokenType.Inherits);
            OptionalInherits.FollowSet.Add(TokenType.OpenCurlyBrace);

            BoolExpr.FirstSet.Add(TokenType.IntNum);
            BoolExpr.FirstSet.Add(TokenType.FloatNum);
            BoolExpr.FirstSet.Add(TokenType.OpenBrace);
            BoolExpr.FirstSet.Add(TokenType.Not);
            BoolExpr.FirstSet.Add(TokenType.Identifier);
            BoolExpr.FirstSet.Add(TokenType.Plus);
            BoolExpr.FirstSet.Add(TokenType.Minus);

            FuncDecl.FirstSet.Add(TokenType.OpenBrace);

            BoolExprOrNone.FirstSet.Add(TokenType.EqualEqual);
            BoolExprOrNone.FirstSet.Add(TokenType.LesserGreater);
            BoolExprOrNone.FirstSet.Add(TokenType.Lesser);
            BoolExprOrNone.FirstSet.Add(TokenType.Greater);
            BoolExprOrNone.FirstSet.Add(TokenType.LesserEqual);
            BoolExprOrNone.FirstSet.Add(TokenType.GreaterEqual);
            BoolExprOrNone.FollowSet.Add(TokenType.CloseBrace);
            BoolExprOrNone.FollowSet.Add(TokenType.SemiColon);
            BoolExprOrNone.FollowSet.Add(TokenType.Comma);

            AddOp.FirstSet.Add(TokenType.Plus);
            AddOp.FirstSet.Add(TokenType.Minus);
            AddOp.FirstSet.Add(TokenType.Or);

            RightArithExpr.FirstSet.Add(TokenType.Plus);
            RightArithExpr.FirstSet.Add(TokenType.Minus);
            RightArithExpr.FirstSet.Add(TokenType.Or);
            RightArithExpr.FollowSet.Add(TokenType.EqualEqual);
            RightArithExpr.FollowSet.Add(TokenType.LesserGreater);
            RightArithExpr.FollowSet.Add(TokenType.Lesser);
            RightArithExpr.FollowSet.Add(TokenType.Greater);
            RightArithExpr.FollowSet.Add(TokenType.LesserEqual);
            RightArithExpr.FollowSet.Add(TokenType.GreaterEqual);
            RightArithExpr.FollowSet.Add(TokenType.CloseSquareBrace);
            RightArithExpr.FollowSet.Add(TokenType.SemiColon);
            RightArithExpr.FollowSet.Add(TokenType.Comma);
            RightArithExpr.FollowSet.Add(TokenType.CloseBrace);

            FuncSig.FirstSet.Add(TokenType.Identifier);

            FuncSigNamespace.FirstSet.Add(TokenType.ColonColon);
            FuncSigNamespace.FirstSet.Add(TokenType.OpenBrace);

            FuncSigExt.FirstSet.Add(TokenType.OpenBrace);

            FuncParams.FirstSet.Add(TokenType.Identifier);
            FuncParams.FirstSet.Add(TokenType.Integer);
            FuncParams.FirstSet.Add(TokenType.Float);
            FuncParams.FollowSet.Add(TokenType.CloseBrace);

            FuncParamsRests.FirstSet.Add(TokenType.Comma);
            FuncParamsRests.FollowSet.Add(TokenType.CloseBrace);

            InheritedClasses.FirstSet.Add(TokenType.Comma);
            InheritedClasses.FollowSet.Add(TokenType.OpenCurlyBrace);

            CompareOp.FirstSet.Add(TokenType.EqualEqual);
            CompareOp.FirstSet.Add(TokenType.LesserGreater);
            CompareOp.FirstSet.Add(TokenType.Lesser);
            CompareOp.FirstSet.Add(TokenType.Greater);
            CompareOp.FirstSet.Add(TokenType.LesserEqual);
            CompareOp.FirstSet.Add(TokenType.GreaterEqual);

            VarDecls.FirstSet.Add(TokenType.Identifier);
            VarDecls.FirstSet.Add(TokenType.Integer);
            VarDecls.FirstSet.Add(TokenType.Float);
            VarDecls.FollowSet.Add(TokenType.Do);

            ArithExpr.FirstSet.Add(TokenType.IntNum);
            ArithExpr.FirstSet.Add(TokenType.FloatNum);
            ArithExpr.FirstSet.Add(TokenType.OpenBrace);
            ArithExpr.FirstSet.Add(TokenType.Not);
            ArithExpr.FirstSet.Add(TokenType.Identifier);
            ArithExpr.FirstSet.Add(TokenType.Plus);
            ArithExpr.FirstSet.Add(TokenType.Minus);

            Sign.FirstSet.Add(TokenType.Plus);
            Sign.FirstSet.Add(TokenType.Minus);

            VarOrFuncCall.FirstSet.Add(TokenType.OpenBrace);
            VarOrFuncCall.FirstSet.Add(TokenType.Period);
            VarOrFuncCall.FirstSet.Add(TokenType.OpenSquareBrace);
            VarOrFuncCall.FollowSet.Add(TokenType.Asterix);
            VarOrFuncCall.FollowSet.Add(TokenType.FwdSlash);
            VarOrFuncCall.FollowSet.Add(TokenType.And);
            VarOrFuncCall.FollowSet.Add(TokenType.Plus);
            VarOrFuncCall.FollowSet.Add(TokenType.Minus);
            VarOrFuncCall.FollowSet.Add(TokenType.Or);
            VarOrFuncCall.FollowSet.Add(TokenType.EqualEqual);
            VarOrFuncCall.FollowSet.Add(TokenType.LesserGreater);
            VarOrFuncCall.FollowSet.Add(TokenType.Lesser);
            VarOrFuncCall.FollowSet.Add(TokenType.Greater);
            VarOrFuncCall.FollowSet.Add(TokenType.LesserEqual);
            VarOrFuncCall.FollowSet.Add(TokenType.GreaterEqual);
            VarOrFuncCall.FollowSet.Add(TokenType.CloseSquareBrace);
            VarOrFuncCall.FollowSet.Add(TokenType.SemiColon);
            VarOrFuncCall.FollowSet.Add(TokenType.Comma);
            VarOrFuncCall.FollowSet.Add(TokenType.CloseBrace);

            FactorVar.FirstSet.Add(TokenType.Period);
            FactorVar.FollowSet.Add(TokenType.Asterix);
            FactorVar.FollowSet.Add(TokenType.FwdSlash);
            FactorVar.FollowSet.Add(TokenType.And);
            FactorVar.FollowSet.Add(TokenType.Plus);
            FactorVar.FollowSet.Add(TokenType.Minus);
            FactorVar.FollowSet.Add(TokenType.Or);
            FactorVar.FollowSet.Add(TokenType.EqualEqual);
            FactorVar.FollowSet.Add(TokenType.LesserGreater);
            FactorVar.FollowSet.Add(TokenType.Lesser);
            FactorVar.FollowSet.Add(TokenType.Greater);
            FactorVar.FollowSet.Add(TokenType.LesserEqual);
            FactorVar.FollowSet.Add(TokenType.GreaterEqual);
            FactorVar.FollowSet.Add(TokenType.CloseSquareBrace);
            FactorVar.FollowSet.Add(TokenType.SemiColon);
            FactorVar.FollowSet.Add(TokenType.Comma);
            FactorVar.FollowSet.Add(TokenType.CloseBrace);

            FactorFuncCall.FirstSet.Add(TokenType.Period);
            FactorFuncCall.FollowSet.Add(TokenType.Asterix);
            FactorFuncCall.FollowSet.Add(TokenType.FwdSlash);
            FactorFuncCall.FollowSet.Add(TokenType.And);
            FactorFuncCall.FollowSet.Add(TokenType.Plus);
            FactorFuncCall.FollowSet.Add(TokenType.Minus);
            FactorFuncCall.FollowSet.Add(TokenType.Or);
            FactorFuncCall.FollowSet.Add(TokenType.EqualEqual);
            FactorFuncCall.FollowSet.Add(TokenType.LesserGreater);
            FactorFuncCall.FollowSet.Add(TokenType.Lesser);
            FactorFuncCall.FollowSet.Add(TokenType.Greater);
            FactorFuncCall.FollowSet.Add(TokenType.LesserEqual);
            FactorFuncCall.FollowSet.Add(TokenType.GreaterEqual);
            FactorFuncCall.FollowSet.Add(TokenType.CloseSquareBrace);
            FactorFuncCall.FollowSet.Add(TokenType.SemiColon);
            FactorFuncCall.FollowSet.Add(TokenType.Comma);
            FactorFuncCall.FollowSet.Add(TokenType.CloseBrace);

            VarFuncCall.FirstSet.Add(TokenType.Identifier);

            Term.FirstSet.Add(TokenType.IntNum);
            Term.FirstSet.Add(TokenType.FloatNum);
            Term.FirstSet.Add(TokenType.OpenBrace);
            Term.FirstSet.Add(TokenType.Not);
            Term.FirstSet.Add(TokenType.Identifier);
            Term.FirstSet.Add(TokenType.Plus);
            Term.FirstSet.Add(TokenType.Minus);

            MultOp.FirstSet.Add(TokenType.Asterix);
            MultOp.FirstSet.Add(TokenType.FwdSlash);
            MultOp.FirstSet.Add(TokenType.And);

            Factor.FirstSet.Add(TokenType.IntNum);
            Factor.FirstSet.Add(TokenType.FloatNum);
            Factor.FirstSet.Add(TokenType.OpenBrace);
            Factor.FirstSet.Add(TokenType.Not);
            Factor.FirstSet.Add(TokenType.Identifier);
            Factor.FirstSet.Add(TokenType.Plus);
            Factor.FirstSet.Add(TokenType.Minus);

            RightTerm.FirstSet.Add(TokenType.Asterix);
            RightTerm.FirstSet.Add(TokenType.FwdSlash);
            RightTerm.FirstSet.Add(TokenType.And);
            RightTerm.FollowSet.Add(TokenType.Plus);
            RightTerm.FollowSet.Add(TokenType.Minus);
            RightTerm.FollowSet.Add(TokenType.Or);
            RightTerm.FollowSet.Add(TokenType.EqualEqual);
            RightTerm.FollowSet.Add(TokenType.LesserGreater);
            RightTerm.FollowSet.Add(TokenType.Lesser);
            RightTerm.FollowSet.Add(TokenType.Greater);
            RightTerm.FollowSet.Add(TokenType.LesserGreater);
            RightTerm.FollowSet.Add(TokenType.GreaterEqual);
            RightTerm.FollowSet.Add(TokenType.CloseSquareBrace);
            RightTerm.FollowSet.Add(TokenType.SemiColon);
            RightTerm.FollowSet.Add(TokenType.Comma);
            RightTerm.FollowSet.Add(TokenType.CloseBrace);

            TypeOrVoid.FirstSet.Add(TokenType.Void);
            TypeOrVoid.FirstSet.Add(TokenType.Identifier);
            TypeOrVoid.FirstSet.Add(TokenType.Integer);
            TypeOrVoid.FirstSet.Add(TokenType.Float);

            TypeNoID.FirstSet.Add(TokenType.Integer);
            TypeNoID.FirstSet.Add(TokenType.Float);

            ArraySize.FirstSet.Add(TokenType.OpenSquareBrace);

            OptionalInt.FirstSet.Add(TokenType.IntNum);
            OptionalInt.FollowSet.Add(TokenType.CloseSquareBrace);

            FuncCallParamsRest.FirstSet.Add(TokenType.Comma);

            FuncCallParams.FirstSet.Add(TokenType.IntNum);
            FuncCallParams.FirstSet.Add(TokenType.FloatNum);
            FuncCallParams.FirstSet.Add(TokenType.OpenBrace);
            FuncCallParams.FirstSet.Add(TokenType.Not);
            FuncCallParams.FirstSet.Add(TokenType.Identifier);
            FuncCallParams.FirstSet.Add(TokenType.Plus);
            FuncCallParams.FirstSet.Add(TokenType.Minus);
            FuncCallParams.FollowSet.Add(TokenType.CloseBrace);

            Expression.FirstSet.Add(TokenType.IntNum);
            Expression.FirstSet.Add(TokenType.FloatNum);
            Expression.FirstSet.Add(TokenType.OpenBrace);
            Expression.FirstSet.Add(TokenType.Not);
            Expression.FirstSet.Add(TokenType.Identifier);
            Expression.FirstSet.Add(TokenType.Plus);
            Expression.FirstSet.Add(TokenType.Minus);

            FuncCallParamsRests.FirstSet.Add(TokenType.Comma);
            FuncCallParamsRests.FollowSet.Add(TokenType.CloseBrace);

            VarDecl.FirstSet.Add(TokenType.Identifier);

            FuncBody.FirstSet.Add(TokenType.Do);
            FuncBody.FirstSet.Add(TokenType.Local);

            LocalScope.FirstSet.Add(TokenType.Local);
            LocalScope.FollowSet.Add(TokenType.Do);

            StatementBlock.FirstSet.Add(TokenType.Do);
            StatementBlock.FirstSet.Add(TokenType.If);
            StatementBlock.FirstSet.Add(TokenType.While);
            StatementBlock.FirstSet.Add(TokenType.Read);
            StatementBlock.FirstSet.Add(TokenType.Write);
            StatementBlock.FirstSet.Add(TokenType.Return);
            StatementBlock.FirstSet.Add(TokenType.Identifier);
            StatementBlock.FollowSet.Add(TokenType.Else);
            StatementBlock.FollowSet.Add(TokenType.SemiColon);

            Statements.FirstSet.Add(TokenType.If);
            Statements.FirstSet.Add(TokenType.While);
            Statements.FirstSet.Add(TokenType.Read);
            Statements.FirstSet.Add(TokenType.Write);
            Statements.FirstSet.Add(TokenType.Return);
            Statements.FirstSet.Add(TokenType.Identifier);
            Statements.FollowSet.Add(TokenType.End);

            Statement.FirstSet.Add(TokenType.If);
            Statement.FirstSet.Add(TokenType.While);
            Statement.FirstSet.Add(TokenType.Read);
            Statement.FirstSet.Add(TokenType.Write);
            Statement.FirstSet.Add(TokenType.Return);
            Statement.FirstSet.Add(TokenType.Identifier);

            FuncParamsRest.FirstSet.Add(TokenType.Comma);

            Type.FirstSet.Add(TokenType.Identifier);
            Type.FirstSet.Add(TokenType.Integer);
            Type.FirstSet.Add(TokenType.Float);

            ArrayDims.FirstSet.Add(TokenType.OpenSquareBrace);
            ArrayDims.FollowSet.Add(TokenType.CloseBrace);
            ArrayDims.FollowSet.Add(TokenType.Comma);
            ArrayDims.FollowSet.Add(TokenType.SemiColon);

            Index.FirstSet.Add(TokenType.OpenSquareBrace);

            Indices.FirstSet.Add(TokenType.OpenSquareBrace);
            Indices.FollowSet.Add(TokenType.Asterix);
            Indices.FollowSet.Add(TokenType.FwdSlash);
            Indices.FollowSet.Add(TokenType.And);
            Indices.FollowSet.Add(TokenType.Plus);
            Indices.FollowSet.Add(TokenType.Minus);
            Indices.FollowSet.Add(TokenType.Or);
            Indices.FollowSet.Add(TokenType.EqualEqual);
            Indices.FollowSet.Add(TokenType.LesserGreater);
            Indices.FollowSet.Add(TokenType.Lesser);
            Indices.FollowSet.Add(TokenType.Greater);
            Indices.FollowSet.Add(TokenType.LesserEqual);
            Indices.FollowSet.Add(TokenType.GreaterEqual);
            Indices.FollowSet.Add(TokenType.CloseSquareBrace);
            Indices.FollowSet.Add(TokenType.Equal);
            Indices.FollowSet.Add(TokenType.Period);
            Indices.FollowSet.Add(TokenType.SemiColon);
            Indices.FollowSet.Add(TokenType.Comma);
            Indices.FollowSet.Add(TokenType.CloseBrace);

            #endregion NonTerminals

            #region Rules
            Start.Rules.Add(new List<RuleBase>() { Program });
            Program.Rules.Add(new List<RuleBase>() { ClassDecls, FuncDefs, Main, FuncBody });
            ClassDecls.Rules.Add(new List<RuleBase>() { ClassDecl, ClassDecls });
            ClassDecls.Rules.Add(new List<RuleBase>() { });
            ClassDecl.Rules.Add(new List<RuleBase>() { Class, Identifier, OptionalInherits, OpenCurlyBrace, MemberDecls, CloseCurlyBrace, SemiColon });
            FuncDefs.Rules.Add(new List<RuleBase>() { FuncDef, FuncDefs });
            FuncDefs.Rules.Add(new List<RuleBase>() { });
            FuncDef.Rules.Add(new List<RuleBase>() { FuncSig, FuncBody, SemiColon });
            MemberDecls.Rules.Add(new List<RuleBase>() { Visibility, MemberDecl, MemberDecls });
            MemberDecls.Rules.Add(new List<RuleBase>() { });
            MemberDecl.Rules.Add(new List<RuleBase>() { Identifier, FuncOrVarDecl });
            MemberDecl.Rules.Add(new List<RuleBase>() { TypeNoID, VarDecl });
            FuncOrVarDecl.Rules.Add(new List<RuleBase>() { FuncDecl });
            FuncOrVarDecl.Rules.Add(new List<RuleBase>() { VarDecl });
            Visibility.Rules.Add(new List<RuleBase>() { Public });
            Visibility.Rules.Add(new List<RuleBase>() { Private });
            Statement.Rules.Add(new List<RuleBase>() { If, OpenBrace, BoolExpr, CloseBrace, Then, StatementBlock, Else, StatementBlock, SemiColon });
            Statement.Rules.Add(new List<RuleBase>() { While, OpenBrace, BoolExpr, CloseBrace, StatementBlock, SemiColon });
            Statement.Rules.Add(new List<RuleBase>() { Read, OpenBrace, StatementVar, CloseBrace, SemiColon });
            Statement.Rules.Add(new List<RuleBase>() { Write, OpenBrace, Expression, CloseBrace, SemiColon });
            Statement.Rules.Add(new List<RuleBase>() { Return, OpenBrace, Expression, CloseBrace, SemiColon });
            Statement.Rules.Add(new List<RuleBase>() { AssignStatementOrFuncCall });
            StatementVar.Rules.Add(new List<RuleBase>() { Identifier, StatementVarOrFuncCall });
            StatementVarOrFuncCall.Rules.Add(new List<RuleBase>() { Indices, StatementVarExt });
            StatementVarOrFuncCall.Rules.Add(new List<RuleBase>() { OpenBrace, FuncCallParams, CloseBrace, StatementFunctionCall });
            StatementVarExt.Rules.Add(new List<RuleBase>() { Period, StatementVar });
            StatementVarExt.Rules.Add(new List<RuleBase>() { });
            StatementFunctionCall.Rules.Add(new List<RuleBase>() { Period, StatementVar });
            AssignStatementOrFuncCall.Rules.Add(new List<RuleBase>() { Identifier, VarOrFuncCallExt });
            VarOrFuncCallExt.Rules.Add(new List<RuleBase>() { Indices, VarExt });
            VarOrFuncCallExt.Rules.Add(new List<RuleBase>() { OpenBrace, FuncCallParams, CloseBrace, FuncCallExt });
            VarExt.Rules.Add(new List<RuleBase>() { Equal, Expression, SemiColon });
            VarExt.Rules.Add(new List<RuleBase>() { Period, AssignStatementOrFuncCall });
            FuncCallExt.Rules.Add(new List<RuleBase>() { SemiColon });
            FuncCallExt.Rules.Add(new List<RuleBase>() { Period, AssignStatementOrFuncCall });
            FuncParams.Rules.Add(new List<RuleBase>() { Type, Identifier, ArrayDims, FuncParamsRests });
            FuncParams.Rules.Add(new List<RuleBase>() { });
            AddOp.Rules.Add(new List<RuleBase>() { Plus });
            AddOp.Rules.Add(new List<RuleBase>() { Minus });
            AddOp.Rules.Add(new List<RuleBase>() { Or });
            OptionalInherits.Rules.Add(new List<RuleBase>() { Inherits, Identifier, InheritedClasses });
            OptionalInherits.Rules.Add(new List<RuleBase>() { });
            BoolExpr.Rules.Add(new List<RuleBase>() { ArithExpr, CompareOp, ArithExpr });
            FuncDecl.Rules.Add(new List<RuleBase>() { OpenBrace, FuncParams, CloseBrace, Colon, TypeOrVoid, SemiColon });
            FuncCallParamsRests.Rules.Add(new List<RuleBase>() { FuncCallParamsRest, FuncCallParamsRests });
            FuncCallParamsRests.Rules.Add(new List<RuleBase>() { });
            LocalScope.Rules.Add(new List<RuleBase>() { Local, VarDecls });
            LocalScope.Rules.Add(new List<RuleBase>() { });
            ArrayDims.Rules.Add(new List<RuleBase>() { ArraySize, ArrayDims });
            ArrayDims.Rules.Add(new List<RuleBase>() { });
            Expression.Rules.Add(new List<RuleBase>() { ArithExpr, BoolExprOrNone });
            BoolExprOrNone.Rules.Add(new List<RuleBase>() { CompareOp, ArithExpr });
            BoolExprOrNone.Rules.Add(new List<RuleBase>() { });
            Statements.Rules.Add(new List<RuleBase>() { Statement, Statements });
            Statements.Rules.Add(new List<RuleBase>() { });
            ArithExpr.Rules.Add(new List<RuleBase>() { Term, RightArithExpr });
            RightArithExpr.Rules.Add(new List<RuleBase>() { });
            RightArithExpr.Rules.Add(new List<RuleBase>() { AddOp, Term, RightArithExpr });
            FuncSig.Rules.Add(new List<RuleBase>() { Identifier, FuncSigNamespace });
            FuncSigNamespace.Rules.Add(new List<RuleBase>() { FuncSigExt });
            FuncSigNamespace.Rules.Add(new List<RuleBase>() { ColonColon, Identifier, FuncSigExt });
            FuncSigExt.Rules.Add(new List<RuleBase>() { OpenBrace, FuncParams, CloseBrace, Colon, TypeOrVoid });
            FuncParamsRests.Rules.Add(new List<RuleBase>() { FuncParamsRest, FuncParamsRests });
            FuncParamsRests.Rules.Add(new List<RuleBase>() { });
            InheritedClasses.Rules.Add(new List<RuleBase>() { Comma, Identifier, InheritedClasses });
            InheritedClasses.Rules.Add(new List<RuleBase>() { });
            Sign.Rules.Add(new List<RuleBase>() { Plus });
            Sign.Rules.Add(new List<RuleBase>() { Minus });
            CompareOp.Rules.Add(new List<RuleBase>() { EqualEqual });
            CompareOp.Rules.Add(new List<RuleBase>() { LesserGreater });
            CompareOp.Rules.Add(new List<RuleBase>() { Lesser });
            CompareOp.Rules.Add(new List<RuleBase>() { Greater });
            CompareOp.Rules.Add(new List<RuleBase>() { LesserEqual });
            CompareOp.Rules.Add(new List<RuleBase>() { GreaterEqual });
            Index.Rules.Add(new List<RuleBase>() { OpenSquareBrace, ArithExpr, CloseSquareBrace });
            VarDecls.Rules.Add(new List<RuleBase>() { Type, VarDecl, VarDecls });
            VarDecls.Rules.Add(new List<RuleBase>() { });
            Factor.Rules.Add(new List<RuleBase>() { VarFuncCall });
            Factor.Rules.Add(new List<RuleBase>() { IntNum });
            Factor.Rules.Add(new List<RuleBase>() { FloatNum });
            Factor.Rules.Add(new List<RuleBase>() { OpenBrace, ArithExpr, CloseBrace });
            Factor.Rules.Add(new List<RuleBase>() { Not, Factor });
            Factor.Rules.Add(new List<RuleBase>() { Sign, Factor });
            VarFuncCall.Rules.Add(new List<RuleBase>() { Identifier, VarOrFuncCall });
            VarOrFuncCall.Rules.Add(new List<RuleBase>() { Indices, FactorVar });
            VarOrFuncCall.Rules.Add(new List<RuleBase>() { OpenBrace, FuncCallParams, CloseBrace, FactorFuncCall });
            FactorVar.Rules.Add(new List<RuleBase>() { Period, VarFuncCall });
            FactorVar.Rules.Add(new List<RuleBase>() { });
            FactorFuncCall.Rules.Add(new List<RuleBase>() { Period, VarFuncCall });
            FactorFuncCall.Rules.Add(new List<RuleBase>() { });
            Term.Rules.Add(new List<RuleBase>() { Factor, RightTerm });
            MultOp.Rules.Add(new List<RuleBase>() { Asterix });
            MultOp.Rules.Add(new List<RuleBase>() { FwdSlash });
            MultOp.Rules.Add(new List<RuleBase>() { And });
            RightTerm.Rules.Add(new List<RuleBase>() { });
            RightTerm.Rules.Add(new List<RuleBase>() { MultOp, Factor, RightTerm });
            TypeOrVoid.Rules.Add(new List<RuleBase>() { Type });
            TypeOrVoid.Rules.Add(new List<RuleBase>() { Void });
            Type.Rules.Add(new List<RuleBase>() { TypeNoID });
            Type.Rules.Add(new List<RuleBase>() { Identifier });
            TypeNoID.Rules.Add(new List<RuleBase>() { Integer });
            TypeNoID.Rules.Add(new List<RuleBase>() { Float });
            ArraySize.Rules.Add(new List<RuleBase>() { OpenSquareBrace, OptionalInt, CloseSquareBrace });
            OptionalInt.Rules.Add(new List<RuleBase>() { IntNum });
            OptionalInt.Rules.Add(new List<RuleBase>() { });
            FuncCallParamsRest.Rules.Add(new List<RuleBase>() { Comma, Expression });
            FuncCallParams.Rules.Add(new List<RuleBase>() { Expression, FuncCallParamsRests });
            FuncCallParams.Rules.Add(new List<RuleBase>() { });
            VarDecl.Rules.Add(new List<RuleBase>() { Identifier, ArrayDims, SemiColon });
            FuncBody.Rules.Add(new List<RuleBase>() { LocalScope, Do, Statements, End });
            StatementBlock.Rules.Add(new List<RuleBase>() { Do, Statements, End });
            StatementBlock.Rules.Add(new List<RuleBase>() { Statement });
            StatementBlock.Rules.Add(new List<RuleBase>() { });
            Indices.Rules.Add(new List<RuleBase>() { Index, Indices });
            Indices.Rules.Add(new List<RuleBase>() { });

            #endregion

            return grammar;
        }
    }
}
