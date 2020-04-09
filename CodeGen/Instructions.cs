using System.Collections.Generic;

namespace CodeGen
{
    // To avoid typos when programming at 2am...
    public enum Instructions
    {
        Lw,     // Load Word
        LB,     // Load Byte
        Sw,     // Store Word
        SB,     // Store Byte
        Add,    // Add
        Sub,    // Subtract
        Mul,    // Mumtiply
        Div,    // Divide
        Mod,    // Modulus
        And,    // And
        Or,     // Or
        Not,    // Not
        Ceq,    // Equal
        Cne,    // Not Equal
        Clt,    // Less
        Cle,    // Less or Equal
        Cgt,    // Greater
        Cge,    // Greater or Equal
        Addi,   // Add Immediate
        Subi,   // Subtract Immediate
        Muli,   // Mumtiply Immediate
        Divi,   // Divide Immediate
        Modi,   // Modulus Immediate
        Andi,   // And Immediate
        Ori,    // Or Immediate
        Ceqi,   // Equal Immediate
        Cnei,   // Not Equal Immediate
        Clti,   // Less Immediate
        Clei,   // Less or Equal Immediate
        Cgti,   // Greater Immediate
        Cgei,   // Greater or Equal Immediate
        Sl,     // Shift Left
        Sr,     // Shift Right
        Getc,   // Get char
        Putc,   // Put char
        Bz,     // Branch if zero
        Bnz,    // Branch if non zero
        J,      // Jump
        Jr,     // Jump (register)
        Jl,     // Jump and link
        Jlr,    // Jump and link (register)
        Nop,    // nop
        hlt,    // Halt
        Entry,  // Entry
        Align,  // Align
        Org,    // Same as x86
        Dw,     // Same as x86
        Db,     // Same as x86
        Res     // Reserve bytes
    }

    public static class InstructionsConstants
    {
        public static readonly Dictionary<Instructions, int> ArgumentNumMap = new Dictionary<Instructions, int>()
        {
            {Instructions.Lw,    2},
            {Instructions.LB,    2},
            {Instructions.Sw,    2},
            {Instructions.SB,    2},
            {Instructions.Add,   3},
            {Instructions.Sub,   3},
            {Instructions.Mul,   3},
            {Instructions.Div,   3},
            {Instructions.Mod,   3},
            {Instructions.And,   3},
            {Instructions.Or,    3},
            {Instructions.Not,   2},
            {Instructions.Ceq,   3},
            {Instructions.Cne,   3},
            {Instructions.Clt,   3},
            {Instructions.Cle,   3},
            {Instructions.Cgt,   3},
            {Instructions.Cge,   3},
            {Instructions.Addi,  3},
            {Instructions.Subi,  3},
            {Instructions.Muli,  3},
            {Instructions.Divi,  3},
            {Instructions.Modi,  3},
            {Instructions.Andi,  3},
            {Instructions.Ori,   3},
            {Instructions.Ceqi,  3},
            {Instructions.Cnei,  3},
            {Instructions.Clti,  3},
            {Instructions.Clei,  3},
            {Instructions.Cgti,  3},
            {Instructions.Cgei,  3},
            {Instructions.Sl,    2},
            {Instructions.Sr,    2},
            {Instructions.Getc,  1},
            {Instructions.Putc,  1},
            {Instructions.Bz,    2},
            {Instructions.Bnz,   2},
            {Instructions.J,     2},
            {Instructions.Jr,    2},
            {Instructions.Jl,    2},
            {Instructions.Jlr,   2},
            {Instructions.Nop,   0},
            {Instructions.hlt,   0},
            {Instructions.Entry, 0},
            {Instructions.Align, 0},
            {Instructions.Org,   1},
            {Instructions.Dw,    -1},
            {Instructions.Db,    -1},
            {Instructions.Res,   1}
        };
    }
}
