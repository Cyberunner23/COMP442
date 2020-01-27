using System.Collections.Generic;
using System.Xml.Serialization;

namespace Lexer.DFA.XML
{
    [XmlRoot("DFA")]
    public class DFAXML
    {
        [XmlArray("Alphabet")]
        [XmlArrayItem("AlphabetItem", typeof(AlphabetItem))]
        public List<AlphabetItem> Alphabet { get; set; }

        [XmlElement]
        public StateList StateList { get; set; }

        [XmlArray("Transitions")]
        [XmlArrayItem("Transition", typeof(Transition))]
        public List<Transition> Transitions { get; set; }
    }
}
