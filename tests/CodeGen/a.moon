
% Start of the program
    align 
    entry 

% Set stack pointer to initial value (baseaddr)
    addi r14,r14,baseAddr

% Set FSP for main function
    addi r14,r14,76

main

% Init const int value 3 (32:17)
    sub r1,r1,r1
    addi r1,r1,3
    sw -44(r14),r1

% Init const int value 2 (32:20)
    sub r1,r1,r1
    addi r1,r1,2
    sw -48(r14),r1

% Init const int value 2 (33:14)
    sub r1,r1,r1
    addi r1,r1,2
    sw -52(r14),r1

% Init const int value 0 (36:13)
    sub r1,r1,r1
    addi r1,r1,0
    sw -64(r14),r1

% Init const int value 1 (36:9)
    sub r1,r1,r1
    addi r1,r1,1
    sw -68(r14),r1

% AddOp (Add) at (36 : 11)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-64(r14)
    lw r3,-68(r14)
    add r1,r2,r3
    sw -60(r14),r1

% Init const int value 0 (36:16)
    sub r1,r1,r1
    addi r1,r1,0
    sw -72(r14),r1

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r14
    addi r1,r1,-32

% Computing address from array index
    sub r2,r2,r2
    addi r2,r2,4
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5

% Computing for 0th index
    addi r3,r3,1
    sub r5,r5,r5
    addi r5,r5,1
    lw r4,-72(r14)
    mul r5,r4,r2
    mul r5,r5,r3
    add r1,r1,r5

% Computing for 1th index
    muli r3,r3,2
    sub r5,r5,r5
    addi r5,r5,1
    lw r4,-60(r14)
    mul r5,r4,r2
    mul r5,r5,r3
    add r1,r1,r5

% Storing final address
    sw -56(r14),r1

% Init const int value 5 (36:21)
    sub r1,r1,r1
    addi r1,r1,5
    sw -76(r14),r1

% Assignment
    sub r1,r1,r1
    sub r2,r2,r2
    lw r1,-56(r14)
    lw r2,-76(r14)
    sw 0(r1),r2

% Program footer
    hlt 

baseAddr
