
% Start of the program
    align 
    entry 

% Set stack pointer to initial value (baseaddr)
    addi r14,r14,baseAddr

% Set FSP for main function
    addi r14,r14,32

main

% Init const int value 2 (33:14)
    sub r1,r1,r1
    addi r1,r1,2
    sw -24(r14),r1

% Init const int value 5 (38:7)
    sub r1,r1,r1
    addi r1,r1,5
    sw -28(r14),r1

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
    sw -28(r14),r1

% Init const int value 5 (39:8)
    sub r1,r1,r1
    addi r1,r1,5
    sw -32(r14),r1

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
