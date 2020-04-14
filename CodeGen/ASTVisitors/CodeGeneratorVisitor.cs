using Parser.AST;
using Parser.AST.Nodes;
using Parser.ASTVisitor;
using Parser.SymbolTable;
using Parser.SymbolTable.Class;
using Parser.SymbolTable.Function;
using Parser.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGen.ASTVisitors
{
    class CodeGeneratorVisitor : IVisitor
    {
        private CodeWriter _writer;
        private Stack<string> _availableRegisters;
        private int _branchCounter;
        private int _writeLabelCounter;
        private int _readLabelCounter;
        private int _copyLabelCounter;

        private GlobalSymbolTable _globalSymbolTable;

        private string FSPReg { get { return Registers.R14; } }

        public CodeGeneratorVisitor(CodeWriter writer, GlobalSymbolTable table)
        {
            _writer = writer;
            _globalSymbolTable = table;

            _availableRegisters = new Stack<string>();
            _branchCounter = 0;
            _writeLabelCounter = 0;
            _readLabelCounter = 0;

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

        public void Visit(FuncBodyNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            var tag = Utils.GetTag(table);
            var r15 = Registers.R15;
            
            _writer.WriteTag(tag);
            _writer.WriteInstruction(Instructions.Sw, $"-4({FSPReg})", r15);

            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }

            if (string.Equals(table.ReturnType.Lexeme, TypeConstants.VoidType))
            {
                // Jump to return address
                _writer.WriteInstruction(Instructions.Lw, r15, $"-4({FSPReg})");
                _writer.WriteInstruction(Instructions.Jr, r15);
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
            var table = (FunctionSymbolTableEntry)n.SymTable;
            var children = n.GetChildren();
            _writer.WriteComment("If Statement");

            var ifBranch = $"IfBranch_true_{_branchCounter}";
            var elseBranch = $"IfBranch_false_{_branchCounter}";
            var endBranch = $"IfBranch_end_{_branchCounter}";
            ++_branchCounter;

            // Write compare operations
            children[0].Accept(this);

            // Write Jump Logic
            var compareResultVar = children[0].TemporaryVariableName;
            var compareResultOffset = table.MemoryLayout.GetOffset(compareResultVar);
            var compareResultReg = PopRegister();

            _writer.WriteInstruction(Instructions.Lw, compareResultReg, $"{compareResultOffset}({FSPReg})");
            _writer.WriteInstruction(Instructions.Bz, compareResultReg, elseBranch);
            PushRegister(compareResultReg);

            // Write if statement block
            _writer.WriteTag(ifBranch);
            children[1].Accept(this);
            _writer.WriteInstruction(Instructions.J, endBranch);

            // Write else statement block
            _writer.WriteTag(elseBranch);
            children[2].Accept(this);

            // Write end
            _writer.WriteTag(endBranch);

        }

        public void Visit(WhileNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            var children = n.GetChildren();
            _writer.WriteComment("While Loop");

            var beginBranch = $"WhileBranch_begin_{_branchCounter}";
            var endBranch = $"WhileBranch_end_{_branchCounter}";
            ++_branchCounter;

            // Write begin branch
            _writer.WriteTag(beginBranch);

            // Write compare operations
            children[0].Accept(this);

            // Write jump logic
            var compareResultVar = children[0].TemporaryVariableName;
            var compareResultOffset = table.MemoryLayout.GetOffset(compareResultVar);
            var compareResultReg = PopRegister();

            _writer.WriteInstruction(Instructions.Lw, compareResultReg, $"{compareResultOffset}({FSPReg})");
            _writer.WriteInstruction(Instructions.Bz, compareResultReg, endBranch);
            PushRegister(compareResultReg);

            // Write statement block
            children[1].Accept(this);
            _writer.WriteInstruction(Instructions.J, beginBranch);

            _writer.WriteTag(endBranch);
        }

        public void Visit(BoolExpressionNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;

            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }

            var compareOp = ((CompareOpNode)children[1]).CompareOpType;
            Instructions instruction;
            switch (compareOp)
            {
                case CompareOpType.Equals:
                    instruction = Instructions.Ceq;
                    break;
                case CompareOpType.NotEquals:
                    instruction = Instructions.Cne;
                    break;
                case CompareOpType.GreaterThan:
                    instruction = Instructions.Cgt;
                    break;
                case CompareOpType.LessThan:
                    instruction = Instructions.Clt;
                    break;
                case CompareOpType.GreaterThanEqual:
                    instruction = Instructions.Cge;
                    break;
                case CompareOpType.LessThanEqual:
                    instruction = Instructions.Clt;
                    break;
                default:
                    throw new InvalidOperationException("Unknown boolexpr op");
            }

            var lhsVar = children[0].TemporaryVariableName;
            var rhsVar = children[2].TemporaryVariableName;
            var resultVar = n.TemporaryVariableName;

            var lhsOffset = table.MemoryLayout.GetOffset(lhsVar);
            var rhsOffset = table.MemoryLayout.GetOffset(rhsVar);
            var resultOffset = table.MemoryLayout.GetOffset(resultVar);

            _writer.WriteComment($"CompareOp ({compareOp})");
            var lhsReg = PopRegister();
            var rhsReg = PopRegister();
            var resultReg = PopRegister();

            _writer.WriteInstruction(Instructions.Lw, lhsReg, $"{lhsOffset}({FSPReg})");
            _writer.WriteInstruction(Instructions.Lw, rhsReg, $"{rhsOffset}({FSPReg})");
            _writer.WriteInstruction(instruction, resultReg, lhsReg, rhsReg);
            _writer.WriteInstruction(Instructions.Sw, $"{resultOffset}({FSPReg})", resultReg);

            PushRegister(resultReg);
            PushRegister(rhsReg);
            PushRegister(lhsReg);
        }

        public void Visit(CompareOpNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ReadNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child._ReturnRawAddress = true;
                child.Accept(this);
            }

            var valueVarVar = children[0].TemporaryVariableName;
            var valueVarOffset = table.MemoryLayout.GetOffset(valueVarVar);

            // NOTE(AFL): Code adapted from the util.m file. Maybe make it into a function.
            var getint1 = $"getint1_{_readLabelCounter}";
            var getint2 = $"getint2_{_readLabelCounter}";
            var getint3 = $"getint3_{_readLabelCounter}";
            var getint4 = $"getint4_{_readLabelCounter}";
            var getint5 = $"getint5_{_readLabelCounter}";
            var getint6 = $"getint6_{_readLabelCounter}";
            var getint9 = $"getint9_{_readLabelCounter}";
            var getintEnd = $"getint_end_{_readLabelCounter}";
            ++_readLabelCounter;

            _writer.WriteComment("Read Op");

            var r0 = Registers.R0;
            var r1 = PopRegister();
            var r2 = PopRegister();
            var r3 = PopRegister();
            var r4 = PopRegister();

            // getint
            _writer.WriteTag(getint1);
            _writer.WriteInstruction(Instructions.Getc, r1);
            _writer.WriteInstruction(Instructions.Ceqi, r3, r1, "43");
            _writer.WriteInstruction(Instructions.Bnz, r3, getint1);
            _writer.WriteInstruction(Instructions.Ceqi, r3, r1, "45");
            _writer.WriteInstruction(Instructions.Bz, r3, getint2);
            _writer.WriteInstruction(Instructions.Addi, r4, r0, "1");
            _writer.WriteInstruction(Instructions.J, getint1);
            _writer.WriteTag(getint2);
            _writer.WriteInstruction(Instructions.Clti, r3, r1, "48");
            _writer.WriteInstruction(Instructions.Bnz, r3, getint3);
            _writer.WriteInstruction(Instructions.Cgti, r3, r1, "57");
            _writer.WriteInstruction(Instructions.Bnz, r3, getint3);
            _writer.WriteInstruction(Instructions.Sb, $"{getint9}({r2})", r1);
            _writer.WriteInstruction(Instructions.Addi, r2, r2, "1");
            _writer.WriteInstruction(Instructions.J, getint1);
            _writer.WriteTag(getint3);
            _writer.WriteInstruction(Instructions.Sb, $"{getint9}({r2})", r0);
            _writer.WriteInstruction(Instructions.Add, r1, r0, r0);
            _writer.WriteInstruction(Instructions.Add, r2, r0, r0);
            _writer.WriteInstruction(Instructions.Add, r3, r0, r0);
            _writer.WriteTag(getint4);
            _writer.WriteInstruction(Instructions.Lb, r3, $"{getint9}({r2})");
            _writer.WriteInstruction(Instructions.Bz, r3, getint5);
            _writer.WriteInstruction(Instructions.Subi, r3, r3, "48");
            _writer.WriteInstruction(Instructions.Muli, r1, r1, "10");
            _writer.WriteInstruction(Instructions.Add, r1, r1, r3);
            _writer.WriteInstruction(Instructions.Addi, r2, r2, "1");
            _writer.WriteInstruction(Instructions.J, getint4);
            _writer.WriteTag(getint5);
            _writer.WriteInstruction(Instructions.Bz, r4, getint6);
            _writer.WriteInstruction(Instructions.Sub, r1, r0, r1);
            _writer.WriteTag(getint6);
            _writer.WriteInstruction(Instructions.J, getintEnd);
            _writer.WriteTag(getint9);
            _writer.WriteInstruction(Instructions.Res, "12");
            _writer.WriteInstruction(Instructions.Align);
            _writer.WriteTag(getintEnd);

            // Store value we got
            // r12 has address to value to store in

            _writer.WriteInstruction(Instructions.Sw, $"0({Registers.R12})", r1);

            PushRegister(r4);
            PushRegister(r3);
            PushRegister(r2);
            PushRegister(r1);
        }

        public void Visit(WriteNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }

            var valueVar = children[0].TemporaryVariableName;
            var valueOffset = table.MemoryLayout.GetOffset(valueVar);

            // NOTE(AFL): Code adapted from the util.m file. Maybe make it into a function.
            var putint1 = $"putint1_{_writeLabelCounter}";
            var putint2 = $"putint2_{_writeLabelCounter}";
            var putint9 = $"putint9_{_writeLabelCounter}";
            var putintEnd = $"putint_end_{_writeLabelCounter}";
            ++_writeLabelCounter;

            _writer.WriteComment("Write Op");

            var r0 = Registers.R0;
            var r1 = PopRegister();
            var r2 = PopRegister();
            var r3 = PopRegister();
            var r4 = PopRegister();

            // Load value to write
            _writer.WriteInstruction(Instructions.Lw, r1, $"{valueOffset}({FSPReg})");

            // putint
            _writer.WriteInstruction(Instructions.Cge, r3, r1, r0);
            _writer.WriteInstruction(Instructions.Bnz, r3, putint1);
            _writer.WriteInstruction(Instructions.Sub, r1, r0, r1);
            _writer.WriteTag(putint1);
            _writer.WriteInstruction(Instructions.Modi, r4, r1, "10");
            _writer.WriteInstruction(Instructions.Addi, r4, r4, "48");
            _writer.WriteInstruction(Instructions.Divi, r1, r1, "10");
            _writer.WriteInstruction(Instructions.Sb, $"{putint9}({r2})", r4);
            _writer.WriteInstruction(Instructions.Addi, r2, r2, "1");
            _writer.WriteInstruction(Instructions.Bnz, r1, putint1);
            _writer.WriteInstruction(Instructions.Bnz, r3, putint2);
            _writer.WriteInstruction(Instructions.Addi, r3, r0, "45");
            _writer.WriteInstruction(Instructions.Sb, $"{putint9}({r2})", r3);
            _writer.WriteInstruction(Instructions.Addi, r2, r2, "1");
            _writer.WriteInstruction(Instructions.Add, r1, r0, r0);
            _writer.WriteTag(putint2);
            _writer.WriteInstruction(Instructions.Subi, r2, r2, "1");
            _writer.WriteInstruction(Instructions.Lb, r1, $"{putint9}({r2})");
            _writer.WriteInstruction(Instructions.Putc, r1);
            _writer.WriteInstruction(Instructions.Bnz, r2, putint2);
            _writer.WriteInstruction(Instructions.J, putintEnd);
            _writer.WriteTag(putint9);
            _writer.WriteInstruction(Instructions.Res, "12");
            _writer.WriteInstruction(Instructions.Align);
            _writer.WriteTag(putintEnd);
            _writer.WriteInstruction(Instructions.Sub, r1, r1, r1);
            _writer.WriteInstruction(Instructions.Addi, r1, r1, "10");
            _writer.WriteInstruction(Instructions.Putc, r1);

            PushRegister(r4);
            PushRegister(r3);
            PushRegister(r2);
            PushRegister(r1);
        }

        // TODO(AFL): Redo this such that r13 contains absolute address of result.
        // IDEA: put result in tempvar, pass on absolute address to it
        public void Visit(ReturnNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }

            var valueVar = children[0].TemporaryVariableName;
            var valueOffset = table.MemoryLayout.GetOffset(valueVar);

            var r13 = Registers.R13;
            var r15 = Registers.R15;

            // Set return value register to absolute address of return value
            _writer.WriteInstruction(Instructions.Sub, r13, r13, r13);
            _writer.WriteInstruction(Instructions.Add, r13, r13, FSPReg);
            _writer.WriteInstruction(Instructions.Addi, r13, r13, $"{valueOffset}");

            // Jump to return address
            _writer.WriteInstruction(Instructions.Lw, r15, $"-4({FSPReg})");
            _writer.WriteInstruction(Instructions.Jr, r15);
        }

        // Goes through the call chain and writes the code for it
        // Sets the initial value for the callchain pointer (r12)
        // Writes the code for the subcalls
        private void WriteCallchainCode(IEnumerable<ASTNodeBase> subCallNodes, string initAddressReg)
        {
            var r12 = Registers.R12;

            _writer.WriteComment("%% Callchain");
            _writer.WriteInstruction(Instructions.Sub, r12, r12, r12);
            _writer.WriteInstruction(Instructions.Add, r12, r12, initAddressReg);

            foreach (var subCallNode in subCallNodes)
            {
                subCallNode.Accept(this);
            }
        }

        

        public void Visit(AssignmentNode n)
        {
            var children = n.GetChildren();
            var subCalls = children.SkipLast().ToList();
            var table = (FunctionSymbolTableEntry)n.SymTable;

            _writer.WriteComment($"Assignment");

            var rhsNode = children.Last();
            rhsNode.Accept(this);

            var rhsVarName = rhsNode.TemporaryVariableName;
            var rhsOffset = table.MemoryLayout.GetOffset(rhsVarName);

            WriteCallchainCode(subCalls, FSPReg); // r12 has absolute address of variable to write to.

            var finalValSize = Utils.GetTypeFullSize(_globalSymbolTable, subCalls.Last().ExprType);
            var srcReg = Registers.R12;
            var dstReg = PopRegister();
            var sizeReg = PopRegister();

            _writer.WriteInstruction(Instructions.Addi, sizeReg, sizeReg, $"{finalValSize}");
            _writer.WriteInstruction(Instructions.Add, dstReg, dstReg, FSPReg);
            _writer.WriteInstruction(Instructions.Addi, dstReg, dstReg, $"{rhsOffset}");

            // src dst inverted, because bugs
            WriteMultiByteCopy(dstReg, srcReg, sizeReg);

            PushRegister(sizeReg);
            PushRegister(dstReg);
        }

        public void Visit(VarFuncCallNode n)
        {
            var children = n.GetChildren();
            var table = (FunctionSymbolTableEntry)n.SymTable;

            _writer.WriteComment("Var Func Call");
            WriteCallchainCode(children, FSPReg);

            // r12 points to value, crate local copy
            var valSize = Utils.GetTypeFullSize(_globalSymbolTable, n.ExprType);
            var destVarName = n.TemporaryVariableName;
            var destVarOffset = table.MemoryLayout.GetOffset(destVarName);
            var srcAddrReg = Registers.R12;
            var destAddrReg = PopRegister();
            var valSizeReg = PopRegister();

            _writer.WriteInstruction(Instructions.Addi, valSizeReg, valSizeReg, $"{valSize}");
            _writer.WriteInstruction(Instructions.Add, destAddrReg, destAddrReg, FSPReg);
            _writer.WriteInstruction(Instructions.Addi, destAddrReg, destAddrReg, $"{destVarOffset}");

            if (!n._ReturnRawAddress)
            {
                WriteMultiByteCopy(srcAddrReg, destAddrReg, valSizeReg);
            }

            PushRegister(valSizeReg);
            PushRegister(destAddrReg);
        }

        public void Visit(FuncCallNode n)
        {
            var children = n.GetChildren();
            WriteCallchainCode(children, FSPReg);
        }

        private void WriteMultiByteCopy(string srcReg, string dstReg, string sizeReg)
        {
            _writer.WriteComment("- MultiByteCopy");
            var copyTag = $"multi_byte_copy_{_copyLabelCounter}";
            var copyEndTag = $"multi_byte_copy_end_{_copyLabelCounter++}";

            var counterReg = PopRegister();
            var currentValReg = PopRegister();
            var evalResultReg = PopRegister();
            var currentSrcPtrReg = PopRegister();
            var currentDstPtrReg = PopRegister();

            _writer.WriteInstruction(Instructions.Add, currentDstPtrReg, currentDstPtrReg, dstReg); // set dst[0] addr = dstReg 
            _writer.WriteInstruction(Instructions.Add, currentSrcPtrReg, currentSrcPtrReg, srcReg); // set src[0] addr = srcReg 

            _writer.WriteTag(copyTag);
            _writer.WriteComment("-- while (i < valSizeReg)");
            _writer.WriteInstruction(Instructions.Clt, evalResultReg, counterReg, sizeReg); // while (i < valSizeReg)
            _writer.WriteInstruction(Instructions.Bz, evalResultReg, copyEndTag);           // {

            _writer.WriteComment("-- {\n% --- dst[i] = src[i]");
            _writer.WriteInstruction(Instructions.Lw, currentValReg, $"0({currentSrcPtrReg})"); //
            _writer.WriteInstruction(Instructions.Sw, $"0({currentDstPtrReg})", currentValReg); // dst[i] = src[i]
            _writer.WriteComment("--- i++");
            _writer.WriteInstruction(Instructions.Addi, currentSrcPtrReg, currentSrcPtrReg, "4"); //
            _writer.WriteInstruction(Instructions.Addi, currentDstPtrReg, currentDstPtrReg, "4"); // i++

            _writer.WriteComment("-- }");
            _writer.WriteInstruction(Instructions.Addi, counterReg, counterReg, "4");         
            _writer.WriteInstruction(Instructions.J, copyTag); // }
            _writer.WriteTag(copyEndTag);

            PushRegister(currentSrcPtrReg);
            PushRegister(currentDstPtrReg);
            PushRegister(evalResultReg);
            PushRegister(currentValReg);
            PushRegister(counterReg);
        }

        public void Visit(SubFuncCallNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }

            var callerTable = (FunctionSymbolTableEntry)n.CallerTable;
            var funcTable = (FunctionSymbolTableEntry)n.SecondarySymTable;
            var funcReturnValSize = Utils.GetTypeFullSize(_globalSymbolTable, (funcTable.ReturnType.Lexeme, new List<int>()));
            var tag = Utils.GetTag(funcTable);

            var frameSize = funcTable.MemoryLayout.TotalSize;
            var oldFSPReg = PopRegister();

            var localReturnValVar = n.TemporaryVariableName;
            var localReturnValOffset = callerTable.MemoryLayout.GetOffset(localReturnValVar);

            var r0 = Registers.R0;
            var r12 = Registers.R12;
            var r13 = Registers.R13;
            var r15 = Registers.R15;
            _writer.WriteComment("SUB FUNC CALL");

            // Set the new FSP reg and set self addr
            _writer.WriteComment("- create frame");
            _writer.WriteInstruction(Instructions.Add, oldFSPReg, r0, FSPReg);
            _writer.WriteInstruction(Instructions.Addi, FSPReg, FSPReg, $"{frameSize}");

            //TODO(AFL) setSelfAddr
            var selfAddrOffset = -8;
            _writer.WriteInstruction(Instructions.Sw, $"{selfAddrOffset}({FSPReg})", r12);

            // Copy arguments
            _writer.WriteComment("- copy args");

            var givenParamTempVarNames = ((FuncCallParamsNode)children.Last()).ParamTempVarNames; // Params given
            var funcParamNames = funcTable.Params.Select(x => x.Name).ToList(); // variables used in the function
            for (int i = 0; i < funcParamNames.Count; ++i)
            {
                var givenParamAddrReg = PopRegister();
                var funcParamAddrReg = PopRegister();
                var paramSizeReg = PopRegister();

                var givenParamSize = callerTable.MemoryLayout.GetTypeSize(givenParamTempVarNames[i]);
                var givenParamOffset = callerTable.MemoryLayout.GetOffset(givenParamTempVarNames[i]);
                var funcParamOffset = funcTable.MemoryLayout.GetOffset(funcParamNames[i]);

                _writer.WriteInstruction(Instructions.Addi, paramSizeReg, paramSizeReg, $"{givenParamSize}");
                _writer.WriteInstruction(Instructions.Add, givenParamAddrReg, givenParamAddrReg, oldFSPReg);
                _writer.WriteInstruction(Instructions.Addi, givenParamAddrReg, givenParamAddrReg, $"{givenParamOffset}");
                _writer.WriteInstruction(Instructions.Add, funcParamAddrReg, funcParamAddrReg, FSPReg);
                _writer.WriteInstruction(Instructions.Addi, funcParamAddrReg, funcParamAddrReg, $"{funcParamOffset}");

                WriteMultiByteCopy(givenParamAddrReg, funcParamAddrReg, paramSizeReg);

                PushRegister(paramSizeReg);
                PushRegister(funcParamAddrReg);
                PushRegister(givenParamAddrReg);
            }


            // JUMP!
            _writer.WriteComment("- jump to func");
            _writer.WriteInstruction(Instructions.Jl, r15, tag);

            // Ok we're back, unset FSP
            _writer.WriteComment("- unset FSP");
            _writer.WriteInstruction(Instructions.Subi, FSPReg, FSPReg, $"{frameSize}");

            // set r12 to absolute address of result
            _writer.WriteComment("- set r12 (callchain ptr)");
            _writer.WriteInstruction(Instructions.Sub, r12, r12, r12);
            _writer.WriteInstruction(Instructions.Add, r12, r0, FSPReg);
            _writer.WriteInstruction(Instructions.Addi, r12, r12, $"{localReturnValOffset}");

            // Copy result from other frame to this frame
            var valSizeReg = PopRegister();

            _writer.WriteComment("- copy result");
            _writer.WriteInstruction(Instructions.Addi, valSizeReg, r0, $"{funcReturnValSize}");
            WriteMultiByteCopy(r13, r12, valSizeReg);

            PushRegister(valSizeReg);
            PushRegister(oldFSPReg);
        }

        public void Visit(SubVarCallNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }

            var callChainPointerReg = Registers.R12;
            var varName = n.VarName;
            int varOffset;
            (string type, List<int> dims) varType;
            int typeSize;
            FunctionSymbolTableEntry tableForIndexing;

            switch (n.SymTable)
            {
                case FunctionSymbolTableEntry f:
                    {
                        if (f.MemoryLayout.Contains(varName))
                        {
                            varOffset = f.MemoryLayout.GetOffset(varName);
                            varType = f.MemoryLayout.GetVarType(varName);
                            typeSize = f.MemoryLayout.GetTypeSize(varName);
                        }
                        else
                        {
                            var classTable = _globalSymbolTable.GetClassSymbolTableByName(f.ScopeSpec);
                            varOffset = classTable.MemoryLayout.GetOffset(varName);
                            varType = classTable.MemoryLayout.GetVarType(varName);
                            typeSize = classTable.MemoryLayout.GetTypeSize(varName);

                            _writer.WriteInstruction(Instructions.Lw, callChainPointerReg, $"-8({FSPReg})");
                        }
                        
                    }
                    tableForIndexing = f;
                    break;
                case ClassSymbolTable c:
                    varOffset = c.MemoryLayout.GetOffset(varName);
                    varType = c.MemoryLayout.GetVarType(varName);
                    typeSize = c.MemoryLayout.GetTypeSize(varName);
                    tableForIndexing = (FunctionSymbolTableEntry)n.SecondarySymTable;
                    break;
                default:
                    throw new InvalidOperationException("Unknown table type");
            }
            
            _writer.WriteComment("SUB VAR CALL");

            // Get variable address
            _writer.WriteComment("Compute absolute address of variable, (we don't have lea...)");
            var absoluteAddressReg = PopRegister();
            _writer.WriteInstruction(Instructions.Add, absoluteAddressReg, absoluteAddressReg, callChainPointerReg); // grab callchain address
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
                    var indexOffset = tableForIndexing.MemoryLayout.GetOffset(indices.FastReverse().ToList()[i]);
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

            //NOTE: R12 has address now
            // Store absolute address into temp var associated to this SubVarCall
            //_writer.WriteComment("Storing final address");
            //var tempVarOffset = table.MemoryLayout.GetOffset(n.TemporaryVariableName);
            //_writer.WriteInstruction(Instructions.Sw, $"{tempVarOffset}({FSPReg})", absoluteAddressReg);
            _writer.WriteInstruction(Instructions.Add, callChainPointerReg, Registers.R0, absoluteAddressReg);
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
                n.ParamTempVarNames.Add(child.TemporaryVariableName);
            }
        }

        public void Visit(ExpressionNode n)
        {
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
                n.TemporaryVariableName = child.TemporaryVariableName;
                child._ReturnRawAddress = n._ReturnRawAddress;
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
            _writer.WriteInstruction(instruction, destReg, op2Reg, op1Reg);
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
                child._ReturnRawAddress = n._ReturnRawAddress;
            }
        }

        

        public void Visit(MainFuncNode n)
        {
            var table = (FunctionSymbolTableEntry)n.SymTable;
            var frameSize = table.MemoryLayout.TotalSize;

            _writer.WriteComment("----------------------------------------\n% Start of the program\n% ----------------------------------------");
            _writer.WriteInstruction(Instructions.Align);
            _writer.WriteInstruction(Instructions.Entry);
            _writer.WriteComment("Set stack pointer to initial value (baseaddr)");
            _writer.WriteInstruction(Instructions.Addi, Registers.R14, Registers.R14, Tags.BaseAddr);

            _writer.WriteComment("Set FSP for main function");
            _writer.WriteInstruction(Instructions.Addi, FSPReg, FSPReg, frameSize.ToString());
            _writer.WriteTag("main");

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
    }
}
