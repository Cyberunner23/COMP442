using System.Collections.Generic;
using System.Xml.Serialization;

namespace Lexer.DFA.XML
{
    public class AlphabetItem
    {
        [XmlArrayItem("Letter", typeof(Letter))]
        public List<Letter> Letters { get; set; }

        [XmlAttribute("Symbol")]
        public string Symbol { get; set; }
    }
}
