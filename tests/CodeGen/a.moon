
funky_integer_integer
    sw -4(r14),r15

% Init const int value 1 (13:17)
    sub r1,r1,r1
    addi r1,r1,1
    sw -24(r14),r1

% Var Func Call
    sw -32(r14),r12

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
    lw r12,-32(r14)

% AddOp (Add) at (13 : 15)
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    lw r2,-24(r14)
    lw r3,-28(r14)
    add r1,r3,r2
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
    addi r14,r14,100

main

% Init const int value 10 (19:14)
    sub r1,r1,r1
    addi r1,r1,10
    sw -52(r14),r1

% Var Func Call
    sw -76(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% Var Func Call
    sw -68(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% Init const int value 4 (21:17)
    sub r1,r1,r1
    addi r1,r1,4
    sw -56(r14),r1
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
    addi r2,r2,-56
    add r3,r3,r14
    addi r3,r3,-16

% - MultiByteCopy
    sub r5,r5,r5
    sub r7,r7,r7
    sub r6,r6,r6
    sub r8,r8,r8
    sub r9,r9,r9
    add r9,r9,r3
    add r8,r8,r2

multi_byte_copy_1

% -- while (i < valSizeReg)
    clt r6,r5,r4
    bz r6,multi_byte_copy_end_1

% -- {
% --- dst[i] = src[i]
    lw r7,0(r8)
    sw 0(r9),r7

% --- i++
    addi r8,r8,4
    addi r9,r9,4

% -- }
    addi r5,r5,4
    j multi_byte_copy_1

multi_byte_copy_end_1

% - jump to func
    jl r15,funky_integer_integer

% - unset FSP
    subi r14,r14,32

% - set r12 (callchain ptr)
    sub r12,r12,r12
    add r12,r0,r14
    addi r12,r12,-60
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

multi_byte_copy_2

% -- while (i < valSizeReg)
    clt r5,r3,r2
    bz r5,multi_byte_copy_end_2

% -- {
% --- dst[i] = src[i]
    lw r4,0(r7)
    sw 0(r6),r4

% --- i++
    addi r7,r7,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_2

multi_byte_copy_end_2
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-64

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r5,r5,r5
    sub r6,r6,r6
    sub r7,r7,r7
    add r7,r7,r1
    add r6,r6,r12

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
    lw r12,-68(r14)

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-48

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
    lw r4,-64(r14)
    mul r5,r4,r2
    mul r5,r5,r3
    add r1,r1,r5
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-72
    sw 0(r1),r12
    lw r12,-76(r14)

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
    sub r7,r7,r7
    lw r7,-72(r14)
    sw 0(r7),r1

% Var Func Call
    sw -100(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% Var Func Call
    sw -92(r14),r12

% %% Callchain
    sub r12,r12,r12
    add r12,r12,r14

% Init const int value 4 (22:18)
    sub r1,r1,r1
    addi r1,r1,4
    sw -80(r14),r1
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
    addi r2,r2,-80
    add r3,r3,r14
    addi r3,r3,-16

% - MultiByteCopy
    sub r7,r7,r7
    sub r6,r6,r6
    sub r9,r9,r9
    sub r8,r8,r8
    sub r10,r10,r10
    add r10,r10,r3
    add r8,r8,r2

multi_byte_copy_4

% -- while (i < valSizeReg)
    clt r9,r7,r4
    bz r9,multi_byte_copy_end_4

% -- {
% --- dst[i] = src[i]
    lw r6,0(r8)
    sw 0(r10),r6

% --- i++
    addi r8,r8,4
    addi r10,r10,4

% -- }
    addi r7,r7,4
    j multi_byte_copy_4

multi_byte_copy_end_4

% - jump to func
    jl r15,funky_integer_integer

% - unset FSP
    subi r14,r14,32

% - set r12 (callchain ptr)
    sub r12,r12,r12
    add r12,r0,r14
    addi r12,r12,-84
    sub r2,r2,r2

% - copy result
    addi r2,r0,4

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r7,r7,r7
    sub r6,r6,r6
    sub r9,r9,r9
    add r9,r9,r12
    add r6,r6,r13

multi_byte_copy_5

% -- while (i < valSizeReg)
    clt r7,r3,r2
    bz r7,multi_byte_copy_end_5

% -- {
% --- dst[i] = src[i]
    lw r4,0(r6)
    sw 0(r9),r4

% --- i++
    addi r6,r6,4
    addi r9,r9,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_5

multi_byte_copy_end_5
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-88

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r7,r7,r7
    sub r9,r9,r9
    sub r6,r6,r6
    add r6,r6,r1
    add r9,r9,r12

multi_byte_copy_6

% -- while (i < valSizeReg)
    clt r7,r3,r2
    bz r7,multi_byte_copy_end_6

% -- {
% --- dst[i] = src[i]
    lw r4,0(r9)
    sw 0(r6),r4

% --- i++
    addi r9,r9,4
    addi r6,r6,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_6

multi_byte_copy_end_6
    lw r12,-92(r14)

% SUB VAR CALL

% Compute absolute address of variable, (we don't have lea...)
    sub r1,r1,r1
    add r1,r1,r12
    addi r1,r1,-48

% Computing address from array index
    sub r2,r2,r2
    addi r2,r2,4
    sub r3,r3,r3
    sub r4,r4,r4
    sub r7,r7,r7

% Computing for 0th index
    addi r3,r3,1
    sub r7,r7,r7
    addi r7,r7,1
    lw r4,-88(r14)
    mul r7,r4,r2
    mul r7,r7,r3
    add r1,r1,r7
    add r12,r0,r1
    sub r1,r1,r1
    sub r2,r2,r2
    addi r2,r2,4
    add r1,r1,r14
    addi r1,r1,-96

% - MultiByteCopy
    sub r3,r3,r3
    sub r4,r4,r4
    sub r6,r6,r6
    sub r9,r9,r9
    sub r10,r10,r10
    add r10,r10,r1
    add r9,r9,r12

multi_byte_copy_7

% -- while (i < valSizeReg)
    clt r6,r3,r2
    bz r6,multi_byte_copy_end_7

% -- {
% --- dst[i] = src[i]
    lw r4,0(r9)
    sw 0(r10),r4

% --- i++
    addi r9,r9,4
    addi r10,r10,4

% -- }
    addi r3,r3,4
    j multi_byte_copy_7

multi_byte_copy_end_7
    lw r12,-100(r14)

% Write Op
    sub r1,r1,r1
    sub r2,r2,r2
    sub r3,r3,r3
    sub r4,r4,r4
    lw r1,-96(r14)
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

% Program footer
    hlt 

baseAddr
