using System.Xml.Serialization;

namespace Lexer.DFA.XML
{
    public class Keyword
    {
        [XmlAttribute]
        public string Identifier { get; set; }

        [XmlAttribute]
        public TokenType Token { get; set; }
    }
}
