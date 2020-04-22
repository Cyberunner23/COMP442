
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
    addi r14,r14,616

main

% Init const int value 5 (42:12)
    sub r1,r1,r1
    addi r1,r1,5
    sw -480(r14),r1

% Init const int value 5 (42:15)
    sub r1,r1,r1
    addi r1,r1,5
    sw -484(r14),r1

% Init const int value 5 (45:7)
    sub r1,r1,r1
    addi r1,r1,5
    sw -488(r14),r1

% Assignment

% Init const int value 1 (49:11)
    sub r1,r1,r1
    addi r1,r1,1
    sw -500(r14),r1

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-332
    add r12,r0,r1

% Init const int value 2 (49:6)
    sub r1,r1,r1
    addi r1,r1,2
    sw -496(r14),r1

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,4

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
    lw r4,-496(r14)
    mul r5,r4,r2
    mul r5,r5,r3
    add r1,r1,r5
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-500

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r12
    add r6,r6,r1

multi_byte_copy_8

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_8

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_8

multi_byte_copy_end_8

% Assignment

% Init const int value 5 (50:13)
    sub r1,r1,r1
    addi r1,r1,5
    sw -512(r14),r1

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-332
    add r12,r0,r1

% Init const int value 2 (50:6)
    sub r1,r1,r1
    addi r1,r1,2
    sw -508(r14),r1

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,24

% Computing address from array index
    sub r2,r2,r2
    addi r2,r2,28
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5

% Computing for 0th index
    addi r3,r3,1
    sub r5,r5,r5
    addi r5,r5,1
    lw r4,-508(r14)
    mul r5,r4,r2
    mul r5,r5,r3
    add r1,r1,r5
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
    addi r1,r1,-512

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r1

multi_byte_copy_9

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_9

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_9

multi_byte_copy_end_9

% Var Func Call
    sw -520(r14),r12

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
    addi r1,r1,-516
    sw 0(r1),r12
    lw r12,-520(r14)

% Read Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4

getint1_0
    getc r1
    ceqi r3,r1,43
    bnz r3,getint1_0
    ceqi r3,r1,45
    bz r3,getint2_0
    addi r4,r0,1
    j getint1_0

getint2_0
    clti r3,r1,48
    bnz r3,getint3_0
    cgti r3,r1,57
    bnz r3,getint3_0
    sb getint9_0(r2),r1
    addi r2,r2,1
    j getint1_0

getint3_0
    sb getint9_0(r2),r0
    add r1,r0,r0
    add r2,r0,r0
    add r3,r0,r0

getint4_0
    lb r3,getint9_0(r2)
    bz r3,getint5_0
    subi r3,r3,48
    muli r1,r1,10
    add r1,r1,r3
    addi r2,r2,1
    j getint4_0

getint5_0
    bz r4,getint6_0
    sub r1,r0,r1

getint6_0
    j getint_end_0

getint9_0
    res 12
    align 

getint_end_0
    sub r5,r5,r5
    lw r5,-516(r14)
    sw 0(r5),r1

% Var Func Call
    sw -528(r14),r12

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
    addi r1,r1,-524

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_10

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_10

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_10

multi_byte_copy_end_10
    lw r12,-528(r14)

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-524(r14)
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
    sub r1,r1,r1
    addi r1,r1,10
    putc r1

% Init const int value 10 (54:13)
    sub r1,r1,r1
    addi r1,r1,10
    sw -536(r14),r1

% Init const int value 10 (54:8)
    sub r1,r1,r1
    addi r1,r1,10
    sw -540(r14),r1

% AddOp (Add) at (54 : 11)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-536(r14)
    lw r3,-540(r14)
    add r1,r3,r2
    sw -532(r14),r1

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-532(r14)
    cge r3,r1,r0
    bnz r3,putint1_1
    sub r1,r0,r1

putint1_1
    modi r4,r1,10
    addi r4,r4,48
    divi r1,r1,10
    sb putint9_1(r2),r4
    addi r2,r2,1
    bnz r1,putint1_1
    bnz r3,putint2_1
    addi r3,r0,45
    sb putint9_1(r2),r3
    addi r2,r2,1
    add r1,r0,r0

putint2_1
    subi r2,r2,1
    lb r1,putint9_1(r2)
    putc r1
    bnz r2,putint2_1
    j putint_end_1

putint9_1
    res 12
    align 

putint_end_1
    sub r1,r1,r1
    addi r1,r1,10
    putc r1

% Assignment

% Init const int value 9 (56:15)
    sub r1,r1,r1
    addi r1,r1,9
    sw -556(r14),r1

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% Init const int value 0 (56:7)
    sub r1,r1,r1
    addi r1,r1,0
    sw -548(r14),r1

% Init const int value 4 (56:10)
    sub r1,r1,r1
    addi r1,r1,4
    sw -552(r14),r1

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-112

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
    lw r4,-552(r14)
    mul r5,r4,r2
    mul r5,r5,r3
    add r1,r1,r5

% Computing for 1th index
    muli r3,r3,5
    sub r5,r5,r5
    addi r5,r5,1
    lw r4,-548(r14)
    mul r5,r4,r2
    mul r5,r5,r3
    add r1,r1,r5
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-556

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r1

multi_byte_copy_11

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_11

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_11

multi_byte_copy_end_11

% While Loop

WhileBranch_begin_0

% Var Func Call
    sw -568(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-476
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-564

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_12

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_12

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_12

multi_byte_copy_end_12
    lw r12,-568(r14)

% Init const int value 0 (59:14)
    sub r1,r1,r1
    addi r1,r1,0
    sw -572(r14),r1

% CompareOp (GreaterThan)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r1,-564(r14)
    lw r2,-572(r14)
    cgt r3,r1,r2
    sw -560(r14),r3
    sub r1,r1,r1
    lw r1,-560(r14)
    bz r1,WhileBranch_end_0

% If Statement

% Var Func Call
    sw -584(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-476
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-580

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r1
    add r7,r7,r12

multi_byte_copy_13

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_13

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_13

multi_byte_copy_end_13
    lw r12,-584(r14)

% Init const int value 5 (62:13)
    sub r1,r1,r1
    addi r1,r1,5
    sw -588(r14),r1

% CompareOp (GreaterThan)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r1,-580(r14)
    lw r2,-588(r14)
    cgt r3,r1,r2
    sw -576(r14),r3
    sub r1,r1,r1
    lw r1,-576(r14)
    bz r1,IfBranch_false_1

IfBranch_true_1

% Init const int value 1 (65:12)
    sub r1,r1,r1
    addi r1,r1,1
    sw -592(r14),r1

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-592(r14)
    cge r3,r1,r0
    bnz r3,putint1_2
    sub r1,r0,r1

putint1_2
    modi r4,r1,10
    addi r4,r4,48
    divi r1,r1,10
    sb putint9_2(r2),r4
    addi r2,r2,1
    bnz r1,putint1_2
    bnz r3,putint2_2
    addi r3,r0,45
    sb putint9_2(r2),r3
    addi r2,r2,1
    add r1,r0,r0

putint2_2
    subi r2,r2,1
    lb r1,putint9_2(r2)
    putc r1
    bnz r2,putint2_2
    j putint_end_2

putint9_2
    res 12
    align 

putint_end_2
    sub r1,r1,r1
    addi r1,r1,10
    putc r1
    j IfBranch_end_1

IfBranch_false_1

% Init const int value 2 (69:12)
    sub r1,r1,r1
    addi r1,r1,2
    sw -596(r14),r1

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-596(r14)
    cge r3,r1,r0
    bnz r3,putint1_3
    sub r1,r0,r1

putint1_3
    modi r4,r1,10
    addi r4,r4,48
    divi r1,r1,10
    sb putint9_3(r2),r4
    addi r2,r2,1
    bnz r1,putint1_3
    bnz r3,putint2_3
    addi r3,r0,45
    sb putint9_3(r2),r3
    addi r2,r2,1
    add r1,r0,r0

putint2_3
    subi r2,r2,1
    lb r1,putint9_3(r2)
    putc r1
    bnz r2,putint2_3
    j putint_end_3

putint9_3
    res 12
    align 

putint_end_3
    sub r1,r1,r1
    addi r1,r1,10
    putc r1

IfBranch_end_1

% Assignment

% Init const int value 1 (72:14)
    sub r1,r1,r1
    addi r1,r1,1
    sw -608(r14),r1

% Var Func Call
    sw -616(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-476
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-612

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_14

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_14

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_14

multi_byte_copy_end_14
    lw r12,-616(r14)

% AddOp (Subtract) at (72 : 12)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-608(r14)
    lw r3,-612(r14)
    sub r1,r3,r2
    sw -604(r14),r1

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-476
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-604

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r1

multi_byte_copy_15

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_15

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_15

multi_byte_copy_end_15
    j WhileBranch_begin_0

WhileBranch_end_0

% Program footer
    hlt 

baseAddr
