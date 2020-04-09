using System;
using System.Collections.Generic;
using System.IO;
using CodeGen;
using Lexer;
using Parser.ASTVisitor.Visitors;

namespace CodeGenDriver
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

            string filePath = $@"{Environment.CurrentDirectory}\{args[0]}";
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string fileDirectory = Path.GetDirectoryName(filePath);
            string inputText = File.ReadAllText(filePath);

            Lexer.Lexer lex = new Lexer.Lexer(inputText);

            List<Token> tokensToParse = new List<Token>();

            using (StreamWriter tokenFile = new StreamWriter($@"{fileDirectory}\{fileName}.outlextokens"))
            using (StreamWriter tokenErrorFile = new StreamWriter($@"{fileDirectory}\{fileName}.outlexerrors"))
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

            using (StreamWriter astStream = new StreamWriter($@"{fileDirectory}\{fileName}.outast"))
            using (StreamWriter derivationsStream = new StreamWriter($@"{fileDirectory}\{fileName}.outderivation"))
            using (StreamWriter syntaxErrorStream = new StreamWriter($@"{fileDirectory}\{fileName}.outsyntaxerrors"))
            using (StreamWriter symbolTablesStream = new StreamWriter($@"{fileDirectory}\{fileName}.outsymboltables"))
            using (StreamWriter semanticErrorStream = new StreamWriter($@"{fileDirectory}\{fileName}.outsemanticerrors"))
            using (StreamWriter codeGenOutput = new StreamWriter($@"{fileDirectory}\{fileName}.moon"))
            {
                // Do parsing
                Parser.Parser parser = new Parser.Parser(tokensToParse, syntaxErrorStream, derivationsStream, astStream);
                Console.WriteLine(parser.Parse());
                var tree = parser.GetASTTree();

                var printVisitor = new DOTPrinterVisitor(astStream);
                tree.Accept(printVisitor);
                astStream.Flush();

                var symbolTableVisitor = new SymbolTableVisitor(semanticErrorStream);
                tree.Accept(symbolTableVisitor);

                var semanticCheckerVisitor = new SemanticCheckerVisitor(semanticErrorStream, symbolTableVisitor.GlobalSymbolTable);
                tree.Accept(semanticCheckerVisitor);

                syntaxErrorStream.Flush();
                semanticErrorStream.Flush();
                bool hasErrors = semanticErrorStream.BaseStream.Length != 0 || syntaxErrorStream.BaseStream.Length != 0;
                if (hasErrors)
                {
                    Console.WriteLine("Errors generated during parsing, skipping codegen.");
                    Environment.Exit(-10);
                }

                // Codegen
                codeGenOutput.NewLine = "\n";
                var codeWriter = new CodeWriter(codeGenOutput);
                var codeGen = new CodeGen.CodeGen(tree, symbolTableVisitor.GlobalSymbolTable, codeWriter);
                codeGen.GenerateCode();

                symbolTablesStream.WriteLine(symbolTableVisitor.GlobalSymbolTable);
                Console.WriteLine(symbolTableVisitor.GlobalSymbolTable);
            }
        }
    }
}
