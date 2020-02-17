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
            IntNum.FollowSet.Add(TokenType.Asterix);
            IntNum.FollowSet.Add(TokenType.FwdSlash);
            IntNum.FollowSet.Add(TokenType.And);
            IntNum.FollowSet.Add(TokenType.Plus);
            IntNum.FollowSet.Add(TokenType.Minus);
            IntNum.FollowSet.Add(TokenType.Or);
            IntNum.FollowSet.Add(TokenType.EqualEqual);
            IntNum.FollowSet.Add(TokenType.LesserGreater);
            IntNum.FollowSet.Add(TokenType.Lesser);
            IntNum.FollowSet.Add(TokenType.Greater);
            IntNum.FollowSet.Add(TokenType.LesserEqual);
            IntNum.FollowSet.Add(TokenType.GreaterEqual);
            IntNum.FollowSet.Add(TokenType.CloseSquareBrace);
            IntNum.FollowSet.Add(TokenType.SemiColon);
            IntNum.FollowSet.Add(TokenType.Comma);
            IntNum.FollowSet.Add(TokenType.CloseBrace);

            FloatNum.FirstSet.Add(TokenType.FloatNum);
            FloatNum.FollowSet.Add(TokenType.Asterix);
            FloatNum.FollowSet.Add(TokenType.FwdSlash);
            FloatNum.FollowSet.Add(TokenType.And);
            FloatNum.FollowSet.Add(TokenType.Plus);
            FloatNum.FollowSet.Add(TokenType.Minus);
            FloatNum.FollowSet.Add(TokenType.Or);
            FloatNum.FollowSet.Add(TokenType.EqualEqual);
            FloatNum.FollowSet.Add(TokenType.LesserGreater);
            FloatNum.FollowSet.Add(TokenType.Lesser);
            FloatNum.FollowSet.Add(TokenType.Greater);
            FloatNum.FollowSet.Add(TokenType.LesserEqual);
            FloatNum.FollowSet.Add(TokenType.GreaterEqual);
            FloatNum.FollowSet.Add(TokenType.CloseSquareBrace);
            FloatNum.FollowSet.Add(TokenType.SemiColon);
            FloatNum.FollowSet.Add(TokenType.Comma);
            FloatNum.FollowSet.Add(TokenType.CloseBrace);

            Integer.FirstSet.Add(TokenType.Integer);
            Integer.FollowSet.Add(TokenType.SemiColon);
            Integer.FollowSet.Add(TokenType.Identifier);
            Integer.FollowSet.Add(TokenType.Do);
            Integer.FollowSet.Add(TokenType.Local);


            Float.FirstSet.Add(TokenType.Float);
            Float.FollowSet.Add(TokenType.SemiColon);
            Float.FollowSet.Add(TokenType.Identifier);
            Float.FollowSet.Add(TokenType.Do);
            Float.FollowSet.Add(TokenType.Local);

            Identifier.FirstSet.Add(TokenType.Identifier);
            Identifier.FollowSet.Add(TokenType.Asterix);
            Identifier.FollowSet.Add(TokenType.FwdSlash);
            Identifier.FollowSet.Add(TokenType.And);
            Identifier.FollowSet.Add(TokenType.Plus);
            Identifier.FollowSet.Add(TokenType.Minus);
            Identifier.FollowSet.Add(TokenType.Or);
            Identifier.FollowSet.Add(TokenType.EqualEqual);
            Identifier.FollowSet.Add(TokenType.LesserGreater);
            Identifier.FollowSet.Add(TokenType.Lesser);
            Identifier.FollowSet.Add(TokenType.Greater);
            Identifier.FollowSet.Add(TokenType.LesserEqual);
            Identifier.FollowSet.Add(TokenType.GreaterEqual);
            Identifier.FollowSet.Add(TokenType.CloseSquareBrace);
            Identifier.FollowSet.Add(TokenType.CloseBrace);
            Identifier.FollowSet.Add(TokenType.Do);
            Identifier.FollowSet.Add(TokenType.Local);
            Identifier.FollowSet.Add(TokenType.Inherits);
            Identifier.FollowSet.Add(TokenType.OpenCurlyBrace);
            Identifier.FollowSet.Add(TokenType.Identifier);
            Identifier.FollowSet.Add(TokenType.Equal);
            Identifier.FollowSet.Add(TokenType.ColonColon);
            Identifier.FollowSet.Add(TokenType.Comma);
            Identifier.FollowSet.Add(TokenType.OpenBrace);
            Identifier.FollowSet.Add(TokenType.Period);
            Identifier.FollowSet.Add(TokenType.SemiColon);
            Identifier.FollowSet.Add(TokenType.OpenSquareBrace);

            Void.FirstSet.Add(TokenType.Void);
            Void.FollowSet.Add(TokenType.SemiColon);
            Void.FollowSet.Add(TokenType.Do);
            Void.FollowSet.Add(TokenType.Local);

            And.FirstSet.Add(TokenType.And);
            And.FollowSet.Add(TokenType.IntNum);
            And.FollowSet.Add(TokenType.FloatNum);
            And.FollowSet.Add(TokenType.OpenBrace);
            And.FollowSet.Add(TokenType.Not);
            And.FollowSet.Add(TokenType.Identifier);
            And.FollowSet.Add(TokenType.Plus);
            And.FollowSet.Add(TokenType.Minus);

            FwdSlash.FirstSet.Add(TokenType.FwdSlash);
            FwdSlash.FollowSet.Add(TokenType.IntNum);
            FwdSlash.FollowSet.Add(TokenType.FloatNum);
            FwdSlash.FollowSet.Add(TokenType.OpenBrace);
            FwdSlash.FollowSet.Add(TokenType.Not);
            FwdSlash.FollowSet.Add(TokenType.Identifier);
            FwdSlash.FollowSet.Add(TokenType.Plus);
            FwdSlash.FollowSet.Add(TokenType.Minus);

            Asterix.FirstSet.Add(TokenType.Asterix);
            Asterix.FollowSet.Add(TokenType.IntNum);
            Asterix.FollowSet.Add(TokenType.FloatNum);
            Asterix.FollowSet.Add(TokenType.OpenBrace);
            Asterix.FollowSet.Add(TokenType.Not);
            Asterix.FollowSet.Add(TokenType.Identifier);
            Asterix.FollowSet.Add(TokenType.Plus);
            Asterix.FollowSet.Add(TokenType.Minus);

            Period.FirstSet.Add(TokenType.Period);
            Period.FollowSet.Add(TokenType.Identifier);

            OpenSquareBrace.FirstSet.Add(TokenType.OpenSquareBrace);
            OpenSquareBrace.FollowSet.Add(TokenType.FloatNum);
            OpenSquareBrace.FollowSet.Add(TokenType.OpenBrace);
            OpenSquareBrace.FollowSet.Add(TokenType.Not);
            OpenSquareBrace.FollowSet.Add(TokenType.Identifier);
            OpenSquareBrace.FollowSet.Add(TokenType.Plus);
            OpenSquareBrace.FollowSet.Add(TokenType.Minus);
            OpenSquareBrace.FollowSet.Add(TokenType.IntNum);
            OpenSquareBrace.FollowSet.Add(TokenType.CloseSquareBrace);

            CloseSquareBrace.FirstSet.Add(TokenType.CloseSquareBrace);
            CloseSquareBrace.FollowSet.Add(TokenType.Asterix);
            CloseSquareBrace.FollowSet.Add(TokenType.FwdSlash);
            CloseSquareBrace.FollowSet.Add(TokenType.And);
            CloseSquareBrace.FollowSet.Add(TokenType.Plus);
            CloseSquareBrace.FollowSet.Add(TokenType.Minus);
            CloseSquareBrace.FollowSet.Add(TokenType.Or);
            CloseSquareBrace.FollowSet.Add(TokenType.OpenSquareBrace);
            CloseSquareBrace.FollowSet.Add(TokenType.EqualEqual);
            CloseSquareBrace.FollowSet.Add(TokenType.LesserGreater);
            CloseSquareBrace.FollowSet.Add(TokenType.Lesser);
            CloseSquareBrace.FollowSet.Add(TokenType.Greater);
            CloseSquareBrace.FollowSet.Add(TokenType.LesserEqual);
            CloseSquareBrace.FollowSet.Add(TokenType.GreaterEqual);
            CloseSquareBrace.FollowSet.Add(TokenType.CloseSquareBrace);
            CloseSquareBrace.FollowSet.Add(TokenType.Equal);
            CloseSquareBrace.FollowSet.Add(TokenType.Period);
            CloseSquareBrace.FollowSet.Add(TokenType.SemiColon);
            CloseSquareBrace.FollowSet.Add(TokenType.Comma);
            CloseSquareBrace.FollowSet.Add(TokenType.CloseBrace);

            OpenBrace.FirstSet.Add(TokenType.OpenBrace);
            OpenBrace.FollowSet.Add(TokenType.Integer);
            OpenBrace.FollowSet.Add(TokenType.Float);
            OpenBrace.FollowSet.Add(TokenType.IntNum);
            OpenBrace.FollowSet.Add(TokenType.FloatNum);
            OpenBrace.FollowSet.Add(TokenType.OpenBrace);
            OpenBrace.FollowSet.Add(TokenType.Not);
            OpenBrace.FollowSet.Add(TokenType.Identifier);
            OpenBrace.FollowSet.Add(TokenType.Plus);
            OpenBrace.FollowSet.Add(TokenType.Minus);
            OpenBrace.FollowSet.Add(TokenType.CloseBrace);

            CloseBrace.FirstSet.Add(TokenType.CloseBrace);
            CloseBrace.FollowSet.Add(TokenType.Asterix);
            CloseBrace.FollowSet.Add(TokenType.FwdSlash);
            CloseBrace.FollowSet.Add(TokenType.And);
            CloseBrace.FollowSet.Add(TokenType.Plus);
            CloseBrace.FollowSet.Add(TokenType.Minus);
            CloseBrace.FollowSet.Add(TokenType.Or);
            CloseBrace.FollowSet.Add(TokenType.EqualEqual);
            CloseBrace.FollowSet.Add(TokenType.LesserGreater);
            CloseBrace.FollowSet.Add(TokenType.Lesser);
            CloseBrace.FollowSet.Add(TokenType.Greater);
            CloseBrace.FollowSet.Add(TokenType.LesserEqual);
            CloseBrace.FollowSet.Add(TokenType.GreaterEqual);
            CloseBrace.FollowSet.Add(TokenType.CloseSquareBrace);
            CloseBrace.FollowSet.Add(TokenType.Comma);
            CloseBrace.FollowSet.Add(TokenType.Then);
            CloseBrace.FollowSet.Add(TokenType.Do);
            CloseBrace.FollowSet.Add(TokenType.If);
            CloseBrace.FollowSet.Add(TokenType.While);
            CloseBrace.FollowSet.Add(TokenType.Read);
            CloseBrace.FollowSet.Add(TokenType.Write);
            CloseBrace.FollowSet.Add(TokenType.Return);
            CloseBrace.FollowSet.Add(TokenType.Identifier);
            CloseBrace.FollowSet.Add(TokenType.SemiColon);
            CloseBrace.FollowSet.Add(TokenType.Colon);
            CloseBrace.FollowSet.Add(TokenType.Period);
            CloseBrace.FollowSet.Add(TokenType.CloseBrace);

            Not.FirstSet.Add(TokenType.Not);
            Not.FollowSet.Add(TokenType.IntNum);
            Not.FollowSet.Add(TokenType.FloatNum);
            Not.FollowSet.Add(TokenType.OpenBrace);
            Not.FollowSet.Add(TokenType.Not);
            Not.FollowSet.Add(TokenType.Identifier);
            Not.FollowSet.Add(TokenType.Plus);
            Not.FollowSet.Add(TokenType.Minus);

            Plus.FirstSet.Add(TokenType.Plus);
            Plus.FollowSet.Add(TokenType.IntNum);
            Plus.FollowSet.Add(TokenType.FloatNum);
            Plus.FollowSet.Add(TokenType.OpenBrace);
            Plus.FollowSet.Add(TokenType.Not);
            Plus.FollowSet.Add(TokenType.Identifier);
            Plus.FollowSet.Add(TokenType.Plus);
            Plus.FollowSet.Add(TokenType.Minus);

            Minus.FirstSet.Add(TokenType.Minus);
            Minus.FollowSet.Add(TokenType.IntNum);
            Minus.FollowSet.Add(TokenType.FloatNum);
            Minus.FollowSet.Add(TokenType.OpenBrace);
            Minus.FollowSet.Add(TokenType.Not);
            Minus.FollowSet.Add(TokenType.Identifier);
            Minus.FollowSet.Add(TokenType.Plus);
            Minus.FollowSet.Add(TokenType.Minus);

            SemiColon.FirstSet.Add(TokenType.SemiColon);
            SemiColon.FollowSet.Add(TokenType.Do);
            SemiColon.FollowSet.Add(TokenType.End);
            SemiColon.FollowSet.Add(TokenType.Integer);
            SemiColon.FollowSet.Add(TokenType.Float);
            SemiColon.FollowSet.Add(TokenType.If);
            SemiColon.FollowSet.Add(TokenType.While);
            SemiColon.FollowSet.Add(TokenType.Read);
            SemiColon.FollowSet.Add(TokenType.Write);
            SemiColon.FollowSet.Add(TokenType.Return);
            SemiColon.FollowSet.Add(TokenType.Else);
            SemiColon.FollowSet.Add(TokenType.SemiColon);
            SemiColon.FollowSet.Add(TokenType.Public);
            SemiColon.FollowSet.Add(TokenType.Private);
            SemiColon.FollowSet.Add(TokenType.CloseCurlyBrace);
            SemiColon.FollowSet.Add(TokenType.Class);
            SemiColon.FollowSet.Add(TokenType.Identifier);
            SemiColon.FollowSet.Add(TokenType.Main);

            Equal.FirstSet.Add(TokenType.Equal);
            Equal.FollowSet.Add(TokenType.IntNum);
            Equal.FollowSet.Add(TokenType.FloatNum);
            Equal.FollowSet.Add(TokenType.OpenBrace);
            Equal.FollowSet.Add(TokenType.Not);
            Equal.FollowSet.Add(TokenType.Identifier);
            Equal.FollowSet.Add(TokenType.Plus);
            Equal.FollowSet.Add(TokenType.Minus);

            LesserGreater.FirstSet.Add(TokenType.LesserGreater);
            LesserGreater.FollowSet.Add(TokenType.IntNum);
            LesserGreater.FollowSet.Add(TokenType.FloatNum);
            LesserGreater.FollowSet.Add(TokenType.OpenBrace);
            LesserGreater.FollowSet.Add(TokenType.Not);
            LesserGreater.FollowSet.Add(TokenType.Identifier);
            LesserGreater.FollowSet.Add(TokenType.Plus);
            LesserGreater.FollowSet.Add(TokenType.Minus);

            Lesser.FirstSet.Add(TokenType.Lesser);
            Lesser.FollowSet.Add(TokenType.IntNum);
            Lesser.FollowSet.Add(TokenType.FloatNum);
            Lesser.FollowSet.Add(TokenType.OpenBrace);
            Lesser.FollowSet.Add(TokenType.Not);
            Lesser.FollowSet.Add(TokenType.Identifier);
            Lesser.FollowSet.Add(TokenType.Plus);
            Lesser.FollowSet.Add(TokenType.Minus);

            Greater.FirstSet.Add(TokenType.Greater);
            Greater.FollowSet.Add(TokenType.IntNum);
            Greater.FollowSet.Add(TokenType.FloatNum);
            Greater.FollowSet.Add(TokenType.OpenBrace);
            Greater.FollowSet.Add(TokenType.Not);
            Greater.FollowSet.Add(TokenType.Identifier);
            Greater.FollowSet.Add(TokenType.Plus);
            Greater.FollowSet.Add(TokenType.Minus);

            LesserEqual.FirstSet.Add(TokenType.LesserEqual);
            LesserEqual.FollowSet.Add(TokenType.IntNum);
            LesserEqual.FollowSet.Add(TokenType.FloatNum);
            LesserEqual.FollowSet.Add(TokenType.OpenBrace);
            LesserEqual.FollowSet.Add(TokenType.Not);
            LesserEqual.FollowSet.Add(TokenType.Identifier);
            LesserEqual.FollowSet.Add(TokenType.Plus);
            LesserEqual.FollowSet.Add(TokenType.Minus);

            GreaterEqual.FirstSet.Add(TokenType.GreaterEqual);
            GreaterEqual.FollowSet.Add(TokenType.IntNum);
            GreaterEqual.FollowSet.Add(TokenType.FloatNum);
            GreaterEqual.FollowSet.Add(TokenType.OpenBrace);
            GreaterEqual.FollowSet.Add(TokenType.Not);
            GreaterEqual.FollowSet.Add(TokenType.Identifier);
            GreaterEqual.FollowSet.Add(TokenType.Plus);
            GreaterEqual.FollowSet.Add(TokenType.Minus);

            Comma.FirstSet.Add(TokenType.Comma);
            Comma.FollowSet.Add(TokenType.IntNum);
            Comma.FollowSet.Add(TokenType.FloatNum);
            Comma.FollowSet.Add(TokenType.OpenBrace);
            Comma.FollowSet.Add(TokenType.Not);
            Comma.FollowSet.Add(TokenType.Identifier);
            Comma.FollowSet.Add(TokenType.Plus);
            Comma.FollowSet.Add(TokenType.Minus);
            Comma.FollowSet.Add(TokenType.Integer);
            Comma.FollowSet.Add(TokenType.Float);

            ColonColon.FirstSet.Add(TokenType.ColonColon);
            ColonColon.FollowSet.Add(TokenType.Identifier);

            Colon.FirstSet.Add(TokenType.Colon);
            Colon.FollowSet.Add(TokenType.Void);
            Colon.FollowSet.Add(TokenType.Identifier);
            Colon.FollowSet.Add(TokenType.Integer);
            Colon.FollowSet.Add(TokenType.Float);

            Local.FirstSet.Add(TokenType.Local);
            Local.FollowSet.Add(TokenType.Do);
            Local.FollowSet.Add(TokenType.Identifier);
            Local.FollowSet.Add(TokenType.Integer);
            Local.FollowSet.Add(TokenType.Float);

            Inherits.FirstSet.Add(TokenType.Inherits);
            Inherits.FollowSet.Add(TokenType.Identifier);

            Or.FirstSet.Add(TokenType.Or);
            Or.FirstSet.Add(TokenType.IntNum);
            Or.FirstSet.Add(TokenType.FloatNum);
            Or.FirstSet.Add(TokenType.OpenBrace);
            Or.FirstSet.Add(TokenType.Not);
            Or.FirstSet.Add(TokenType.Identifier);
            Or.FirstSet.Add(TokenType.Plus);
            Or.FirstSet.Add(TokenType.Minus);

            Do.FirstSet.Add(TokenType.Do);
            Do.FollowSet.Add(TokenType.If);
            Do.FollowSet.Add(TokenType.While);
            Do.FollowSet.Add(TokenType.Read);
            Do.FollowSet.Add(TokenType.Write);
            Do.FollowSet.Add(TokenType.Read);
            Do.FollowSet.Add(TokenType.Identifier);
            Do.FollowSet.Add(TokenType.End);

            End.FirstSet.Add(TokenType.End);
            End.FollowSet.Add(TokenType.Else);
            End.FollowSet.Add(TokenType.SemiColon);

            Public.FirstSet.Add(TokenType.Public);
            Public.FollowSet.Add(TokenType.Identifier);
            Public.FollowSet.Add(TokenType.Inherits);
            Public.FollowSet.Add(TokenType.Float);

            Private.FirstSet.Add(TokenType.Private);
            Private.FollowSet.Add(TokenType.Identifier);
            Private.FollowSet.Add(TokenType.Inherits);
            Private.FollowSet.Add(TokenType.Float);

            Main.FirstSet.Add(TokenType.Main);
            Main.FollowSet.Add(TokenType.Do);
            Main.FollowSet.Add(TokenType.Local);

            If.FirstSet.Add(TokenType.If);
            If.FollowSet.Add(TokenType.OpenBrace);

            Then.FirstSet.Add(TokenType.Then);
            Then.FollowSet.Add(TokenType.Do);
            Then.FollowSet.Add(TokenType.If);
            Then.FollowSet.Add(TokenType.While);
            Then.FollowSet.Add(TokenType.Read);
            Then.FollowSet.Add(TokenType.Write);
            Then.FollowSet.Add(TokenType.Return);
            Then.FollowSet.Add(TokenType.Identifier);
            Then.FollowSet.Add(TokenType.Else);

            Else.FirstSet.Add(TokenType.Else);
            Else.FollowSet.Add(TokenType.Do);
            Else.FollowSet.Add(TokenType.If);
            Else.FollowSet.Add(TokenType.While);
            Else.FollowSet.Add(TokenType.Read);
            Else.FollowSet.Add(TokenType.Write);
            Else.FollowSet.Add(TokenType.Return);
            Else.FollowSet.Add(TokenType.Identifier);
            Else.FollowSet.Add(TokenType.SemiColon);

            While.FirstSet.Add(TokenType.While);
            While.FollowSet.Add(TokenType.OpenBrace);

            Read.FirstSet.Add(TokenType.Read);
            Read.FollowSet.Add(TokenType.OpenBrace);

            Write.FirstSet.Add(TokenType.Write);
            Write.FollowSet.Add(TokenType.OpenBrace);

            Return.FirstSet.Add(TokenType.Return);
            Return.FollowSet.Add(TokenType.OpenBrace);

            Class.FirstSet.Add(TokenType.Class);
            Class.FollowSet.Add(TokenType.Identifier);

            OpenCurlyBrace.FirstSet.Add(TokenType.OpenCurlyBrace);
            OpenCurlyBrace.FollowSet.Add(TokenType.Public);
            OpenCurlyBrace.FollowSet.Add(TokenType.Private);
            OpenCurlyBrace.FollowSet.Add(TokenType.CloseCurlyBrace);

            CloseCurlyBrace.FirstSet.Add(TokenType.CloseCurlyBrace);
            CloseCurlyBrace.FollowSet.Add(TokenType.SemiColon);

            EqualEqual.FirstSet.Add(TokenType.EqualEqual);
            EqualEqual.FollowSet.Add(TokenType.IntNum);
            EqualEqual.FollowSet.Add(TokenType.FloatNum);
            EqualEqual.FollowSet.Add(TokenType.OpenBrace);
            EqualEqual.FollowSet.Add(TokenType.Not);
            EqualEqual.FollowSet.Add(TokenType.Identifier);
            EqualEqual.FollowSet.Add(TokenType.Plus);
            EqualEqual.FollowSet.Add(TokenType.Minus);

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
            var FuncCallParamsRests = new GrammarRule(NonTerminal.FuncCallParamsRests, true);
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
            var VarOrFuncCall = new GrammarRule(NonTerminal.VarOrFuncCall, true);
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
            ClassDecl.FollowSet.Add(TokenType.Class);
            ClassDecl.FollowSet.Add(TokenType.Identifier);
            ClassDecl.FollowSet.Add(TokenType.Main);

            FuncDefs.FirstSet.Add(TokenType.Identifier);
            FuncDefs.FollowSet.Add(TokenType.Main);

            FuncDef.FirstSet.Add(TokenType.Identifier);
            FuncDef.FollowSet.Add(TokenType.Identifier);
            FuncDef.FollowSet.Add(TokenType.Main);

            MemberDecls.FirstSet.Add(TokenType.Public);
            MemberDecls.FirstSet.Add(TokenType.Private);
            MemberDecls.FollowSet.Add(TokenType.CloseCurlyBrace);

            MemberDecl.FirstSet.Add(TokenType.Identifier);
            MemberDecl.FirstSet.Add(TokenType.Integer);
            MemberDecl.FirstSet.Add(TokenType.Float);
            MemberDecl.FollowSet.Add(TokenType.Public);
            MemberDecl.FollowSet.Add(TokenType.Private);
            MemberDecl.FollowSet.Add(TokenType.CloseCurlyBrace);

            FuncOrVarDecl.FirstSet.Add(TokenType.OpenBrace);
            FuncOrVarDecl.FirstSet.Add(TokenType.Identifier);
            FuncOrVarDecl.FollowSet.Add(TokenType.Public);
            FuncOrVarDecl.FollowSet.Add(TokenType.Private);
            FuncOrVarDecl.FollowSet.Add(TokenType.CloseCurlyBrace);

            Visibility.FirstSet.Add(TokenType.Public);
            Visibility.FirstSet.Add(TokenType.Private);
            Visibility.FollowSet.Add(TokenType.Identifier);
            Visibility.FollowSet.Add(TokenType.Integer);
            Visibility.FollowSet.Add(TokenType.Float);

            StatementVarOrFuncCall.FirstSet.Add(TokenType.OpenBrace);
            StatementVarOrFuncCall.FirstSet.Add(TokenType.Period);
            StatementVarOrFuncCall.FirstSet.Add(TokenType.OpenSquareBrace);
            StatementVarOrFuncCall.FollowSet.Add(TokenType.CloseCurlyBrace);

            StatementVarExt.FirstSet.Add(TokenType.Period);
            StatementVarExt.FollowSet.Add(TokenType.CloseCurlyBrace);

            StatementFunctionCall.FirstSet.Add(TokenType.Period);
            StatementFunctionCall.FollowSet.Add(TokenType.CloseCurlyBrace);

            StatementVar.FirstSet.Add(TokenType.Identifier);
            StatementVar.FollowSet.Add(TokenType.CloseCurlyBrace);

            VarOrFuncCallExt.FirstSet.Add(TokenType.OpenBrace);
            VarOrFuncCallExt.FirstSet.Add(TokenType.Equal);
            VarOrFuncCallExt.FirstSet.Add(TokenType.Period);
            VarOrFuncCallExt.FirstSet.Add(TokenType.OpenSquareBrace);
            VarOrFuncCallExt.FollowSet.Add(TokenType.End);
            VarOrFuncCallExt.FollowSet.Add(TokenType.If);
            VarOrFuncCallExt.FollowSet.Add(TokenType.While);
            VarOrFuncCallExt.FollowSet.Add(TokenType.Read);
            VarOrFuncCallExt.FollowSet.Add(TokenType.Write);
            VarOrFuncCallExt.FollowSet.Add(TokenType.Return);
            VarOrFuncCallExt.FollowSet.Add(TokenType.Identifier);
            VarOrFuncCallExt.FollowSet.Add(TokenType.Else);
            VarOrFuncCallExt.FollowSet.Add(TokenType.SemiColon);

            VarExt.FirstSet.Add(TokenType.Equal);
            VarExt.FirstSet.Add(TokenType.Period);
            VarExt.FollowSet.Add(TokenType.End);
            VarExt.FollowSet.Add(TokenType.If);
            VarExt.FollowSet.Add(TokenType.While);
            VarExt.FollowSet.Add(TokenType.Read);
            VarExt.FollowSet.Add(TokenType.Write);
            VarExt.FollowSet.Add(TokenType.Return);
            VarExt.FollowSet.Add(TokenType.Identifier);
            VarExt.FollowSet.Add(TokenType.Else);
            VarExt.FollowSet.Add(TokenType.SemiColon);

            FuncCallExt.FirstSet.Add(TokenType.SemiColon);
            FuncCallExt.FirstSet.Add(TokenType.Period);
            FuncCallExt.FollowSet.Add(TokenType.End);
            FuncCallExt.FollowSet.Add(TokenType.If);
            FuncCallExt.FollowSet.Add(TokenType.While);
            FuncCallExt.FollowSet.Add(TokenType.Read);
            FuncCallExt.FollowSet.Add(TokenType.Write);
            FuncCallExt.FollowSet.Add(TokenType.Return);
            FuncCallExt.FollowSet.Add(TokenType.Identifier);
            FuncCallExt.FollowSet.Add(TokenType.Else);
            FuncCallExt.FollowSet.Add(TokenType.SemiColon);

            AssignStatementOrFuncCall.FirstSet.Add(TokenType.Identifier);
            AssignStatementOrFuncCall.FollowSet.Add(TokenType.End);
            AssignStatementOrFuncCall.FollowSet.Add(TokenType.If);
            AssignStatementOrFuncCall.FollowSet.Add(TokenType.While);
            AssignStatementOrFuncCall.FollowSet.Add(TokenType.Read);
            AssignStatementOrFuncCall.FollowSet.Add(TokenType.Write);
            AssignStatementOrFuncCall.FollowSet.Add(TokenType.Return);
            AssignStatementOrFuncCall.FollowSet.Add(TokenType.Identifier);
            AssignStatementOrFuncCall.FollowSet.Add(TokenType.Else);
            AssignStatementOrFuncCall.FollowSet.Add(TokenType.SemiColon);

            OptionalInherits.FirstSet.Add(TokenType.Inherits);
            OptionalInherits.FollowSet.Add(TokenType.OpenCurlyBrace);

            BoolExpr.FirstSet.Add(TokenType.IntNum);
            BoolExpr.FirstSet.Add(TokenType.FloatNum);
            BoolExpr.FirstSet.Add(TokenType.OpenBrace);
            BoolExpr.FirstSet.Add(TokenType.Not);
            BoolExpr.FirstSet.Add(TokenType.Identifier);
            BoolExpr.FirstSet.Add(TokenType.Plus);
            BoolExpr.FirstSet.Add(TokenType.Minus);
            BoolExpr.FollowSet.Add(TokenType.CloseBrace);

            FuncDecl.FirstSet.Add(TokenType.OpenBrace);
            FuncDecl.FollowSet.Add(TokenType.Public);
            FuncDecl.FollowSet.Add(TokenType.Private);
            FuncDecl.FollowSet.Add(TokenType.CloseCurlyBrace);

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
            AddOp.FollowSet.Add(TokenType.IntNum);
            AddOp.FollowSet.Add(TokenType.FloatNum);
            AddOp.FollowSet.Add(TokenType.OpenBrace);
            AddOp.FollowSet.Add(TokenType.Not);
            AddOp.FollowSet.Add(TokenType.Identifier);
            AddOp.FollowSet.Add(TokenType.Plus);
            AddOp.FollowSet.Add(TokenType.Minus);

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
            FuncSig.FollowSet.Add(TokenType.Do);
            FuncSig.FollowSet.Add(TokenType.Local);

            FuncSigNamespace.FirstSet.Add(TokenType.ColonColon);
            FuncSigNamespace.FirstSet.Add(TokenType.OpenBrace);
            FuncSigNamespace.FollowSet.Add(TokenType.Do);
            FuncSigNamespace.FollowSet.Add(TokenType.Local);

            FuncSigExt.FirstSet.Add(TokenType.OpenBrace);
            FuncSigExt.FollowSet.Add(TokenType.Do);
            FuncSigExt.FollowSet.Add(TokenType.Local);

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
            CompareOp.FollowSet.Add(TokenType.IntNum);
            CompareOp.FollowSet.Add(TokenType.FloatNum);
            CompareOp.FollowSet.Add(TokenType.OpenBrace);
            CompareOp.FollowSet.Add(TokenType.Not);
            CompareOp.FollowSet.Add(TokenType.Identifier);
            CompareOp.FollowSet.Add(TokenType.Plus);
            CompareOp.FollowSet.Add(TokenType.Minus);

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
            ArithExpr.FollowSet.Add(TokenType.Minus);
            ArithExpr.FollowSet.Add(TokenType.EqualEqual);
            ArithExpr.FollowSet.Add(TokenType.LesserGreater);
            ArithExpr.FollowSet.Add(TokenType.Lesser);
            ArithExpr.FollowSet.Add(TokenType.Greater);
            ArithExpr.FollowSet.Add(TokenType.LesserEqual);
            ArithExpr.FollowSet.Add(TokenType.GreaterEqual);
            ArithExpr.FollowSet.Add(TokenType.CloseSquareBrace);
            ArithExpr.FollowSet.Add(TokenType.SemiColon);
            ArithExpr.FollowSet.Add(TokenType.Comma);
            ArithExpr.FollowSet.Add(TokenType.CloseBrace);

            Sign.FirstSet.Add(TokenType.Plus);
            Sign.FirstSet.Add(TokenType.Minus);
            Sign.FollowSet.Add(TokenType.IntNum);
            Sign.FollowSet.Add(TokenType.FloatNum);
            Sign.FollowSet.Add(TokenType.OpenBrace);
            Sign.FollowSet.Add(TokenType.Not);
            Sign.FollowSet.Add(TokenType.Identifier);
            Sign.FollowSet.Add(TokenType.Plus);
            Sign.FollowSet.Add(TokenType.Minus);

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
            VarFuncCall.FollowSet.Add(TokenType.Asterix);
            VarFuncCall.FollowSet.Add(TokenType.FwdSlash);
            VarFuncCall.FollowSet.Add(TokenType.And);
            VarFuncCall.FollowSet.Add(TokenType.Plus);
            VarFuncCall.FollowSet.Add(TokenType.Minus);
            VarFuncCall.FollowSet.Add(TokenType.Or);
            VarFuncCall.FollowSet.Add(TokenType.EqualEqual);
            VarFuncCall.FollowSet.Add(TokenType.LesserGreater);
            VarFuncCall.FollowSet.Add(TokenType.Lesser);
            VarFuncCall.FollowSet.Add(TokenType.Greater);
            VarFuncCall.FollowSet.Add(TokenType.LesserEqual);
            VarFuncCall.FollowSet.Add(TokenType.GreaterEqual);
            VarFuncCall.FollowSet.Add(TokenType.CloseSquareBrace);
            VarFuncCall.FollowSet.Add(TokenType.SemiColon);
            VarFuncCall.FollowSet.Add(TokenType.Comma);
            VarFuncCall.FollowSet.Add(TokenType.CloseBrace);

            Term.FirstSet.Add(TokenType.IntNum);
            Term.FirstSet.Add(TokenType.FloatNum);
            Term.FirstSet.Add(TokenType.OpenBrace);
            Term.FirstSet.Add(TokenType.Not);
            Term.FirstSet.Add(TokenType.Identifier);
            Term.FirstSet.Add(TokenType.Plus);
            Term.FirstSet.Add(TokenType.Minus);
            Term.FollowSet.Add(TokenType.Plus);
            Term.FollowSet.Add(TokenType.Minus);
            Term.FollowSet.Add(TokenType.Or);
            Term.FollowSet.Add(TokenType.EqualEqual);
            Term.FollowSet.Add(TokenType.LesserGreater);
            Term.FollowSet.Add(TokenType.Lesser);
            Term.FollowSet.Add(TokenType.Greater);
            Term.FollowSet.Add(TokenType.LesserEqual);
            Term.FollowSet.Add(TokenType.GreaterEqual);
            Term.FollowSet.Add(TokenType.CloseSquareBrace);
            Term.FollowSet.Add(TokenType.SemiColon);
            Term.FollowSet.Add(TokenType.Colon);
            Term.FollowSet.Add(TokenType.CloseBrace);

            MultOp.FirstSet.Add(TokenType.Asterix);
            MultOp.FirstSet.Add(TokenType.FwdSlash);
            MultOp.FirstSet.Add(TokenType.And);
            MultOp.FollowSet.Add(TokenType.IntNum);
            MultOp.FollowSet.Add(TokenType.FloatNum);
            MultOp.FollowSet.Add(TokenType.OpenBrace);
            MultOp.FollowSet.Add(TokenType.Not);
            MultOp.FollowSet.Add(TokenType.Identifier);
            MultOp.FollowSet.Add(TokenType.Plus);
            MultOp.FollowSet.Add(TokenType.Minus);

            Factor.FirstSet.Add(TokenType.IntNum);
            Factor.FirstSet.Add(TokenType.FloatNum);
            Factor.FirstSet.Add(TokenType.OpenBrace);
            Factor.FirstSet.Add(TokenType.Not);
            Factor.FirstSet.Add(TokenType.Identifier);
            Factor.FirstSet.Add(TokenType.Plus);
            Factor.FirstSet.Add(TokenType.Minus);
            Factor.FollowSet.Add(TokenType.Asterix);
            Factor.FollowSet.Add(TokenType.FwdSlash);
            Factor.FollowSet.Add(TokenType.And);
            Factor.FollowSet.Add(TokenType.Plus);
            Factor.FollowSet.Add(TokenType.Minus);
            Factor.FollowSet.Add(TokenType.Or);
            Factor.FollowSet.Add(TokenType.EqualEqual);
            Factor.FollowSet.Add(TokenType.LesserGreater);
            Factor.FollowSet.Add(TokenType.Lesser);
            Factor.FollowSet.Add(TokenType.Greater);
            Factor.FollowSet.Add(TokenType.LesserEqual);
            Factor.FollowSet.Add(TokenType.GreaterEqual);
            Factor.FollowSet.Add(TokenType.CloseSquareBrace);
            Factor.FollowSet.Add(TokenType.SemiColon);
            Factor.FollowSet.Add(TokenType.Comma);
            Factor.FollowSet.Add(TokenType.CloseBrace);

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
            RightTerm.FollowSet.Add(TokenType.LesserEqual);
            RightTerm.FollowSet.Add(TokenType.GreaterEqual);
            RightTerm.FollowSet.Add(TokenType.CloseSquareBrace);
            RightTerm.FollowSet.Add(TokenType.SemiColon);
            RightTerm.FollowSet.Add(TokenType.Comma);
            RightTerm.FollowSet.Add(TokenType.CloseBrace);

            TypeOrVoid.FirstSet.Add(TokenType.Void);
            TypeOrVoid.FirstSet.Add(TokenType.Identifier);
            TypeOrVoid.FirstSet.Add(TokenType.Integer);
            TypeOrVoid.FirstSet.Add(TokenType.Float);
            TypeOrVoid.FollowSet.Add(TokenType.SemiColon);
            TypeOrVoid.FollowSet.Add(TokenType.Do);
            TypeOrVoid.FollowSet.Add(TokenType.Local);

            TypeNoID.FirstSet.Add(TokenType.Integer);
            TypeNoID.FirstSet.Add(TokenType.Float);
            TypeNoID.FollowSet.Add(TokenType.SemiColon);
            TypeNoID.FollowSet.Add(TokenType.Do);
            TypeNoID.FollowSet.Add(TokenType.Local);
            TypeNoID.FollowSet.Add(TokenType.Identifier);

            ArraySize.FirstSet.Add(TokenType.OpenSquareBrace);
            ArraySize.FollowSet.Add(TokenType.OpenSquareBrace);
            ArraySize.FollowSet.Add(TokenType.CloseBrace);
            ArraySize.FollowSet.Add(TokenType.Comma);
            ArraySize.FollowSet.Add(TokenType.SemiColon);

            OptionalInt.FirstSet.Add(TokenType.IntNum);
            OptionalInt.FollowSet.Add(TokenType.CloseSquareBrace);

            FuncCallParamsRest.FirstSet.Add(TokenType.Comma);
            FuncCallParamsRest.FollowSet.Add(TokenType.Comma);
            FuncCallParamsRest.FollowSet.Add(TokenType.CloseBrace);

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
            Expression.FollowSet.Add(TokenType.Comma);
            Expression.FollowSet.Add(TokenType.CloseBrace);
            Expression.FollowSet.Add(TokenType.SemiColon);

            FuncCallParamsRests.FirstSet.Add(TokenType.Comma);
            FuncCallParamsRests.FollowSet.Add(TokenType.CloseBrace);

            VarDecl.FirstSet.Add(TokenType.Identifier);
            VarDecl.FollowSet.Add(TokenType.Do);
            VarDecl.FollowSet.Add(TokenType.Identifier);
            VarDecl.FollowSet.Add(TokenType.Integer);
            VarDecl.FollowSet.Add(TokenType.Float);
            VarDecl.FollowSet.Add(TokenType.Public);
            VarDecl.FollowSet.Add(TokenType.Private);
            VarDecl.FollowSet.Add(TokenType.CloseCurlyBrace);

            FuncBody.FirstSet.Add(TokenType.Do);
            FuncBody.FirstSet.Add(TokenType.Local);
            FuncBody.FollowSet.Add(TokenType.SemiColon);

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
            Statement.FollowSet.Add(TokenType.End);
            Statement.FollowSet.Add(TokenType.If);
            Statement.FollowSet.Add(TokenType.While);
            Statement.FollowSet.Add(TokenType.Read);
            Statement.FollowSet.Add(TokenType.Write);
            Statement.FollowSet.Add(TokenType.Return);
            Statement.FollowSet.Add(TokenType.Identifier);
            Statement.FollowSet.Add(TokenType.Else);
            Statement.FollowSet.Add(TokenType.SemiColon);

            FuncParamsRest.FirstSet.Add(TokenType.Comma);
            FuncParamsRest.FollowSet.Add(TokenType.Comma);
            FuncParamsRest.FollowSet.Add(TokenType.CloseBrace);

            Type.FirstSet.Add(TokenType.Identifier);
            Type.FirstSet.Add(TokenType.Integer);
            Type.FirstSet.Add(TokenType.Float);
            Type.FollowSet.Add(TokenType.SemiColon);
            Type.FollowSet.Add(TokenType.Identifier);
            Type.FollowSet.Add(TokenType.Do);
            Type.FollowSet.Add(TokenType.Local);

            ArrayDims.FirstSet.Add(TokenType.OpenSquareBrace);
            ArrayDims.FollowSet.Add(TokenType.CloseBrace);
            ArrayDims.FollowSet.Add(TokenType.Comma);
            ArrayDims.FollowSet.Add(TokenType.SemiColon);

            Index.FirstSet.Add(TokenType.OpenSquareBrace);
            Index.FollowSet.Add(TokenType.OpenSquareBrace);
            Index.FollowSet.Add(TokenType.Asterix);
            Index.FollowSet.Add(TokenType.FwdSlash);
            Index.FollowSet.Add(TokenType.And);
            Index.FollowSet.Add(TokenType.Plus);
            Index.FollowSet.Add(TokenType.Minus);
            Index.FollowSet.Add(TokenType.Or);
            Index.FollowSet.Add(TokenType.EqualEqual);
            Index.FollowSet.Add(TokenType.LesserGreater);
            Index.FollowSet.Add(TokenType.Lesser);
            Index.FollowSet.Add(TokenType.Greater);
            Index.FollowSet.Add(TokenType.LesserEqual);
            Index.FollowSet.Add(TokenType.GreaterEqual);
            Index.FollowSet.Add(TokenType.CloseSquareBrace);
            Index.FollowSet.Add(TokenType.Equal);
            Index.FollowSet.Add(TokenType.Period);
            Index.FollowSet.Add(TokenType.SemiColon);
            Index.FollowSet.Add(TokenType.Comma);
            Index.FollowSet.Add(TokenType.CloseBrace);

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
            Start.RHSSet.Add(new List<RuleBase>() { Program });
            Program.RHSSet.Add(new List<RuleBase>() { ClassDecls, FuncDefs, Main, FuncBody });
            ClassDecls.RHSSet.Add(new List<RuleBase>() { ClassDecl, ClassDecls });
            ClassDecl.RHSSet.Add(new List<RuleBase>() { Class, Identifier, OptionalInherits, OpenCurlyBrace, MemberDecls, CloseCurlyBrace, SemiColon });
            FuncDefs.RHSSet.Add(new List<RuleBase>() { FuncDef, FuncDefs });
            FuncDef.RHSSet.Add(new List<RuleBase>() { FuncSig, FuncBody, SemiColon });
            MemberDecls.RHSSet.Add(new List<RuleBase>() { Visibility, MemberDecl, MemberDecls });
            MemberDecl.RHSSet.Add(new List<RuleBase>() { Identifier, FuncOrVarDecl });
            MemberDecl.RHSSet.Add(new List<RuleBase>() { TypeNoID, VarDecl });
            FuncOrVarDecl.RHSSet.Add(new List<RuleBase>() { FuncDecl });
            FuncOrVarDecl.RHSSet.Add(new List<RuleBase>() { VarDecl });
            Visibility.RHSSet.Add(new List<RuleBase>() { Public });
            Visibility.RHSSet.Add(new List<RuleBase>() { Private });
            Statement.RHSSet.Add(new List<RuleBase>() { If, OpenBrace, BoolExpr, CloseBrace, Then, StatementBlock, Else, StatementBlock, SemiColon });
            Statement.RHSSet.Add(new List<RuleBase>() { While, OpenBrace, BoolExpr, CloseBrace, StatementBlock, SemiColon });
            Statement.RHSSet.Add(new List<RuleBase>() { Read, OpenBrace, StatementVar, CloseBrace, SemiColon });
            Statement.RHSSet.Add(new List<RuleBase>() { Write, OpenBrace, Expression, CloseBrace, SemiColon });
            Statement.RHSSet.Add(new List<RuleBase>() { Return, OpenBrace, Expression, CloseBrace, SemiColon });
            Statement.RHSSet.Add(new List<RuleBase>() { AssignStatementOrFuncCall });
            StatementVar.RHSSet.Add(new List<RuleBase>() { Identifier, StatementVarOrFuncCall });
            StatementVarOrFuncCall.RHSSet.Add(new List<RuleBase>() { Indices, StatementVarExt });
            StatementVarOrFuncCall.RHSSet.Add(new List<RuleBase>() { OpenBrace, FuncCallParams, CloseBrace, StatementFunctionCall });
            StatementVarExt.RHSSet.Add(new List<RuleBase>() { Period, StatementVar });
            StatementFunctionCall.RHSSet.Add(new List<RuleBase>() { Period, StatementVar });
            AssignStatementOrFuncCall.RHSSet.Add(new List<RuleBase>() { Identifier, VarOrFuncCallExt });
            VarOrFuncCallExt.RHSSet.Add(new List<RuleBase>() { Indices, VarExt });
            VarOrFuncCallExt.RHSSet.Add(new List<RuleBase>() { OpenBrace, FuncCallParams, CloseBrace, FuncCallExt });
            VarExt.RHSSet.Add(new List<RuleBase>() { Equal, Expression, SemiColon });
            VarExt.RHSSet.Add(new List<RuleBase>() { Period, AssignStatementOrFuncCall });
            FuncCallExt.RHSSet.Add(new List<RuleBase>() { SemiColon });
            FuncCallExt.RHSSet.Add(new List<RuleBase>() { Period, AssignStatementOrFuncCall });
            FuncParams.RHSSet.Add(new List<RuleBase>() { Type, Identifier, ArrayDims, FuncParamsRests });
            AddOp.RHSSet.Add(new List<RuleBase>() { Plus });
            AddOp.RHSSet.Add(new List<RuleBase>() { Minus });
            AddOp.RHSSet.Add(new List<RuleBase>() { Or });
            OptionalInherits.RHSSet.Add(new List<RuleBase>() { Inherits, Identifier, InheritedClasses });
            BoolExpr.RHSSet.Add(new List<RuleBase>() { ArithExpr, CompareOp, ArithExpr });
            FuncDecl.RHSSet.Add(new List<RuleBase>() { OpenBrace, FuncParams, CloseBrace, Colon, TypeOrVoid, SemiColon });
            FuncCallParamsRests.RHSSet.Add(new List<RuleBase>() { FuncCallParamsRest, FuncCallParamsRests });
            LocalScope.RHSSet.Add(new List<RuleBase>() { Local, VarDecls });
            ArrayDims.RHSSet.Add(new List<RuleBase>() { ArraySize, ArrayDims });
            Expression.RHSSet.Add(new List<RuleBase>() { ArithExpr, BoolExprOrNone });
            BoolExprOrNone.RHSSet.Add(new List<RuleBase>() { CompareOp, ArithExpr });
            Statements.RHSSet.Add(new List<RuleBase>() { Statement, Statements });
            ArithExpr.RHSSet.Add(new List<RuleBase>() { Term, RightArithExpr });
            RightArithExpr.RHSSet.Add(new List<RuleBase>() { AddOp, Term, RightArithExpr });
            FuncSig.RHSSet.Add(new List<RuleBase>() { Identifier, FuncSigNamespace });
            FuncSigNamespace.RHSSet.Add(new List<RuleBase>() { FuncSigExt });
            FuncSigNamespace.RHSSet.Add(new List<RuleBase>() { ColonColon, Identifier, FuncSigExt });
            FuncSigExt.RHSSet.Add(new List<RuleBase>() { OpenBrace, FuncParams, CloseBrace, Colon, TypeOrVoid });
            FuncParamsRests.RHSSet.Add(new List<RuleBase>() { FuncParamsRest, FuncParamsRests });
            InheritedClasses.RHSSet.Add(new List<RuleBase>() { Comma, Identifier, InheritedClasses });
            Sign.RHSSet.Add(new List<RuleBase>() { Plus });
            Sign.RHSSet.Add(new List<RuleBase>() { Minus });
            CompareOp.RHSSet.Add(new List<RuleBase>() { EqualEqual });
            CompareOp.RHSSet.Add(new List<RuleBase>() { LesserGreater });
            CompareOp.RHSSet.Add(new List<RuleBase>() { Lesser });
            CompareOp.RHSSet.Add(new List<RuleBase>() { Greater });
            CompareOp.RHSSet.Add(new List<RuleBase>() { LesserEqual });
            CompareOp.RHSSet.Add(new List<RuleBase>() { GreaterEqual });
            Index.RHSSet.Add(new List<RuleBase>() { OpenSquareBrace, ArithExpr, CloseSquareBrace });
            VarDecls.RHSSet.Add(new List<RuleBase>() { Type, VarDecl, VarDecls });
            Factor.RHSSet.Add(new List<RuleBase>() { VarFuncCall });
            Factor.RHSSet.Add(new List<RuleBase>() { IntNum });
            Factor.RHSSet.Add(new List<RuleBase>() { FloatNum });
            Factor.RHSSet.Add(new List<RuleBase>() { OpenBrace, ArithExpr, CloseBrace });
            Factor.RHSSet.Add(new List<RuleBase>() { Not, Factor });
            Factor.RHSSet.Add(new List<RuleBase>() { Sign, Factor });
            VarFuncCall.RHSSet.Add(new List<RuleBase>() { Identifier, VarOrFuncCall });
            VarOrFuncCall.RHSSet.Add(new List<RuleBase>() { Indices, FactorVar });
            VarOrFuncCall.RHSSet.Add(new List<RuleBase>() { OpenBrace, FuncCallParams, CloseBrace, FactorFuncCall });
            FactorVar.RHSSet.Add(new List<RuleBase>() { Period, VarFuncCall });
            FactorFuncCall.RHSSet.Add(new List<RuleBase>() { Period, VarFuncCall });
            Term.RHSSet.Add(new List<RuleBase>() { Factor, RightTerm });
            MultOp.RHSSet.Add(new List<RuleBase>() { Asterix });
            MultOp.RHSSet.Add(new List<RuleBase>() { FwdSlash });
            MultOp.RHSSet.Add(new List<RuleBase>() { And });
            RightTerm.RHSSet.Add(new List<RuleBase>() { MultOp, Factor, RightTerm });
            TypeOrVoid.RHSSet.Add(new List<RuleBase>() { Type });
            TypeOrVoid.RHSSet.Add(new List<RuleBase>() { Void });
            Type.RHSSet.Add(new List<RuleBase>() { TypeNoID });
            Type.RHSSet.Add(new List<RuleBase>() { Identifier });
            TypeNoID.RHSSet.Add(new List<RuleBase>() { Integer });
            TypeNoID.RHSSet.Add(new List<RuleBase>() { Float });
            ArraySize.RHSSet.Add(new List<RuleBase>() { OpenSquareBrace, OptionalInt, CloseSquareBrace });
            OptionalInt.RHSSet.Add(new List<RuleBase>() { IntNum });
            FuncCallParamsRest.RHSSet.Add(new List<RuleBase>() { Comma, Expression });
            FuncCallParams.RHSSet.Add(new List<RuleBase>() { Expression, FuncCallParamsRests });
            VarDecl.RHSSet.Add(new List<RuleBase>() { Identifier, ArrayDims, SemiColon });
            FuncBody.RHSSet.Add(new List<RuleBase>() { LocalScope, Do, Statements, End });
            StatementBlock.RHSSet.Add(new List<RuleBase>() { Do, Statements, End });
            StatementBlock.RHSSet.Add(new List<RuleBase>() { Statement });
            Indices.RHSSet.Add(new List<RuleBase>() { Index, Indices });
            FuncParamsRest.RHSSet.Add(new List<RuleBase>() { Comma, Type, Identifier, ArrayDims });

            #endregion

            return grammar;
        }
    }
}
