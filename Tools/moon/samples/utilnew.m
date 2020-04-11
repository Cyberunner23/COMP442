%==============================================================%
% File:        util.m                                          %
% Author:      Nagi B. F. MIKHAIL                              %
% Date:        April, 1995                                     %
% Description: This file contains utility routines written in  %
%              MOON's assembly to handle string operations &   %
%              Input/Output.                                   %
%==============================================================%
%
% NOTE(AFL): Removed unused functions
%
%--------------------------------------------------------------%
% getint                                                       %
%--------------------------------------------------------------%
% Read an integer number from stdin. Read until a non digit char
% is entered. Allowes (+) & (-) signs only as first char. The
% digits are read in ASCII and transformed to numbers.
% Entry : none.
% Exit : result -> r1
%
getint	align
	add	r1,r0,r0		% Initialize input register (r1 = 0)
	add	r2,r0,r0		% Initialize buffer's index i
	add	r4,r0,r0		% Initialize sign flag
getint1	getc	r1			% Input ch
	ceqi	r3,r1,43		% ch = '+' ?
	bnz	r3,getint1		% Branch if true (ch = '+')
	ceqi	r3,r1,45		% ch = '-' ?
	bz	r3,getint2		% Branch if false (ch != '-')
	addi	r4,r0,1			% Set sign flag to true
	j	getint1			% Loop to get next ch
getint2	clti	r3,r1,48		% ch < '0' ?
	bnz	r3,getint3		% Branch if true (ch < '0')
	cgti	r3,r1,57		% ch > '9' ?
	bnz	r3,getint3		% Branch if true (ch > '9')
	sb	getint9(r2),r1		% Store ch in buffer
	addi	r2,r2,1			% i++
	j	getint1			% Loop if not finished
getint3	sb	getint9(r2),r0		% Store end of string in buffer (ch = '\0')
	add	r2,r0,r0		% i = 0
	add	r1,r0,r0		% N = 0
	add	r3,r0,r0		% Initialize r3
getint4	lb	r3,getint9(r2)		% Load ch from buffer
	bz	r3,getint5		% Branch if end of string (ch = '\0')
	subi	r3,r3,48		% Convert to number (M)
	muli	r1,r1,10		% N *= 10
	add	r1,r1,r3		% N += M
	addi	r2,r2,1			% i++
	j	getint4			% Loop if not finished
getint5	bz	r4,getint6		% Branch if sign flag false
	sub	r1,r0,r1		% N = -N
getint6	jr	r15			% Return to the caller
getint9	res	12			% Local buffer (12 bytes)
	align
%
%
%--------------------------------------------------------------%
% putint                                                       %
%--------------------------------------------------------------%
% Write an integer number to stdout. Transform the number into
% ASCII string taking the sign into account.
% Entry : integer number -> r1
% Exit : none.
%
putint	align
	add	r2,r0,r0		% Initialize buffer's index i
	cge	r3,r1,r0		% True if N >= 0
	bnz	r3,putint1		% Branch if True (N >= 0)
	sub	r1,r0,r1		% N = -N
putint1	modi	r4,r1,10		% Rightmost digit
	addi	r4,r4,48		% Convert to ch
	divi	r1,r1,10		% Truncate rightmost digit
	sb	putint9(r2),r4		% Store ch in buffer
	addi	r2,r2,1			% i++
	bnz	r1,putint1		% Loop if not finished
	bnz	r3,putint2		% Branch if True (N >= 0)
	addi	r3,r0,45
	sb	putint9(r2),r3		% Store '-' in buffer
	addi	r2,r2,1			% i++
	add	r1,r0,r0		% Initialize output register (r1 = 0)
putint2	subi	r2,r2,1			% i--
	lb	r1,putint9(r2)		% Load ch from buffer
	putc	r1			% Output ch
	bnz	r2,putint2		% Loop if not finished
	jr	r15			% return to the caller
putint9	res	12			% loacl buffer (12 bytes)
	align










