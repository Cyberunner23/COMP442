Assignment #2

NOTE: The assignment is not fully completed, The parser is done but I did not have the time to fully create the AST tree,
      I am missing some AST nodes and adding semantic rules for them in the grammar.

1. LL1 Grammar

The grammar is stored in docs/grammar.grm

2. First and follow sets
The first and follow sets are in data/FirstFollowSets.txt

3. Design
The solution has 2 additonal projects, Parser and ParserDriver.

ParserDriver:
Uses the Lexer and Parser projects, uses the Lexer to get tokens from the file.
It then passes on the tokens to the parser which validates the program and generates an AST tree.

Parser:
The parser is a recursive descent parser with a generic parse function. Instead of having a function per nonterminal, there is one parse
function that uses a grammar described in code. The Parser is in Parser.cs and all code relating to the grammar as well as the grammar itself
desctibed in code is found in the Grammar folder in the Parser project.

For the AST Tree, there are 3 folders, AST, ASTBuilder, ASTVisitor. 
The AST is build with 4 types of rules. DownScope, which goes down a semantic scope, UpScope, which brings the node in the scope and brings
it to the next scope up, MakeFamily which takes all the nodes in the scope, and makes a parent child relationship with the last node in the scope
as the parent. Finally the MakeNode rules, which creates the node in the AST. There is one rule per type of node.

The semantic scope is implemented with a stack of stacks of ASTNodeBase.
ASTNodeBase is the base class for AST nodes, it includes methods for adding siblings, children and so on.

AST contains the code for the AST nodes, they derive from ASTNodeBase as well as MakeNodeRule.
ASTBuilder contains the ASTBuilder class, which is used in Parser.cs to handle semantic rules found in the grammar, as well as
the semantic rules themselves.

ASTVisitor contains the base classes for a Visitor pattern as well as a visitor to print out the AST in DOT format.

The outast files which are outputted by the parser are in DOT format from GraphViz.

A render of the ASTs are found in the docs directory, note that the AST generation is not complete. The files are in PNG format.

4. Use of tools

I used ucalgary's tool to convert the grammar and generate the first and follor sets.
The rest of the code is simply C# code I wrote, including the DOT printer visitor.

5. Running the code
All binaries are in the bin directory.

ParserDriver.exe is the executable that runs the parser on the file contents.

ParserDriver.exe <filename>

Test cases are in the bin folder as well, the one I created are called polynomialOK.src, polynomialError.src, tests.src, tests2.src


