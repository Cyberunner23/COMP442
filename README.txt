Assignment #1


1. Lexical Specification
The specification used is exactly the same as the one in the assignment with the addition of regex expressions for special characters.
note that E symbolizes Sigma (all characters in the alphabet)

nonzero -> 1..9
digit -> 0..9
letter -> a..z | A..Z
alphanum -> letter | digit | _
integer -> nonzero digit* | 0
fraction -> .digit* nonzero | .0
float -> integer fraction [e[+|-] integer]
id -> letter alphanum*
comment -> //E*\n
blockcomment -> /\*E*\*/
equalequal -> ==
geaterlesser -> <>
lesser -> <
greater -> >
lesserequal -> <=
greaterequal -> >=
plus -> +
minus -> -
asterix -> *
forwardshash -> /
equal -> =
openbrace -> (
closebrace -> )
opencurlybrace -> {
closecurlybrace -> }
opensquarebrace -> [
closesquarebrace -> ]
semicolon -> ;
comma -> ,
period -> .
colon -> :
colon colon -> ::

2. FSM
View FSM.svg

3. Design
There are to projects, one is the lexer DLL and the other is the driver executable, all the lexer logic is in the DLL
and the driver reads the file and geneated the outlextoken and outlexerrors file using the lexer.
The lexer DLL has an implementation of a DFA. The DFA is loaded from an XML file, files in the Lexer/XML subdirectory are used for the XML deserializzation.
Once the file is loaded a transition table is built, the DFA is then ready to be used by the lexer.

4. Use of tools

I created a DFA by hand using draw.io, once the XML and DFA code was done I described the DFA in XML. 
I did not use regex to DFA tools.

In short I used draw.io to create the DFA diagram and C#'s XML serializarion to load the DFA in XML format.



5. Running the code
All binaries are in the bin directory.

LexerDriver.exe is the executable that runs the lexer on the file contents.

LexerDriver.exe <filename>

Test cases are in the bin folder as well, the one I created is called 


