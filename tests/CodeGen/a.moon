
% Start of the program
    align 
    entry 

% Set stack pointer to initial value (baseaddr)
    addi r14,r14,baseAddr

% Set FSP for main function
    addi r14,r14,24

main

% While Loop

WhileBranch_begin_0

% Init const int value 0 (38:9)
    sub r1,r1,r1
    addi r1,r1,0
    sw -20(r14),r1

% Init const int value 1 (38:13)
    sub r1,r1,r1
    addi r1,r1,1
    sw -24(r14),r1

% CompareOp (GreaterThan)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r1,-20(r14)
    lw r2,-24(r14)
    cgt r3,r1,r2
    sw -16(r14),r3
    sub r1,r1,r1
    lw r1,-16(r14)
    bz r1,WhileBranch_end_0
    j WhileBranch_begin_0

WhileBranch_end_0

% Program footer
    hlt 

baseAddr
