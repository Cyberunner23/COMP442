namespace Lexer
{
    public class Token
    {
        public TokenType TokenType { get; set; }
        public string Lexeme { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }
}
