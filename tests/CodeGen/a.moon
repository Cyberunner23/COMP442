
% Start of the program
    align 
    entry 

% Set stack pointer to initial value (baseaddr)
    addi r14,r14,baseAddr

% Set FSP for main function
    addi r14,r14,40

main

% If Statement

% Init const int value 2 (38:6)
    sub r1,r1,r1
    addi r1,r1,2
    sw -20(r14),r1

% Init const int value 1 (38:10)
    sub r1,r1,r1
    addi r1,r1,1
    sw -24(r14),r1

% CompareOp (LessThan)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r1,-20(r14)
    lw r2,-24(r14)
    clt r3,r1,r2
    sw -16(r14),r3
    sub r1,r1,r1
    lw r1,-16(r14)
    bz r1,IfBranch_false_0

IfBranch_true_0

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r14
    addi r1,r1,-12

% Storing final address
    sw -28(r14),r1

% Init const int value 1 (41:13)
    sub r1,r1,r1
    addi r1,r1,1
    sw -32(r14),r1

% Assignment
    sub r1,r1,r1
    sub r2,r2,r2
    lw r1,-28(r14)
    lw r2,-32(r14)
    sw 0(r1),r2
    j IfBranch_end_0

IfBranch_false_0

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r2,r2,r2
    add r2,r2,r14
    addi r2,r2,-12

% Storing final address
    sw -36(r14),r2

% Init const int value 2 (45:10)
    sub r2,r2,r2
    addi r2,r2,2
    sw -40(r14),r2

% Assignment
    sub r2,r2,r2
    sub r1,r1,r1
    lw r2,-36(r14)
    lw r1,-40(r14)
    sw 0(r2),r1

IfBranch_end_0

% Program footer
    hlt 

baseAddr
