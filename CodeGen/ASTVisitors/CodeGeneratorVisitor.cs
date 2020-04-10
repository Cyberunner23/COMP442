using Parser.AST.Nodes;
using Parser.ASTVisitor;
using Parser.SymbolTable.Function;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGen.ASTVisitors
{
    class CodeGeneratorVisitor : IVisitor
    {
        private CodeWriter _writer;
        private Stack<string> _availableRegisters;

        private string FSPReg { get { return Registers.R14; } }

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
            _writer.WriteInstruction(Instructions.Sw, $"{offset}({FSPReg})", reg);
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

            var identifierNode = (IdentifierNode)children[0];
            var table = (FunctionSymbolTableEntry)n.SymTable;
            var varOffset = table.MemoryLayout.GetOffset(identifierNode.Name);
            
            _writer.WriteComment("SUB VAR CALL");

            // Get variable address
            _writer.WriteComment("Compute absolute address of variable, (we don't have lea...)");
            var absoluteAddressReg = PopRegister();
            _writer.WriteInstruction(Instructions.Add, absoluteAddressReg, absoluteAddressReg, FSPReg); // grab FSP
            _writer.WriteInstruction(Instructions.Addi, absoluteAddressReg, absoluteAddressReg, $"{varOffset}"); // Add offset, we have absolute address now
            
            // Get variable address with indexing, if used
            //           x  y  z
            // integer a[3][3][3]
            // a[1][0][2] -> a + 1*sizeof(integer)*3*3 + 0*sizeof(integer)*3 + 2*sizeof(integer)
            //                     ^               ^
            //                      typeSize       runningMultiplier
            var indicesNode = (IndicesNode)children[1];
            var indices = indicesNode.TemporaryVariableNames;
            if (indices.Count > 0)
            {
                _writer.WriteComment("Computing address from array index");

                var varType = table.MemoryLayout.GetVarType(identifierNode.Name);
                var typeSize = table.MemoryLayout.GetTypeSize(identifierNode.Name);

                // Set type size register
                var typeSizeReg = PopRegister();
                _writer.WriteInstruction(Instructions.Addi, typeSizeReg, typeSizeReg, $"{typeSize}");

                var runningMultiplierReg = PopRegister(); // 3*3
                var indexValueReg = PopRegister();
                var indexingElementOffsetReg = PopRegister(); // the 1*sizeof(integer)*3*3 value will be stored here and added to absoluteAddressReg
                for (int i = 0; i < indices.Count; ++i)
                {
                    _writer.WriteComment($"Computing for {i}th index");

                    // Set runningMultiplierReg
                    if (i == 0) // InitialValue
                    {
                        _writer.WriteInstruction(Instructions.Addi, runningMultiplierReg, runningMultiplierReg, "1");
                    }
                    else
                    {
                        _writer.WriteInstruction(Instructions.Muli, runningMultiplierReg, runningMultiplierReg, $"{varType.dims[i]}");
                    }

                    // Clear indexingElementOffsetReg
                    _writer.WriteInstruction(Instructions.Sub, indexingElementOffsetReg, indexingElementOffsetReg, indexingElementOffsetReg);
                    _writer.WriteInstruction(Instructions.Addi, indexingElementOffsetReg, indexingElementOffsetReg, "1"); // set initial multiplier value

                    // Load index value
                    var indexOffset = table.MemoryLayout.GetOffset(indices.FastReverse().ToList()[i]);
                    _writer.WriteInstruction(Instructions.Lw, indexValueReg, $"{indexOffset}({FSPReg})");

                    _writer.WriteInstruction(Instructions.Mul, indexingElementOffsetReg, indexValueReg, typeSizeReg); // 1*sizeof(integer)
                    _writer.WriteInstruction(Instructions.Mul, indexingElementOffsetReg, indexingElementOffsetReg, runningMultiplierReg); // 1*sizeof(integer)*3*3

                    // Add indexingElementOffsetReg to absoluteAddressReg
                    _writer.WriteInstruction(Instructions.Add, absoluteAddressReg, absoluteAddressReg, indexingElementOffsetReg);
                }

                PushRegister(indexValueReg);
                PushRegister(runningMultiplierReg);
                PushRegister(typeSizeReg);
            }

            // Store absolute address into temp var associated to this SubVarCall
            _writer.WriteComment("Storing final address");
            var tempVarOffset = table.MemoryLayout.GetOffset(n.TemporaryVariableName);
            _writer.WriteInstruction(Instructions.Sw, $"{tempVarOffset}({FSPReg})", absoluteAddressReg);
            PushRegister(absoluteAddressReg);
        }

        public void Visit(IndicesNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
                n.TemporaryVariableNames.Add(child.TemporaryVariableName);
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
            var table = (FunctionSymbolTableEntry)n.SymTable;
            var resultOffset = table.MemoryLayout.GetOffset(n.TemporaryVariableName);

            var operandVarOffsets = new List<int>();
            foreach (var child in children)
            {
                child.Accept(this);
                var offset = table.MemoryLayout.GetOffset(child.TemporaryVariableName);
                operandVarOffsets.Add(offset);
            }

            _writer.WriteComment($"Not at ({n.Token.StartLine}:{n.Token.StartColumn})");

            var opReg = PopRegister();
            var destReg = PopRegister();

            _writer.WriteInstruction(Instructions.Lw, opReg, $"{operandVarOffsets[0]}({FSPReg})");
            _writer.WriteInstruction(Instructions.Not, destReg, opReg);
            _writer.WriteInstruction(Instructions.Sw, $"{resultOffset}({FSPReg})", destReg);

            PushRegister(destReg);
            PushRegister(opReg);
        }

        public void Visit(SignNode n)
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

            if (n.Sign == Sign.Minus)
            {
                _writer.WriteComment($"SignNode '{n.Sign}' at ({n.Token.StartLine}:{n.Token.StartColumn})");

                var opReg = PopRegister();
                var destReg = PopRegister();

                _writer.WriteInstruction(Instructions.Lw, opReg, $"{operandVarOffsets[0]}({FSPReg})");
                _writer.WriteInstruction(Instructions.Sub, destReg, destReg, opReg);
                _writer.WriteInstruction(Instructions.Sw, $"{resultOffset}({FSPReg})", destReg);

                PushRegister(destReg);
                PushRegister(opReg);
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

            _writer.WriteInstruction(Instructions.Lw, op1Reg, $"{operandVarOffsets[0]}({FSPReg})");
            _writer.WriteInstruction(Instructions.Lw, op2Reg, $"{operandVarOffsets[1]}({FSPReg})");
            _writer.WriteInstruction(instruction, destReg, op1Reg, op2Reg);
            _writer.WriteInstruction(Instructions.Sw, $"{resultOffset}({FSPReg})", destReg);

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

            _writer.WriteInstruction(Instructions.Lw, op1Reg, $"{operandVarOffsets[0]}({FSPReg})");
            _writer.WriteInstruction(Instructions.Lw, op2Reg, $"{operandVarOffsets[1]}({FSPReg})");
            _writer.WriteInstruction(instruction, destReg, op2Reg, op1Reg);
            _writer.WriteInstruction(Instructions.Sw, $"{resultOffset}({FSPReg})", destReg);

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
                n.TemporaryVariableName = child.TemporaryVariableName;
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
            _writer.WriteInstruction(Instructions.Addi, FSPReg, FSPReg, frameSize.ToString());
            _writer.WriteTag("main");

            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }
    }
}
