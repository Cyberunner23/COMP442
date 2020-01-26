using System;
using System.Collections.Generic;

namespace Lexer.DFA
{
    public class StateTransitionRow
    {
        private Dictionary<char, int> _transitionTableRow;
        private TokenType _stateType;
        private bool _isBacktrackingState;

        public StateTransitionRow(List<char> alphabet, TokenType stateType, bool isBacktrackingState)
        {
            _transitionTableRow = new Dictionary<char, int>();
            foreach (var letter in alphabet)
            {
                _transitionTableRow.Add(letter, 0);
            }

            _stateType = stateType;
            _isBacktrackingState = isBacktrackingState;
        }

        // src -> dst by transitionSymbols 
        public void SetTransitions(int destinationID, List<char> transitionLetters)
        {
            foreach (var letter in transitionLetters)
            {
                if (_transitionTableRow[letter] != 0)
                {
                    throw new InvalidOperationException($"Transition to this state {destinationID} alread set");
                }

                _transitionTableRow[letter] = destinationID;
            }
        }

        public Dictionary<char, int> GetTransitionTableRow()
        {
            return _transitionTableRow;
        }
    }
}
