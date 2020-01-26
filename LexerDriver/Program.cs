using Lexer;
using Lexer.DFA;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LexerDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            /*DFAXML dfa = new DFAXML();
            dfa.Transitions = new List<Transition>()
            {
                new Transition()
                {
                    SourceID = 1,
                    DestinationID = 2,
                    Symbols = new List<string>()
                    {
                        "LETTER"
                    },
                    Except = new List<Letter>()
                    {
                        new Letter()
                        {
                            Char = 'A'
                        },
                        new Letter()
                        {
                            Char = '_'
                        }
                    }
                }
            };

            XmlSerializer serializer = new XmlSerializer(typeof(DFAXML));
            TextWriter writer = new StreamWriter("test.xml");
            serializer.Serialize(writer, dfa);*/

            DFA dfa = new DFA();
            dfa.LoafFromFile("DFA.xml");
        }
    }
}
