
% Start of the program
    align 
    entry 

% Set stack pointer to initial value (baseaddr)
    addi r14,r14,baseAddr

C1_func_integer_C1
    sw -4(r14),r15

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r14
    addi r1,r1,-16

% Storing final address
    sw -20(r14),r1

% Init const int value 1 (21:11)
    sub r1,r1,r1
    addi r1,r1,1
    sw -24(r14),r1

% Assignment
    sub r1,r1,r1
    sub r2,r2,r2
    lw r1,-20(r14)
    lw r2,-24(r14)
    sw 0(r1),r2
    lw r15,-4(r14)
    jr r15

C2_func_integer_C1
    sw -4(r14),r15
    lw r15,-4(r14)
    jr r15

squared_integer_integer
    sw -4(r14),r15
    lw r15,-4(r14)
    jr r15

% Set FSP for main function
    addi r14,r14,64

main

% Init const int value 2 (47:14)
    sub r2,r2,r2
    addi r2,r2,2
    sw -52(r14),r2

% Init const int value 1 (53:10)
    sub r2,r2,r2
    addi r2,r2,1
    sw -56(r14),r2

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r2,r2,r2
    add r2,r2,r14
    addi r2,r2,-48

% Storing final address
    sw -60(r14),r2

% Init const int value 1 (54:9)
    sub r2,r2,r2
    addi r2,r2,1
    sw -64(r14),r2

% Program footer
    hlt 

baseAddr
