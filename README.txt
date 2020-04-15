Assignment #4

1. Analysis

In terms of the implementation, I implemented everything except floating point nubmers
and passing arrays to functions with unsized array parameters, i.e. function(integer a[])

NOTE: values are pass by copy and not pass by reference, hence I need to know the size of parameters
      at compile time.

2. Design

The code generation is implemented in 3 phases
 - SizeCalculation (implemented in SizeCalculator.cs)
 - IntermediateSizeCalculation (implemented in IntermediateSizeCalculatorVisitor.cs)
 - CodeGenration (implemented in CodeGenerator.cs)
 
2.1 SizeCalculation
    Size calculation goes through the symbol tables and creates a MamoryLayout.
	The MamoryLayout is used to store the size of variables and their offsets.
	ClassSymbolTables and FunctionSymbolTables have one.
	The Size calculator also populates these Layouts
	
2.2 IntermediateSizeCalculation
	Intermediate size calculation goes through the AST tree and adds additional entries to the 
	MamoryLayout for functions, these entries are temporary variables used in various calculations
	including complex expressions and passing pointers to pieces of memory.
	
NOTE: The MamoryLayouts dictate the size and layout of the Frames, view "4. Stack Layout" below.

2.3 CodeGenration
    Code Generation goes through the AST tree and writes out the actual code based on data found in 
	SymbolTables, MamoryLayouts and sometimes even temporary variables.
	
NOTE: I also have various utilities to help with writing functions and keeping track of registers.


3. Use of tools

In terms of libraries used, I based my read and write functions based off 
the implementation found in util.m of the samples for the moon processor.



4. Stack Layout
============

| Address | Value (4 bytes)                        |

|   M     | topaddr                                |
|   M - 4 | Last Usable Memory Address             |  Stack grows upward (in ascending address)  
|   ...   |                   ...                  |
|   ...   | Stack Frames                           |  
|   ...   |                   ...                  |
|   B     | baseaddr (Bottom of the stack)         |
|   B - 4 | Last bytes of code                     |
|   ...   |                   ...                  |  
|   8     | Code                                   |
|   4     | Code                                   | Code executes upward (in ascending address)
|   0     | Code                                   |  



Register Layout
===============

NOTE: GPR => General Purpose Register 

R0: GPR,  R4: GPR,  R8:  GPR,  R12: CallChainPointer
R1: GPR,  R5: GPR,  R9:  GPR,  R13: Return Value Pointer
R2: GPR,  R6: GPR,  R10: GPR,  R14: Frame Stack Pointer (FSP)
R3: GPR,  R7: GPR,  R11: GPR,  R15: Return Address

NOTE: r14 is refered to as FSPReg in the code



Frame Stack Layout
==================

| Address  | Value (4 bytes)                              | 
|   M      | topaddr (Top of the Stack)                   |
|   M - 4  | Last Usable Memory Address                   |
|    ...   |                     ...                      |   More Stack Frames
| * K      | Bottom of previous frame                     | * Stack Pointer points to K (R14 = K)
| -------- | -------------------------------------------- |
|   K - 4  | Return Address (Top of frame)                |
|   K - 8  | Address to self (0 if not a member function) |
|   K - 12 | Argument 1                                   |
|   K - 16 | Argument 2                                   |   A Specific Stack Frame
|   K - 20 | Variable 1                                   |
|   K - 24 | Variable 2                                   |
|   K - 28 | Temporary Variable 1                         |
|   K - 32 | Temporary Variable 2 (Bottom of frame)       |
| -------- | -------------------------------------------- |
|    ...   |                     ...                      |   Some Stack Frames
|   B      | baseaddr (Bottom of the stack)               |
|   B - 4  | zeroval (constant 0)                         |
|   B - 8  | Last bytes of code                           |
|    ...   |                     ...                      |
|   8      | Code                                         |
|   4      | Code                                         |
|   0      | Code                                         |

Stack size is known at compile time, therefore, no need for a Base Pointer like in x86.
When popping a stack frame, suffice to move the Stack Pointer to the bottom of the popped Stack Frame












