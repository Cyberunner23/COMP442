Assignment #4



Stack Layout
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
R1: GPR,  R5: GPR,  R9:  GPR,  R13: Return Value
R2: GPR,  R6: GPR,  R10: GPR,  R14: Stack Pointer
R3: GPR,  R7: GPR,  R11: GPR,  R15: Return Address



Stack Frame Layout
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












