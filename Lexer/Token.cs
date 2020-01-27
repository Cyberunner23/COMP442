namespace Lexer
{
    public class Token
    {
        public TokenType TokenType { get; set; }
        public string Lexeme { get; set; }
        public int StartLine { get; set; }
        public int StartColumn { get; set; }

        public override string ToString()
        {
            return $"[{TokenType} : ({StartLine},{StartColumn}) : \"{Lexeme}\"]";
        }
    }
}
