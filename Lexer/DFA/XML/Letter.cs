using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Lexer.DFA.XML
{
    public class Letter
    {
        [XmlIgnore]
        public char Char { get; set; }

        [XmlAttribute(nameof(Char)), Browsable(false)]
        public string CharString
        {
            get { return Char.ToString(); }
            set { Char = value.Single(); }
        }
    }
}
