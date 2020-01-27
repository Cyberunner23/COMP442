﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using Lexer.DFA.XML;

namespace Lexer.DFA
{
    public class DFA
    {
        private List<char> _alphabet; 
        private Dictionary<string, List<char>> _letterMap;
        private Dictionary<char, string> _inverseLetterMap;

        // State ID <-> State
        private Dictionary<int, State> _states;
        private int _startStateID;
        private int _currentStateID;

        private Dictionary<int, StateTransitionRow> _transitionTable;

        public DFA()
        {
            _alphabet = new List<char>();
            _letterMap = new Dictionary<string, List<char>>();
            _inverseLetterMap = new Dictionary<char, string>();
            _states = new Dictionary<int, State>();

            _transitionTable = new Dictionary<int, StateTransitionRow>();
        }

        public void Begin()
        {
            _currentStateID = _startStateID;
        }

        public int GetNextStateID(char transition)
        {
            var transitionRow = _transitionTable[_currentStateID].GetTransitionTableRow();
            int nextStateID = transitionRow[transition];
            _currentStateID = nextStateID;
            return nextStateID;
        }

        public TokenType GetStateType(int id)
        {
            return _states[id].Type;
        }

        public bool IsBacktrackingState(int id)
        {
            return _states[id].IsBacktrackState;
        }

        public void LoafFromFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DFAXML));
            StreamReader reader = new StreamReader(filePath);
            var dfa = serializer.Deserialize(reader) as DFAXML;

            foreach (var alphabetItem in dfa.Alphabet)
            {
                string symbol = alphabetItem.Symbol;
                var letterList = new List<char>();
                foreach (var letter in alphabetItem.Letters)
                {
                    var character = letter.Char;

                    letterList.Add(character);
                    _alphabet.Add(character);
                    _inverseLetterMap.Add(character, symbol);
                }

                _letterMap.Add(symbol, letterList);
            }

            _letterMap.Add("EVERYTHING", _alphabet);
            _states = dfa.StateList.States.ToDictionary(x => x.ID, x => x);
            _startStateID = dfa.StateList.StartStateID;

            CreateTable(dfa);
        }

        private void CreateTable(DFAXML dfa)
        {
            // Init rows
            foreach (var stateID in _states.Keys)
            {
                _transitionTable.Add(stateID, new StateTransitionRow(_alphabet, _states[stateID].Type, _states[stateID].IsBacktrackState));
            }

            // Fill rows
            foreach (var transition in dfa.Transitions)
            {
                int src = transition.SourceID;
                int dst = transition.DestinationID;
                var transitionLetters = new List<char>();

                foreach (var symbol in transition.Symbols)
                {
                    var letters = _letterMap[symbol];
                    transitionLetters.AddRange(letters);
                }

                foreach (var excludedletter in transition.Except.Select(x => x.Char))
                {
                    if (transitionLetters.Contains(excludedletter))
                    {
                        transitionLetters.Remove(excludedletter);
                    }
                }

                _transitionTable[src].SetTransitions(dst, transitionLetters);
            }
        }
    }
}
