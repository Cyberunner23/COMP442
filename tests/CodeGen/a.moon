
C1_func_integer_C1
    sw -4(r14),r15

C2_func_integer_C1
    sw -4(r14),r15

squared_integer_integer
    sw -4(r14),r15

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
    add r6,r6,r1
    add r7,r7,r12

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

% MultOp (Multiply) at (32 : 12)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-24(r14)
    lw r3,-28(r14)
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
    addi r14,r14,28

main

% Assignment

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-12
    add r12,r0,r1

% Var Func Call

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% Init const int value 9 (40:17)
    sub r1,r1,r1
    addi r1,r1,9
    sw -16(r14),r1
    sub r1,r1,r1

% SUB FUNC CALL

% - create frame
    add r1,r0,r14
    addi r14,r14,28
    sw -8(r14),r12

% - copy args
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    addi r4,r4,4
    add r2,r2,r1
    addi r2,r2,-16
    add r3,r3,r14
    addi r3,r3,-16

% - MultiByteCopy
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    sub r8,r8,r8
    sub r9,r9,r9
    add r9,r9,r3
    add r8,r8,r2

multi_byte_copy_2

% -- while (i < valSizeReg)
    clt r7,r5,r4
    bz r7,multi_byte_copy_end_2

% -- {
% --- dst[i] = src[i]
    lw r6,0(r8)
    sw 0(r9),r6

% --- i++
    addi r8,r8,4
    addi r9,r9,4

% -- }
    addi r5,r5,4
    j multi_byte_copy_2

multi_byte_copy_end_2

% - jump to func
    jl r15,squared_integer_integer

% - unset FSP
    subi r14,r14,28

% - set r12 (callchain ptr)
    sub r12,r12,r12
    add r12,r0,r14
    addi r12,r12,-20
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

multi_byte_copy_3

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_3

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_3

multi_byte_copy_end_3
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-24

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r1
    add r7,r7,r12

multi_byte_copy_4

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_4

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_4

multi_byte_copy_end_4
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

multi_byte_copy_5

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_5

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_5

multi_byte_copy_end_5

% Var Func Call

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-12
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
    add r6,r6,r1
    add r7,r7,r12

multi_byte_copy_6

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_6

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_6

multi_byte_copy_end_6

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-28(r14)
    cge r3,r1,r0
    bnz r3,putint1_0
    sub r1,r0,r1

putint1_0
    modi r4,r1,10
    addi r4,r4,48
    divi r1,r1,10
    sb putint9_0(r2),r4
    addi r2,r2,1
    bnz r1,putint1_0
    bnz r3,putint2_0
    addi r3,r0,45
    sb putint9_0(r2),r3
    addi r2,r2,1
    add r1,r0,r0

putint2_0
    subi r2,r2,1
    lb r1,putint9_0(r2)
    putc r1
    bnz r2,putint2_0
    j putint_end_0

putint9_0
    res 12
    align 

putint_end_0

% Program footer
    hlt 

baseAddr
