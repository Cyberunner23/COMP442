using System.Linq;

namespace Lexer
{
    public class Lexer
    {
        private const string DFA_FILE_PATH = "DFA.xml";

        private DFA.DFA _dfa;

        private string _inputCode;
        private int _currentInputIndex = 0;
        private int _currentLine = 0;
        private int _currentColumn = 0;

        public Lexer(string inputCode)
        {
            _inputCode = inputCode;

            // Load config, generate table
            _dfa = new DFA.DFA();
            _dfa.LoafFromFile(DFA_FILE_PATH);
        }

        public Token GetNextToken()
        {
            var token = new Token() { StartColumn = _currentColumn, StartLine = _currentLine };

            if (_currentInputIndex >= _inputCode.Length)
            {
                token.TokenType = TokenType.EOF;
                return token;
            }

            TokenType type = TokenType.Intermediate;
            int stateID;
            _dfa.Begin();
            do
            {
                char currentChar =  _currentInputIndex < _inputCode.Length ? _inputCode.ElementAt(_currentInputIndex) : '~'; // Insert EOF tag if past end of input
                if (currentChar == '\n')
                {
                    _currentColumn = 0;
                    _currentLine++;
                }
                else
                {
                    _currentColumn++;
                }

                stateID = _dfa.GetNextStateID(currentChar);
                type = _dfa.GetStateType(stateID);

                token.Lexeme += currentChar;
                _currentInputIndex++;
            }
            while (type == TokenType.Intermediate);

            if (_dfa.IsBacktrackingState(stateID))
            {
                _currentInputIndex--;
                token.Lexeme = token.Lexeme.Remove(token.Lexeme.Length - 1, 1);
                // undo col row position change
            }

            token.TokenType = type;
            return token;
        }
    }
}
