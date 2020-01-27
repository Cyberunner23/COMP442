namespace Lexer
{
    public enum TokenType
    {
        Error,
        Intermediate,
        EOF,

        Comment,           ///  //
        BlockComment,      ///  /**/

        Identifier,        //  letter alphanum*
        IntNum,            //  nonzero digit* | 0
        FloatNum,          //  integer fraction [e[+-] integer]

        Equal,             ///  =
        FwdSlash,          ///  /
        Asterix,           ///  *
        Minus,             ///  -
        Plus,              ///  +
        GreaterEqual,      ///  >=
        LesserEqual,       ///  <=
        Greater,           ///  >
        Lesser,            ///  <
        LesserGreater,     ///  <>
        EqualEqual,        ///  ==
        OpenBrace,         ///  (
        CloseBrace,        ///  )
        OpenCurlyBrace,    ///  {
        CloseCurlyBrace,   ///  }
        OpenSquareBrace,   ///  [
        CloseSquareBrace,  ///  ]
        SemiColon,         ///  ;
        Comma,             ///  ,
        Period,            ///  .
        Colon,             ///  :
        ColonColon,        ///  ::

        If,                //  if
        Then,              //  then
        Else,              //  else
        While,             //  while
        Class,             //  class
        Integer,           //  integer
        Float,             //  float
        Do,                //  do
        End,               //  end
        Public,            //  public
        Private,           //  private
        Or,                //  or
        And,               //  and
        Not,               //  not
        Read,              //  read
        Write,             //  write
        Return,            //  return 
        Main,              //  main
        Inherits,          //  inherits
        Local,             //  local

        InvalidIdentifier,
        InvalidIntNum,
        InvalidFloatNum,
        UnexpectedEOF
    }
}
