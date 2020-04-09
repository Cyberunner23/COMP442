using Parser.AST.Nodes;
using Parser.ASTVisitor;
using Parser.SymbolTable.Function;
using System;
using System.Collections.Generic;

namespace CodeGen.ASTVisitors
{
    class CodeGeneratorVisitor : IVisitor
    {
        private CodeWriter _writer;
        private Stack<string> _availableRegisters;

        private string FSP { get { return Registers.R14; } }

        public CodeGeneratorVisitor(CodeWriter writer)
        {
            _writer = writer;
            _availableRegisters = new Stack<string>();

            _availableRegisters.Push(Registers.R12);
            _availableRegisters.Push(Registers.R11);
            _availableRegisters.Push(Registers.R10);
            _availableRegisters.Push(Registers.R9);
            _availableRegisters.Push(Registers.R8);
            _availableRegisters.Push(Registers.R7);
            _availableRegisters.Push(Registers.R6);
            _availableRegisters.Push(Registers.R5);
            _availableRegisters.Push(Registers.R4);
            _availableRegisters.Push(Registers.R3);
            _availableRegisters.Push(Registers.R2);
            _availableRegisters.Push(Registers.R1);
            _availableRegisters.Push(Registers.R0);
        }

        private string PopRegister()
        {
            string register = _availableRegisters.Pop();

            _writer.WriteInstruction(Instructions.Sub, register, register, register);

            return register;
        }

        private void PushRegister(string regiter)
        {
            _availableRegisters.Push(regiter);
        }

        public void Visit(ProgramNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ClassDeclsNode n)
        {
        }

        public void Visit(ClassDeclNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncDefsNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(NullNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(MemberDeclsNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(IdentifierNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(InheritListNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncDefNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(TypeNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncParamListNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ArrayDimListNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ArrayDimNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(IntNumNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            var tempVar = n.TemporaryVariableName;
            var offset = table.MemoryLayout.GetOffset(tempVar);

            _writer.WriteComment($"Init const int value {n.Value} ({n.Token.StartLine}:{n.Token.StartColumn})");
            var reg = PopRegister();
            _writer.WriteInstruction(Instructions.Addi, reg, reg, n.Value.ToString());
            _writer.WriteInstruction(Instructions.Sw, $"{offset}({FSP})", reg);
            PushRegister(reg);
        }

        public void Visit(FuncBodyNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(LocalScopeNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(StatementsNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(VarDeclNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(IfNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(BoolExpressionNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(CompareOpNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(WhileNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ReadNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(WriteNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ReturnNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncCallNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(AssignmentNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(SubFuncCallNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(SubVarCallNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(IndicesNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(FuncCallParamsNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ExpressionNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(FloatNumNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(NotNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(SignNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(AddOpNode n)
        {
            var children = n.GetChildren();
            var table = (FunctionSymbolTableEntry)n.SymTable;
            var resultOffset = table.MemoryLayout.GetOffset(n.TemporaryVariableName);

            var operandVarOffsets = new List<int>();
            foreach (var child in children)
            {
                child.Accept(this);
                var offset = table.MemoryLayout.GetOffset(child.TemporaryVariableName);
                operandVarOffsets.Add(offset);
            }

            Instructions instruction;
            switch (n.Op)
            {
                case AddOp.Add:
                    instruction = Instructions.Add;
                    break;
                case AddOp.Subtract:
                    instruction = Instructions.Sub;
                    break;
                case AddOp.Or:
                    instruction = Instructions.Or;
                    break;
                default:
                    throw new InvalidOperationException("Unknown op");
            }

            _writer.WriteComment($"AddOp ({n.Op}) at ({n.Token.StartLine} : {n.Token.StartColumn})");

            var destReg = PopRegister();
            var op1Reg = PopRegister();
            var op2Reg = PopRegister();

            _writer.WriteInstruction(Instructions.Lw, op1Reg, $"{operandVarOffsets[0]}({FSP})");
            _writer.WriteInstruction(Instructions.Lw, op2Reg, $"{operandVarOffsets[1]}({FSP})");
            _writer.WriteInstruction(instruction, destReg, op1Reg, op2Reg);
            _writer.WriteInstruction(Instructions.Sw, $"{resultOffset}({FSP})", destReg);

            PushRegister(op2Reg);
            PushRegister(op1Reg);
            PushRegister(destReg);
        }

        public void Visit(MultOpNode n)
        {
            var children = n.GetChildren();
            var table = (FunctionSymbolTableEntry)n.SymTable;
            var resultOffset = table.MemoryLayout.GetOffset(n.TemporaryVariableName);

            var operandVarOffsets = new List<int>();
            foreach (var child in children)
            {
                child.Accept(this);
                var offset = table.MemoryLayout.GetOffset(child.TemporaryVariableName);
                operandVarOffsets.Add(offset);
            }

            Instructions instruction;
            switch (n.Op)
            {
                case MultOp.Multiply:
                    instruction = Instructions.Mul;
                    break;
                case MultOp.Divide:
                    instruction = Instructions.Div;
                    break;
                case MultOp.And:
                    instruction = Instructions.And;
                    break;
                default:
                    throw new InvalidOperationException("Unknown op");
            }

            _writer.WriteComment($"MultOp ({n.Op}) at ({n.Token.StartLine} : {n.Token.StartColumn})");

            var destReg = PopRegister();
            var op1Reg = PopRegister();
            var op2Reg = PopRegister();

            _writer.WriteInstruction(Instructions.Lw, op1Reg, $"{operandVarOffsets[0]}({FSP})");
            _writer.WriteInstruction(Instructions.Lw, op2Reg, $"{operandVarOffsets[1]}({FSP})");
            _writer.WriteInstruction(instruction, destReg, op2Reg, op1Reg);
            _writer.WriteInstruction(Instructions.Sw, $"{resultOffset}({FSP})", destReg);

            PushRegister(op2Reg);
            PushRegister(op1Reg);
            PushRegister(destReg);
        }

        public void Visit(ArithExprNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(VarFuncCallNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(VisibilityNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(MemberDeclNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(MainFuncNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            var frameSize = table.MemoryLayout.TotalSize;

            _writer.WriteComment("Set FSP for main function");
            _writer.WriteInstruction(Instructions.Addi, FSP, FSP, frameSize.ToString());
            _writer.WriteTag("main");

            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }
    }
}
