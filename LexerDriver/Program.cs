using System;
using System.IO;
using Lexer;

namespace LexerDriver
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

            using (StreamWriter tokenFile = new System.IO.StreamWriter($"{fileName}.outlextokens"))
            using (StreamWriter tokenErrorFile = new System.IO.StreamWriter($"{fileName}.outlexerrors"))
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
                    }
                }
                while (t.TokenType != TokenType.EOF);
            }
        }
    }
}
