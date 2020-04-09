
% Start of the program
    align 
    entry 

% Set stack pointer to initial value (baseaddr)
    addi r14,r14,baseAddr

% Set FSP for main function
    addi r14,r14,68

main

% Init const int value 5 (35:42)
    sub r0,r0,r0
    addi r0,r0,5
    sw -32(r14),r0

% Init const int value 4 (35:40)
    sub r0,r0,r0
    addi r0,r0,4
    sw -36(r14),r0

% MultOp (Multiply) at (35 : 41)
    sub r0,r0,r0
    sub r1,r1,r1
    sub r2,r2,r2
    lw r1,-32(r14)
    lw r2,-36(r14)
    mul r0,r2,r1
    sw -28(r14),r0

% Init const int value 3 (35:35)
    sub r0,r0,r0
    addi r0,r0,3
    sw -40(r14),r0

% AddOp (Add) at (35 : 37)
    sub r0,r0,r0
    sub r1,r1,r1
    sub r2,r2,r2
    lw r1,-28(r14)
    lw r2,-40(r14)
    add r0,r1,r2
    sw -24(r14),r0

% Init const int value 1 (35:29)
    sub r0,r0,r0
    addi r0,r0,1
    sw -52(r14),r0

% Not at (35:25)
    sub r0,r0,r0
    sub r1,r1,r1
    lw r0,-52(r14)
    not r1,r0
    sw -48(r14),r1

% Init const int value 2 (35:20)
    sub r0,r0,r0
    addi r0,r0,2
    sw -64(r14),r0

% SignNode 'Minus' at (35:19)
    sub r0,r0,r0
    sub r1,r1,r1
    lw r0,-64(r14)
    sub r1,r1,r0
    sw -60(r14),r1

% Init const int value 30 (35:14)
    sub r0,r0,r0
    addi r0,r0,30
    sw -68(r14),r0

% MultOp (Multiply) at (35 : 17)
    sub r0,r0,r0
    sub r1,r1,r1
    sub r2,r2,r2
    lw r1,-60(r14)
    lw r2,-68(r14)
    mul r0,r2,r1
    sw -56(r14),r0

% MultOp (Divide) at (35 : 23)
    sub r0,r0,r0
    sub r1,r1,r1
    sub r2,r2,r2
    lw r1,-48(r14)
    lw r2,-56(r14)
    div r0,r2,r1
    sw -44(r14),r0

% MultOp (Divide) at (35 : 32)
    sub r0,r0,r0
    sub r1,r1,r1
    sub r2,r2,r2
    lw r1,-24(r14)
    lw r2,-44(r14)
    div r0,r2,r1
    sw -20(r14),r0

% Program footer
    hlt 

baseAddr
