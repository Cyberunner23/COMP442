using Lexer;
using System;
using System.Collections.Generic;
using System.IO;

namespace ParserDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please provide input file");
                Environment.Exit(-1);
            }

            string inputText = File.ReadAllText(args[0]);
            string fileName = Path.GetFileNameWithoutExtension(args[0]);

            Lexer.Lexer lex = new Lexer.Lexer(inputText);

            List<Token> tokensToParse = new List<Token>();

            using (StreamWriter tokenFile = new StreamWriter($"{fileName}.outlextokens"))
            using (StreamWriter tokenErrorFile = new StreamWriter($"{fileName}.outlexerrors"))
            {
                Token t;
                do
                {
                    t = lex.GetNextToken();
                    Console.WriteLine(t.ToString());

                    if (lex.IsErrorToken(t.TokenType))
                    {
                        tokenErrorFile.WriteLine(t.ToString());
                    }
                    else
                    {
                        tokenFile.WriteLine(t.ToString());
                        tokensToParse.Add(t);
                    }
                }
                while (t.TokenType != TokenType.EOF);

                tokensToParse.RemoveAll(x => lex.IsCommentToken(x.TokenType));
            }

            // Do parsing
        }
    }
}
