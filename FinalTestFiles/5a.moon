
C1_func1_integer_integer
    sw -4(r14),r15

% Assignment

% Init const int value 10 (21:22)
    sub r1,r1,r1
    addi r1,r1,10
    sw -28(r14),r1

% Var Func Call
    sw -36(r14),r12

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
    addi r1,r1,-32

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
    lw r12,-36(r14)

% AddOp (Add) at (21 : 20)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-28(r14)
    lw r3,-32(r14)
    add r1,r3,r2
    sw -24(r14),r1

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
    sw -44(r14),r12

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
    addi r1,r1,-40

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
    lw r12,-44(r14)
    sub r13,r13,r13
    add r13,r13,r14
    addi r13,r13,-40
    lw r15,-4(r14)
    jr r15

C2_func2_integer_C1
    sw -4(r14),r15

% Assignment

% Var Func Call
    sw -52(r14),r12

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
    addi r1,r1,-48

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
    lw r12,-52(r14)

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-40
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
    addi r1,r1,-48

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
    sw -84(r14),r12

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
    addi r2,r2,28
    add r1,r1,r14
    addi r1,r1,-80

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
    lw r12,-84(r14)
    sub r13,r13,r13
    add r13,r13,r14
    addi r13,r13,-80
    lw r15,-4(r14)
    jr r15

squared_integer_integer
    sw -4(r14),r15

% Var Func Call
    sw -24(r14),r12

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
    addi r1,r1,-20

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
    lw r12,-24(r14)

% Var Func Call
    sw -32(r14),r12

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
    lw r12,-32(r14)

% MultOp (Multiply) at (36 : 12)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-20(r14)
    lw r3,-28(r14)
    mul r1,r3,r2
    sw -16(r14),r1
    sub r13,r13,r13
    add r13,r13,r14
    addi r13,r13,-16
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
    addi r14,r14,836

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

% Var Func Call
    sw -496(r14),r12

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
    addi r1,r1,-492
    sw 0(r1),r12
    lw r12,-496(r14)

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
    lw r5,-492(r14)
    sw 0(r5),r1

% Var Func Call
    sw -504(r14),r12

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
    addi r1,r1,-500

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

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
    lw r12,-504(r14)

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-500(r14)
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

% Init const int value 10 (51:13)
    sub r1,r1,r1
    addi r1,r1,10
    sw -512(r14),r1

% Init const int value 10 (51:8)
    sub r1,r1,r1
    addi r1,r1,10
    sw -516(r14),r1

% AddOp (Add) at (51 : 11)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-512(r14)
    lw r3,-516(r14)
    add r1,r3,r2
    sw -508(r14),r1

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-508(r14)
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

% Init const int value 9 (53:15)
    sub r1,r1,r1
    addi r1,r1,9
    sw -532(r14),r1

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% Init const int value 0 (53:7)
    sub r1,r1,r1
    addi r1,r1,0
    sw -524(r14),r1

% Init const int value 4 (53:10)
    sub r1,r1,r1
    addi r1,r1,4
    sw -528(r14),r1

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
    lw r4,-528(r14)
    mul r5,r4,r2
    mul r5,r5,r3
    add r1,r1,r5

% Computing for 1th index
    muli r3,r3,5
    sub r5,r5,r5
    addi r5,r5,1
    lw r4,-524(r14)
    mul r5,r4,r2
    mul r5,r5,r3
    add r1,r1,r5
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-532

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

% Assignment

% Var Func Call
    sw -572(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% Init const int value 0 (54:55)
    sub r1,r1,r1
    addi r1,r1,0
    sw -544(r14),r1

% Init const int value 2 (54:68)
    sub r1,r1,r1
    addi r1,r1,2
    sw -552(r14),r1

% Init const int value 2 (54:64)
    sub r1,r1,r1
    addi r1,r1,2
    sw -560(r14),r1

% Init const int value 2 (54:58)
    sub r1,r1,r1
    addi r1,r1,2
    sw -564(r14),r1

% MultOp (And) at (54 : 60)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-560(r14)
    lw r3,-564(r14)
    and r1,r3,r2
    sw -556(r14),r1

% AddOp (Add) at (54 : 66)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-552(r14)
    lw r3,-556(r14)
    add r1,r3,r2
    sw -548(r14),r1

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
    lw r4,-548(r14)
    mul r5,r4,r2
    mul r5,r5,r3
    add r1,r1,r5

% Computing for 1th index
    muli r3,r3,5
    sub r5,r5,r5
    addi r5,r5,1
    lw r4,-544(r14)
    mul r5,r4,r2
    mul r5,r5,r3
    add r1,r1,r5
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-568

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
    lw r12,-572(r14)

% Init const int value 7 (54:49)
    sub r1,r1,r1
    addi r1,r1,7
    sw -580(r14),r1

% Var Func Call
    sw -600(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% Init const int value 3 (54:44)
    sub r1,r1,r1
    addi r1,r1,3
    sw -588(r14),r1
    sub r1,r1,r1

% SUB FUNC CALL

% - create frame
    add r1,r0,r14
    addi r14,r14,32
    sw -8(r14),r12

% - copy args
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    addi r4,r4,4
    add r2,r2,r1
    addi r2,r2,-588
    add r3,r3,r14
    addi r3,r3,-12

% - MultiByteCopy
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    sub r8,r8,r8
    sub r9,r9,r9
    add r9,r9,r3
    add r8,r8,r2

multi_byte_copy_11

% -- while (i < valSizeReg)
    clt r6,r5,r4
    bz r6,multi_byte_copy_end_11

% -- {
% --- dst[i] = src[i]
    lw r7,0(r8)
    sw 0(r9),r7

% --- i++
    addi r8,r8,4
    addi r9,r9,4

% -- }
    addi r5,r5,4
    j multi_byte_copy_11

multi_byte_copy_end_11

% - jump to func
    jl r15,squared_integer_integer

% - unset FSP
    subi r14,r14,32

% - set r12 (callchain ptr)
    sub r12,r12,r12
    add r12,r0,r14
    addi r12,r12,-592
    sub r2,r2,r2

% - copy result
    addi r2,r0,4

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r13

multi_byte_copy_12

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_12

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_12

multi_byte_copy_end_12
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-596

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_13

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_13

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_13

multi_byte_copy_end_13
    lw r12,-600(r14)

% Init const int value 1 (54:31)
    sub r1,r1,r1
    addi r1,r1,1
    sw -608(r14),r1

% Var Func Call
    sw -628(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% Init const int value 2 (54:26)
    sub r1,r1,r1
    addi r1,r1,2
    sw -616(r14),r1
    sub r1,r1,r1

% SUB FUNC CALL

% - create frame
    add r1,r0,r14
    addi r14,r14,32
    sw -8(r14),r12

% - copy args
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    addi r4,r4,4
    add r2,r2,r1
    addi r2,r2,-616
    add r3,r3,r14
    addi r3,r3,-12

% - MultiByteCopy
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    sub r9,r9,r9
    sub r8,r8,r8
    add r8,r8,r3
    add r9,r9,r2

multi_byte_copy_14

% -- while (i < valSizeReg)
    clt r6,r5,r4
    bz r6,multi_byte_copy_end_14

% -- {
% --- dst[i] = src[i]
    lw r7,0(r9)
    sw 0(r8),r7

% --- i++
    addi r9,r9,4
    addi r8,r8,4

% -- }
    addi r5,r5,4
    j multi_byte_copy_14

multi_byte_copy_end_14

% - jump to func
    jl r15,squared_integer_integer

% - unset FSP
    subi r14,r14,32

% - set r12 (callchain ptr)
    sub r12,r12,r12
    add r12,r0,r14
    addi r12,r12,-620
    sub r2,r2,r2

% - copy result
    addi r2,r0,4

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r13

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
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-624

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_16

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_16

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_16

multi_byte_copy_end_16
    lw r12,-628(r14)

% Init const int value 5 (54:14)
    sub r1,r1,r1
    addi r1,r1,5
    sw -636(r14),r1

% Init const int value 5 (54:10)
    sub r1,r1,r1
    addi r1,r1,5
    sw -640(r14),r1

% MultOp (Divide) at (54 : 12)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-636(r14)
    lw r3,-640(r14)
    div r1,r3,r2
    sw -632(r14),r1

% AddOp (Add) at (54 : 16)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-624(r14)
    lw r3,-632(r14)
    add r1,r3,r2
    sw -612(r14),r1

% AddOp (Subtract) at (54 : 29)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-608(r14)
    lw r3,-612(r14)
    sub r1,r3,r2
    sw -604(r14),r1

% MultOp (Multiply) at (54 : 34)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-596(r14)
    lw r3,-604(r14)
    mul r1,r3,r2
    sw -584(r14),r1

% AddOp (Add) at (54 : 47)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-580(r14)
    lw r3,-584(r14)
    add r1,r3,r2
    sw -576(r14),r1

% AddOp (Add) at (54 : 51)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-568(r14)
    lw r3,-576(r14)
    add r1,r3,r2
    sw -540(r14),r1

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
    addi r1,r1,-540

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r1

multi_byte_copy_17

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_17

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_17

multi_byte_copy_end_17

% Var Func Call
    sw -648(r14),r12

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
    addi r1,r1,-644

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_18

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_18

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_18

multi_byte_copy_end_18
    lw r12,-648(r14)

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-644(r14)
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

% Var Func Call
    sw -664(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-140
    add r12,r0,r1

% Init const int value 2 (57:16)
    sub r1,r1,r1
    addi r1,r1,2
    sw -652(r14),r1
    sub r1,r1,r1

% SUB FUNC CALL

% - create frame
    add r1,r0,r14
    addi r14,r14,44
    sw -8(r14),r12

% - copy args
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    addi r4,r4,4
    add r2,r2,r1
    addi r2,r2,-652
    add r3,r3,r14
    addi r3,r3,-12

% - MultiByteCopy
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    sub r8,r8,r8
    sub r9,r9,r9
    add r9,r9,r3
    add r8,r8,r2

multi_byte_copy_19

% -- while (i < valSizeReg)
    clt r6,r5,r4
    bz r6,multi_byte_copy_end_19

% -- {
% --- dst[i] = src[i]
    lw r7,0(r8)
    sw 0(r9),r7

% --- i++
    addi r8,r8,4
    addi r9,r9,4

% -- }
    addi r5,r5,4
    j multi_byte_copy_19

multi_byte_copy_end_19

% - jump to func
    jl r15,C1_func1_integer_integer

% - unset FSP
    subi r14,r14,44

% - set r12 (callchain ptr)
    sub r12,r12,r12
    add r12,r0,r14
    addi r12,r12,-656
    sub r2,r2,r2

% - copy result
    addi r2,r0,4

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r13

multi_byte_copy_20

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_20

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_20

multi_byte_copy_end_20
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-660

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_21

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_21

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_21

multi_byte_copy_end_21
    lw r12,-664(r14)

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-660(r14)
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

% Assignment

% Init const int value 321 (59:11)
    sub r1,r1,r1
    addi r1,r1,321
    sw -676(r14),r1

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-140
    add r12,r0,r1

% Init const int value 2 (59:6)
    sub r1,r1,r1
    addi r1,r1,2
    sw -672(r14),r1

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
    lw r4,-672(r14)
    mul r5,r4,r2
    mul r5,r5,r3
    add r1,r1,r5
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-676

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r1

multi_byte_copy_22

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_22

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_22

multi_byte_copy_end_22

% Var Func Call
    sw -688(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-140
    add r12,r0,r1

% Init const int value 2 (60:12)
    sub r1,r1,r1
    addi r1,r1,2
    sw -680(r14),r1

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
    lw r4,-680(r14)
    mul r5,r4,r2
    mul r5,r5,r3
    add r1,r1,r5
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-684

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_23

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_23

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_23

multi_byte_copy_end_23
    lw r12,-688(r14)

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-684(r14)
    cge r3,r1,r0
    bnz r3,putint1_4
    sub r1,r0,r1

putint1_4
    modi r4,r1,10
    addi r4,r4,48
    divi r1,r1,10
    sb putint9_4(r2),r4
    addi r2,r2,1
    bnz r1,putint1_4
    bnz r3,putint2_4
    addi r3,r0,45
    sb putint9_4(r2),r3
    addi r2,r2,1
    add r1,r0,r0

putint2_4
    subi r2,r2,1
    lb r1,putint9_4(r2)
    putc r1
    bnz r2,putint2_4
    j putint_end_4

putint9_4
    res 12
    align 

putint_end_4
    sub r1,r1,r1
    addi r1,r1,10
    putc r1

% Assignment

% Init const int value 778 (62:8)
    sub r1,r1,r1
    addi r1,r1,778
    sw -696(r14),r1

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-140
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
    addi r1,r1,-696

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r1

multi_byte_copy_24

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_24

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_24

multi_byte_copy_end_24

% Var Func Call
    sw -704(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-140
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
    addi r1,r1,-700

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_25

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_25

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_25

multi_byte_copy_end_25
    lw r12,-704(r14)

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-700(r14)
    cge r3,r1,r0
    bnz r3,putint1_5
    sub r1,r0,r1

putint1_5
    modi r4,r1,10
    addi r4,r4,48
    divi r1,r1,10
    sb putint9_5(r2),r4
    addi r2,r2,1
    bnz r1,putint1_5
    bnz r3,putint2_5
    addi r3,r0,45
    sb putint9_5(r2),r3
    addi r2,r2,1
    add r1,r0,r0

putint2_5
    subi r2,r2,1
    lb r1,putint9_5(r2)
    putc r1
    bnz r2,putint2_5
    j putint_end_5

putint9_5
    res 12
    align 

putint_end_5
    sub r1,r1,r1
    addi r1,r1,10
    putc r1

% Assignment

% Init const int value 1717 (65:13)
    sub r1,r1,r1
    addi r1,r1,1717
    sw -716(r14),r1

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-332
    add r12,r0,r1

% Init const int value 1 (65:6)
    sub r1,r1,r1
    addi r1,r1,1
    sw -712(r14),r1

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
    lw r4,-712(r14)
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
    addi r1,r1,-716

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r1

multi_byte_copy_26

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_26

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_26

multi_byte_copy_end_26

% Var Func Call
    sw -728(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-332
    add r12,r0,r1

% Init const int value 1 (66:12)
    sub r1,r1,r1
    addi r1,r1,1
    sw -720(r14),r1

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
    lw r4,-720(r14)
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
    addi r1,r1,-724

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_27

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_27

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_27

multi_byte_copy_end_27
    lw r12,-728(r14)

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-724(r14)
    cge r3,r1,r0
    bnz r3,putint1_6
    sub r1,r0,r1

putint1_6
    modi r4,r1,10
    addi r4,r4,48
    divi r1,r1,10
    sb putint9_6(r2),r4
    addi r2,r2,1
    bnz r1,putint1_6
    bnz r3,putint2_6
    addi r3,r0,45
    sb putint9_6(r2),r3
    addi r2,r2,1
    add r1,r0,r0

putint2_6
    subi r2,r2,1
    lb r1,putint9_6(r2)
    putc r1
    bnz r2,putint2_6
    j putint_end_6

putint9_6
    res 12
    align 

putint_end_6
    sub r1,r1,r1
    addi r1,r1,10
    putc r1

% Assignment

% Init const int value 7474 (68:8)
    sub r1,r1,r1
    addi r1,r1,7474
    sw -736(r14),r1

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-332
    add r12,r0,r1

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,188
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-736

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r1

multi_byte_copy_28

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_28

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_28

multi_byte_copy_end_28

% Var Func Call
    sw -744(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-332
    add r12,r0,r1

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,188
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-740

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_29

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_29

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_29

multi_byte_copy_end_29
    lw r12,-744(r14)

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-740(r14)
    cge r3,r1,r0
    bnz r3,putint1_7
    sub r1,r0,r1

putint1_7
    modi r4,r1,10
    addi r4,r4,48
    divi r1,r1,10
    sb putint9_7(r2),r4
    addi r2,r2,1
    bnz r1,putint1_7
    bnz r3,putint2_7
    addi r3,r0,45
    sb putint9_7(r2),r3
    addi r2,r2,1
    add r1,r0,r0

putint2_7
    subi r2,r2,1
    lb r1,putint9_7(r2)
    putc r1
    bnz r2,putint2_7
    j putint_end_7

putint9_7
    res 12
    align 

putint_end_7
    sub r1,r1,r1
    addi r1,r1,10
    putc r1

% Var Func Call
    sw -760(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-332
    add r12,r0,r1

% Init const int value 1 (71:18)
    sub r1,r1,r1
    addi r1,r1,1
    sw -752(r14),r1

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
    lw r4,-752(r14)
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
    addi r1,r1,-756

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r1
    add r7,r7,r12

multi_byte_copy_30

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_30

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_30

multi_byte_copy_end_30
    lw r12,-760(r14)

% Var Func Call
    sw -768(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-332
    add r12,r0,r1

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,188
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-764

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_31

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_31

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_31

multi_byte_copy_end_31
    lw r12,-768(r14)

% AddOp (Add) at (71 : 12)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-756(r14)
    lw r3,-764(r14)
    add r1,r3,r2
    sw -748(r14),r1

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-748(r14)
    cge r3,r1,r0
    bnz r3,putint1_8
    sub r1,r0,r1

putint1_8
    modi r4,r1,10
    addi r4,r4,48
    divi r1,r1,10
    sb putint9_8(r2),r4
    addi r2,r2,1
    bnz r1,putint1_8
    bnz r3,putint2_8
    addi r3,r0,45
    sb putint9_8(r2),r3
    addi r2,r2,1
    add r1,r0,r0

putint2_8
    subi r2,r2,1
    lb r1,putint9_8(r2)
    putc r1
    bnz r2,putint2_8
    j putint_end_8

putint9_8
    res 12
    align 

putint_end_8
    sub r1,r1,r1
    addi r1,r1,10
    putc r1

% Assignment

% Init const int value 10 (73:7)
    sub r1,r1,r1
    addi r1,r1,10
    sw -776(r14),r1

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
    addi r1,r1,-776

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r1

multi_byte_copy_32

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_32

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_32

multi_byte_copy_end_32

% While Loop

WhileBranch_begin_0

% Var Func Call
    sw -788(r14),r12

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
    addi r1,r1,-784

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_33

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_33

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_33

multi_byte_copy_end_33
    lw r12,-788(r14)

% Init const int value 0 (74:14)
    sub r1,r1,r1
    addi r1,r1,0
    sw -792(r14),r1

% CompareOp (GreaterThan)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r1,-784(r14)
    lw r2,-792(r14)
    cgt r3,r1,r2
    sw -780(r14),r3
    sub r1,r1,r1
    lw r1,-780(r14)
    bz r1,WhileBranch_end_0

% If Statement

% Var Func Call
    sw -804(r14),r12

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
    addi r1,r1,-800

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r1
    add r7,r7,r12

multi_byte_copy_34

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_34

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_34

multi_byte_copy_end_34
    lw r12,-804(r14)

% Init const int value 5 (77:13)
    sub r1,r1,r1
    addi r1,r1,5
    sw -808(r14),r1

% CompareOp (GreaterThan)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r1,-800(r14)
    lw r2,-808(r14)
    cgt r3,r1,r2
    sw -796(r14),r3
    sub r1,r1,r1
    lw r1,-796(r14)
    bz r1,IfBranch_false_1

IfBranch_true_1

% Init const int value 1 (80:12)
    sub r1,r1,r1
    addi r1,r1,1
    sw -812(r14),r1

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-812(r14)
    cge r3,r1,r0
    bnz r3,putint1_9
    sub r1,r0,r1

putint1_9
    modi r4,r1,10
    addi r4,r4,48
    divi r1,r1,10
    sb putint9_9(r2),r4
    addi r2,r2,1
    bnz r1,putint1_9
    bnz r3,putint2_9
    addi r3,r0,45
    sb putint9_9(r2),r3
    addi r2,r2,1
    add r1,r0,r0

putint2_9
    subi r2,r2,1
    lb r1,putint9_9(r2)
    putc r1
    bnz r2,putint2_9
    j putint_end_9

putint9_9
    res 12
    align 

putint_end_9
    sub r1,r1,r1
    addi r1,r1,10
    putc r1
    j IfBranch_end_1

IfBranch_false_1

% Init const int value 2 (84:12)
    sub r1,r1,r1
    addi r1,r1,2
    sw -816(r14),r1

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-816(r14)
    cge r3,r1,r0
    bnz r3,putint1_10
    sub r1,r0,r1

putint1_10
    modi r4,r1,10
    addi r4,r4,48
    divi r1,r1,10
    sb putint9_10(r2),r4
    addi r2,r2,1
    bnz r1,putint1_10
    bnz r3,putint2_10
    addi r3,r0,45
    sb putint9_10(r2),r3
    addi r2,r2,1
    add r1,r0,r0

putint2_10
    subi r2,r2,1
    lb r1,putint9_10(r2)
    putc r1
    bnz r2,putint2_10
    j putint_end_10

putint9_10
    res 12
    align 

putint_end_10
    sub r1,r1,r1
    addi r1,r1,10
    putc r1

IfBranch_end_1

% Assignment

% Init const int value 1 (87:14)
    sub r1,r1,r1
    addi r1,r1,1
    sw -828(r14),r1

% Var Func Call
    sw -836(r14),r12

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
    addi r1,r1,-832

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

multi_byte_copy_35

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_35

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r7),r4

% --- i++
    addi r6,r6,4
    addi r7,r7,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_35

multi_byte_copy_end_35
    lw r12,-836(r14)

% AddOp (Subtract) at (87 : 12)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-828(r14)
    lw r3,-832(r14)
    sub r1,r3,r2
    sw -824(r14),r1

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
    addi r1,r1,-824

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    add r6,r6,r12
    add r7,r7,r1

multi_byte_copy_36

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_36

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_36

multi_byte_copy_end_36
    j WhileBranch_begin_0

WhileBranch_end_0

% Program footer
    hlt 

baseAddr
