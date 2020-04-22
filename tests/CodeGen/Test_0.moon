
C1_func1_integer_integer
    sw -4(r14),r15

% Assignment

% Init const int value 10 (21:22)
    sub r1,r1,r1
    addi r1,r1,10
    sw -32(r14),r1

% Var Func Call
    sw -40(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-16
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-36

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

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
    lw r12,-40(r14)

% AddOp (Add) at (21 : 20)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-32(r14)
    lw r3,-36(r14)
    add r1,r3,r2
    sw -28(r14),r1

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-20
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-28

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r1

multi_byte_copy_1

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_1

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_1

multi_byte_copy_end_1

% Var Func Call
    sw -48(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-20
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-44

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_2

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_2

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_2

multi_byte_copy_end_2
    lw r12,-48(r14)
    sub r13,r13,r13
    add r13,r13,r14
    addi r13,r13,-44
    lw r15,-4(r14)
    jr r15

C2_func2_integer_C1
    sw -4(r14),r15

% Assignment

% Var Func Call
    sw -80(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-40
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-76

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r1
    add r7,r7,r12

multi_byte_copy_3

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_3

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_3

multi_byte_copy_end_3
    lw r12,-80(r14)

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-68
    add r12,r0,r1

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,24
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-76

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r12
    add r6,r6,r1

multi_byte_copy_4

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_4

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_4

multi_byte_copy_end_4

% Var Func Call
    sw -112(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-68
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,28
    add r1,r1,r14
    addi r1,r1,-108

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r1
    add r7,r7,r12

multi_byte_copy_5

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_5

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_5

multi_byte_copy_end_5
    lw r12,-112(r14)
    sub r13,r13,r13
    add r13,r13,r14
    addi r13,r13,-108
    lw r15,-4(r14)
    jr r15

squared_integer_integer
    sw -4(r14),r15

% Var Func Call
    sw -28(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-16
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-24

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_6

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_6

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_6

multi_byte_copy_end_6
    lw r12,-28(r14)

% Var Func Call
    sw -36(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-16
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-32

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r1
    add r7,r7,r12

multi_byte_copy_7

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_7

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_7

multi_byte_copy_end_7
    lw r12,-36(r14)

% MultOp (Multiply) at (36 : 12)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-24(r14)
    lw r3,-32(r14)
    mul r1,r3,r2
    sw -20(r14),r1
    sub r13,r13,r13
    add r13,r13,r14
    addi r13,r13,-20
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
    addi r14,r14,396

main

% Init const int value 5 (41:12)
    sub r1,r1,r1
    addi r1,r1,5
    sw -392(r14),r1

% Init const int value 5 (44:7)
    sub r1,r1,r1
    addi r1,r1,5
    sw -396(r14),r1

% Program footer
    hlt 

baseAddr
