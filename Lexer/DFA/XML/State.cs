using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Lexer.DFA.XML
{
    public class State
    {
        [XmlAttribute]
        public int ID { get; set; }

        [XmlIgnore]
        public TokenType Type { get; set; } = TokenType.Error;

        [XmlAttribute(nameof(Type))]
        public string TypeString 
        {
            get { return Type.ToString(); }
            set { Type = (TokenType)Enum.Parse(typeof(TokenType), value); } 
        }

        [XmlAttribute]
        [DefaultValue(typeof(bool), "False")]
        public bool IsBacktrackState { get; set; }
    }
}
