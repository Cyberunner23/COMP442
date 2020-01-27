using System.Collections.Generic;
using System.Xml.Serialization;

namespace Lexer.DFA.XML
{
    public class Transition
    {
        [XmlAttribute(nameof(SourceID))]
        public int SourceID { get; set; }
        
        [XmlAttribute(nameof(DestinationID))]
        public int DestinationID { get; set; }

        [XmlArray(nameof(Symbols))]
        [XmlArrayItem("Symbol", typeof(string))]
        public List<string> Symbols { get; set; }

        [XmlArray(nameof(Except))]
        [XmlArrayItem("Letter", typeof(Letter))]
        public List<Letter> Except { get; set; }
    }
}
