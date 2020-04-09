
% Start of the program
    align 
    entry 

% Set stack pointer to initial value (baseaddr)
    add r14,r14,baseAddr

% Set FSP for main function
    addi r14,r14,48

main

% Init const int value 3 (35:15)
    sub r0,r0,r0
    addi r0,r0,3
    sw -28(r14),r0

% Init const int value 5 (35:11)
    sub r0,r0,r0
    addi r0,r0,5
    sw -32(r14),r0

% AddOp (Subtract) at (35 : 13)
    sub r0,r0,r0
    sub r1,r1,r1
    sub r2,r2,r2
    lw r1,-28(r14)
    lw r2,-32(r14)
    sub r0,r1,r2
    sw -24(r14),r0

% Init const int value 8 (36:12)
    sub r0,r0,r0
    addi r0,r0,8
    sw -44(r14),r0

% Init const int value 7 (36:8)
    sub r0,r0,r0
    addi r0,r0,7
    sw -48(r14),r0

% MultOp (Divide) at (36 : 10)
    sub r0,r0,r0
    sub r1,r1,r1
    sub r2,r2,r2
    lw r1,-44(r14)
    lw r2,-48(r14)
    div r0,r2,r1
    sw -40(r14),r0

% Program footer

zeroval
    dw 0

baseAddr
