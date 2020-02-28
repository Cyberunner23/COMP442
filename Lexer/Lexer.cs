using System;
using System.Linq;

namespace Lexer
{
    public class Lexer
    {
        private const string DFA_FILE_PATH = "DFA.xml";

        private DFA.DFA _dfa;

        private string _inputCode;
        private int _currentInputIndex = 0;
        private int _currentLine = 1;
        private int _currentColumn = 0;

        public Lexer(string inputCode)
        {
            _inputCode = inputCode;

            // Load config, generate table
            _dfa = new DFA.DFA();
            _dfa.LoadFromFile(DFA_FILE_PATH);
        }

        public bool IsErrorToken(TokenType tokenType)
        {
            return tokenType == TokenType.InvalidComment
                || tokenType == TokenType.InvalidFloatNum
                || tokenType == TokenType.InvalidIdentifier
                || tokenType == TokenType.InvalidIntNum
                || tokenType == TokenType.InvalidCharacter
                || tokenType == TokenType.Error;
        }

        public bool IsCommentToken(TokenType tokenType)
        {
            return tokenType == TokenType.Comment
                || tokenType == TokenType.BlockComment;
        }

        public Token GetNextToken()
        {
            var token = new Token() { StartColumn = _currentColumn + 1, StartLine = _currentLine };
            TokenType lastErrorToken = TokenType.Error;

            if (_currentInputIndex >= _inputCode.Length)
            {
                token.TokenType = TokenType.EOF;
                return token;
            }

            TokenType type = TokenType.Intermediate;
            int stateID = 0;
            int previousCol = 0;
            int previousRow = 0;
            bool startPosSet = false;
            _dfa.Begin();
            do
            {
                char currentChar = _currentInputIndex < _inputCode.Length ? _inputCode.ElementAt(_currentInputIndex) : '~'; // Insert EOF tag if past end of input
                if (!_dfa.IsCharacterInAlphabet(currentChar))
                {
                    _currentInputIndex++;
                    continue;
                }

                if (!startPosSet && !char.IsWhiteSpace(currentChar))
                {
                    token.StartColumn = _currentColumn + 1;
                    token.StartLine = _currentLine;
                    startPosSet = true;
                }

                previousCol = _currentColumn;
                previousRow = _currentLine;
                if (currentChar == '\n')
                {
                    _currentColumn = 0;
                    _currentLine++;
                }
                else
                {
                    _currentColumn++;
                }

                if (stateID == 1 && currentChar == '~')
                {
                    type = TokenType.EOF;
                    continue;
                }

                lastErrorToken = _dfa.GetErrorType(stateID);
                stateID = _dfa.GetNextStateID(currentChar);
                type = _dfa.GetStateType(stateID);

                token.Lexeme += currentChar;
                _currentInputIndex++;
            }
            while (type == TokenType.Intermediate);

            if (_dfa.IsBacktrackingState(stateID))
            {
                _currentInputIndex--;
                _currentColumn = previousCol;
                _currentLine = previousRow;
                token.Lexeme = token.Lexeme.Remove(token.Lexeme.Length - 1, 1);
                // undo col row position change
            }

            token.Lexeme = token.Lexeme.Trim().Replace("~", "");
            //token.StartLine = _currentLine;
            //token.StartColumn = _currentColumn;
            token.TokenType = type;

            if (token.TokenType == TokenType.Identifier)
            {
                var keywordMapping = _dfa.GetKeywordMapping();
                TokenType keywordToken = TokenType.Intermediate;
                if (keywordMapping.TryGetValue(token.Lexeme, out keywordToken))
                {
                    token.TokenType = keywordToken;
                }
            }

            if (token.TokenType == TokenType.Error)
            {
                token.TokenType = lastErrorToken;
            }

            return token;
        }
    }
}
