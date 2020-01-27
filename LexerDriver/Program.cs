using System;

using Lexer;

namespace LexerDriver
{
    class Program
    {
        static void Main(string[] args)
        {

            Lexer.Lexer lex = new Lexer.Lexer("(){}[];,*+-. sdfg");

            Token t;
            do
            {
                t = lex.GetNextToken();
                Console.WriteLine(t.ToString());
            }
            while (t.TokenType != TokenType.EOF);
        }
    }
}
