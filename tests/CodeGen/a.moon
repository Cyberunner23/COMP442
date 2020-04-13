
C1_func_integer_C1
    sw -4(r14),r15
    lw r15,-4(r14)
    jr r15

C2_func_integer_C1
    sw -4(r14),r15
    lw r15,-4(r14)
    jr r15

squared_integer_integer
    sw -4(r14),r15

% Assignment

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-20
    add r12,r0,r1

% Var Func Call

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-16
    add r12,r0,r1

% Var Func Call

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-16
    add r12,r0,r1

% MultOp (Multiply) at (33 : 16)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-28(r14)
    lw r3,-32(r14)
    mul r1,r3,r2
    sw -24(r14),r1

% Var Func Call

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-20
    add r12,r0,r1
    sub r13,r13,r13
    add r13,r13,r14
    add r13,r13,-36
    lw r15,-4(r14)
    jr r15
    lw r15,-4(r14)
    jr r15

% ----------------------------------------
% Start of the program
% ----------------------------------------
    align 
    entry 

% Set stack pointer to initial value (baseaddr)
    addi r14,r14,baseAddr

% Set FSP for main function
    addi r14,r14,72

main

% Init const int value 2 (44:13)
    sub r1,r1,r1
    addi r1,r1,2
    sw -68(r14),r1
    sub r1,r1,r1

% SUB FUNC CALL

% - create frame
    addi r1,r14,36

% - copy args

% - jump to func
    jl r15,squared_integer_integer

% - unset FSP
    subi r1,r14,36

% - set r12 (callchain ptr)
    sub r12,r12,r12
    add r12,r0,r14
    addi r12,r12,-72
    sub r2,r2,r2

% - copy result
    addi r2,r0,4

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r12
    add r6,r6,r13

multi_byte_copy_0

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_0

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_0

multi_byte_copy_end_0

% Program footer
    hlt 

baseAddr
