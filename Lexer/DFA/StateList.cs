using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Lexer.DFA
{
    [Serializable]
    public class StateList
    {
        [XmlArray(nameof(States))]
        [XmlArrayItem("State", typeof(State))]
        public List<State> States { get; set; }

        [XmlAttribute]
        public int StartStateID { get; set; } = 0;
    }
}
