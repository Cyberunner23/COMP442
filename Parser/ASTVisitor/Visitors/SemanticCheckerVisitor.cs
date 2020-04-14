using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Parser.AST;
using Parser.AST.Nodes;
using Parser.SymbolTable;
using Parser.SymbolTable.Class;
using Parser.SymbolTable.Function;
using Parser.Utils;

namespace Parser.ASTVisitor.Visitors
{
    public class SemanticCheckerVisitor : IVisitor
    {
        // Find a batter place for this
        public const string BoolType = "bool";

        private StreamWriter _errorStream;
        private GlobalSymbolTable _globalTable;

        public SemanticCheckerVisitor(StreamWriter errorStream, GlobalSymbolTable globalTable)
        {
            _globalTable = globalTable;
            _errorStream = errorStream;
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
            var children = n.GetChildren();
            foreach (var child in children)
            {
                child.Accept(this);
            }
        }

        public void Visit(ClassDeclNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.Table;
                node.Accept(this);
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

        public void Visit(IdentifierNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(FuncDefNode n)
        {
            var funcBody = (FuncBodyNode)n.GetChildren().Last();
            funcBody.SymTable = n.Table;
            funcBody.Accept(this);
        }

        public void Visit(FuncBodyNode n)
        {
            var statements = (StatementsNode)n.GetChildren().Last();
            statements.SymTable = n.SymTable;
            statements.Accept(this);
        }

        #region Statements
        public void Visit(StatementsNode n)
        {
            var children = n.GetChildren();

            var table = (FunctionSymbolTableEntry)n.SymTable;
            var returnType = table.ReturnType?.Lexeme ?? "";

            if (!string.Equals(returnType, TypeConstants.VoidType) && !string.IsNullOrEmpty(returnType) && children.Where(x => x is ReturnNode).Count() == 0)
            {
                _errorStream.WriteLine($"Function {table.ToStringSignature()} returns an {returnType}, however no return statement was found.");
            }

            foreach (var node in children)
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(IfNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(WhileNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(ReadNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(WriteNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(ReturnNode n)
        {
            var children = n.GetChildren();
            foreach (var node in children)
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }

            var table = (FunctionSymbolTableEntry)n.SymTable;
            if (!string.Equals(children.Last().ExprType.Type, table.ReturnType?.Lexeme ?? "") && !(children.Last().ExprType.Type == null && string.Equals(table.ReturnType?.Lexeme ?? "", "void")))
            {
                _errorStream.WriteLine($"Type of value for return is invalid (line: {n.Token.StartLine}), expected: {table.ReturnType?.Lexeme ?? "void"}, received: {children.Last().ExprType.Type}");
            }
        }
        #endregion


        public void Visit(BoolExpressionNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(NotNode n)
        {
            var child = n.GetChildren().Single();
            child.Accept(this);
            n.ExprType = child.ExprType;
        }

        public void Visit(SignNode n)
        {
            var child = n.GetChildren().Single();
            child.Accept(this);
            n.ExprType = child.ExprType;
        }



        public void Visit(AddOpNode n)
        {
            var children = n.GetChildren();
            foreach (var node in children)
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }

            if (children[0].ExprType.Dims.Count > 0 || children[1].ExprType.Dims.Count > 0)
            {
                _errorStream.WriteLine($"Cannot multiply/divide arrays! ({n.Token.StartLine}:{n.Token.StartColumn})");
            }
            else if (!string.Equals(children[0].ExprType.Type, children[1].ExprType.Type))
            {
                _errorStream.WriteLine($"Operand types don't match! {children[1].ExprType.Type} <-> {children[0].ExprType.Type} ({n.Token.StartLine}:{n.Token.StartColumn})");
            }

            n.ExprType = children[0].ExprType;
            
        }

        public void Visit(MultOpNode n)
        {

            var children = n.GetChildren();
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }

            if (!string.Equals(children[0].ExprType.Type, TypeConstants.IntType) 
                && !string.Equals(children[1].ExprType.Type, TypeConstants.IntType)
                && !string.Equals(children[0].ExprType.Type, TypeConstants.FloatType)
                && !string.Equals(children[1].ExprType.Type, TypeConstants.FloatType))
            {
                _errorStream.WriteLine($"Operation must be done with numerical operands! ({n.Token.StartLine}:{n.Token.StartColumn})");
            }

            if (children[0].ExprType.Dims.Count > 0 || children[1].ExprType.Dims.Count > 0)
            {
                _errorStream.WriteLine($"Cannot multiply/divide arrays! ({n.Token.StartLine}:{n.Token.StartColumn})");
            }
            else if (!string.Equals(children[0].ExprType.Type, children[1].ExprType.Type))
            {
                _errorStream.WriteLine($"Operand types don't match! {children[1].ExprType.Type} <-> {children[0].ExprType.Type} ({n.Token.StartLine}:{n.Token.StartColumn})");
            }

            n.ExprType = children[0].ExprType;
        }







        public void Visit(NullNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(MemberDeclsNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }



        public void Visit(InheritListNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }



        public void Visit(TypeNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(FuncParamListNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(ArrayDimListNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(ArrayDimNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(IntNumNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }



        public void Visit(LocalScopeNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }



        public void Visit(VarDeclNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }




        public void Visit(CompareOpNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }









        public void Visit(FuncCallNode n)
        {
            var children = n.GetChildren();

            var first = children.First();
            first.SymTable = n.SymTable;
            first.SecondarySymTable = n.SymTable;
            first.CallerTable = n.SymTable;
            first.Accept(this);

            var currentScopeSpec = first.ScopeSpec;
            foreach (var node in children.Skip(1))
            {
                if (string.IsNullOrEmpty(currentScopeSpec))
                {
                    _errorStream.WriteLine($"ASSERT: Use of variable with no scopespec.");
                    break;
                }

                var classTable = _globalTable.GetClassSymbolTableByName(currentScopeSpec);
                if (classTable == null)
                {
                    _errorStream.WriteLine($"ScopeSpec \"{currentScopeSpec}\" refers to a non existing class.");
                    break;
                }

                node.SymTable = classTable;
                node.SecondarySymTable = n.SymTable;
                node.CallerTable = n.SymTable;
                node.Accept(this);
                currentScopeSpec = node.ScopeSpec;
            }
        }

        public void Visit(VarFuncCallNode n)
        {
            var children = n.GetChildren();

            var first = children.First();
            first.SymTable = n.SymTable;
            first.SecondarySymTable = n.SymTable;
            first.CallerTable = n.SymTable;
            first.Accept(this);

            var currentScopeSpec = first.ScopeSpec;
            foreach (var node in children.Skip(1))
            {
                if (!string.IsNullOrEmpty(currentScopeSpec))
                {
                    var classTable = _globalTable.GetClassSymbolTableByName(currentScopeSpec);
                    if (classTable == null)
                    {
                        _errorStream.WriteLine($"ScopeSpec \"{currentScopeSpec}\" refers to a non existing class.");
                        break;
                    }

                    node.SymTable = classTable;
                    node.SecondarySymTable = n.SymTable;
                }
                else
                {
                    node.SymTable = first.SymTable;
                    node.SecondarySymTable = n.SymTable;
                }
                
                node.Accept(this);
                currentScopeSpec = node.ScopeSpec;
            }

            n.ExprType = children.Last().ExprType;
        }

        public void Visit(SubVarCallNode n)
        {
            var children = n.GetChildren();
            children[0].SymTable = n.SymTable;
            children[0].Accept(this);
            children[1].SymTable = n.SecondarySymTable;
            children[1].Accept(this);

            var varNameToken = ((IdentifierNode)children[0]).Token;
            n.VarName = varNameToken.Lexeme;
            n.NumDims = ((IndicesNode)children[1]).NumDims;

            Dictionary<string, (string, List<int>)> varsInScope;
            switch (n.SymTable)
            {
                case FunctionSymbolTableEntry f:
                    {
                        var classTable = _globalTable.GetClassSymbolTableByName(f.ScopeSpec);
                        Dictionary<string, (string, List<int>)> classVars = classTable?.GetVariablesInScope() ?? new Dictionary<string, (string, List<int>)>();
                        var funcVars = f.GetVariablesInScope();
                        varsInScope = new Dictionary<string, (string, List<int>)>();

                        foreach (var v in classVars)
                        {
                            varsInScope.Add(v.Key, v.Value);
                        }

                        foreach (var v in funcVars)
                        {
                            if (!varsInScope.ContainsKey(v.Key))
                            {
                                varsInScope.Add(v.Key, v.Value);
                            }
                            else
                            {
                                _errorStream.WriteLine($"Variable '{v.Key}' used in {f.ToStringSignature()} is already defined in the class");
                            }
                        }
                    }
                    break;
                case ClassSymbolTable s:
                    {
                        varsInScope = s.GetVariablesInScope();
                    }
                    break;
                default:
                    throw new InvalidOperationException("Unknown table entry type found");
            }

            (string Type, List<int> Dims) typeDims;
            if (!varsInScope.TryGetValue(n.VarName, out typeDims))
            {
                _errorStream.WriteLine($"Use of undeclared variable \"{n.VarName}\" ({varNameToken.StartLine}:{varNameToken.StartColumn})");
            }
            else
            {
                n.ScopeSpec = typeDims.Type;
                n.ExprType = typeDims;

                if (n.NumDims > typeDims.Dims.Count)
                {
                    _errorStream.WriteLine($"Data member \"{n.VarName}\" used with more dims than defined! max: {typeDims.Dims.Count}, had: {n.NumDims}");
                }

                // Say var defined as float a[5][5][5]
                // and used a[2], the type of the expression is now float[5][5]
                n.ExprType = (typeDims.Type, typeDims.Dims.Skip(n.NumDims).ToList());
            }
        }

        public void Visit(SubFuncCallNode n)
        {
            var children = n.GetChildren();

            var token = ((IdentifierNode)children[0]).Token;
            n.FuncName = token.Lexeme;

            List<FunctionSymbolTableEntry> candidateFuncsInScope;
            switch (n.SymTable)
            {
                case FunctionSymbolTableEntry f:
                    {

                        candidateFuncsInScope = new List<FunctionSymbolTableEntry>();
                        if (!string.IsNullOrEmpty(f.ScopeSpec))
                        {
                            ClassSymbolTable s = _globalTable.GetClassSymbolTableByName(f.ScopeSpec);
                            var funcsInClass = s.GetFunctions().Where(x => string.Equals(x.Name, n.FuncName)).ToList();
                            candidateFuncsInScope = candidateFuncsInScope.Concat(funcsInClass).ToList();
                        }

                        var candidateFuncsInGlobalScope = _globalTable.FunctionSymbolTable.Entries
                            .Cast<FunctionSymbolTableEntry>()
                            .Where(x => string.Equals(x.Name, n.FuncName) && string.IsNullOrEmpty(x.ScopeSpec)).ToList();

                        // Same name, in class or free function
                        //candidateFuncsInScope = s.GetFunctions().Where(x => string.Equals(x.Name, n.FuncName)).ToList();
                        candidateFuncsInScope = candidateFuncsInScope.Concat(candidateFuncsInGlobalScope).ToList();
                    }
                    break;
                case ClassSymbolTable s:
                    {
                        // Same name, in class
                        candidateFuncsInScope = s.GetFunctions().Where(x => string.Equals(x.Name, n.FuncName)).ToList();
                    }
                    break;
                default:
                    throw new InvalidOperationException("Unknown table entry type found");
            }

            if (candidateFuncsInScope.Count == 0)
            {
                _errorStream.WriteLine($"Use of undefined function: \"{n.FuncName}\" ({token.StartLine}:{token.StartColumn})");
            }

            // Visit FuncCallParamsNode to get parameter types used
            var funcParams = (FuncCallParamsNode)children[1];
            funcParams.CallerTable = n.CallerTable;
            funcParams.Accept(this);
            var funcParamTypes = funcParams.ParamsTypes;

            FunctionSymbolTableEntry matchingFunc = null;
            foreach (var candidateFunc in candidateFuncsInScope)
            {
                if (candidateFunc.Params.Count != funcParamTypes.Count)
                {
                    continue;
                }

                bool matches = true;
                for (int i = 0; i < candidateFunc.Params.Count; ++i)
                {
                    (string type, List<int> dims) unpacked = funcParamTypes[i];

                    if (!string.Equals(candidateFunc.Params[i].Type.type, unpacked.type))
                    {
                        matches = false;
                        break;
                    }

                    if (candidateFunc.Params[i].Type.dims.Count == unpacked.dims.Count && candidateFunc.Params[i].Type.dims.All(x => x == 0))
                    {
                        matches = true;
                        break;
                    }

                    if (!candidateFunc.Params[i].Type.dims.SequenceEqual(unpacked.dims))
                    {
                        matches = false;
                        break;
                    }
                }

                if (matches)
                {
                    matchingFunc = candidateFunc;
                    break;
                }
            }

            if (matchingFunc == null)
            {
                _errorStream.WriteLine($"Use of function: \"{n.FuncName}\" ({token.StartLine}:{token.StartColumn}) with invalid parameters (no matching overload was found)");
            }
            else
            {
                n.CallerTable = n.SecondarySymTable;
                n.SecondarySymTable = matchingFunc;
                n.ScopeSpec = matchingFunc.ReturnType.Lexeme;
                n.ExprType = (matchingFunc.ReturnType.Lexeme, new List<int>());
            }
        }





        public void Visit(AssignmentNode n)
        {
            var children = n.GetChildren();

            var rhs = children.Last();
            rhs.SymTable = n.SymTable;
            rhs.SecondarySymTable = n.SymTable;
            rhs.Accept(this);
            var rhsType = rhs.ExprType;

            var first = children.First();
            first.SymTable = n.SymTable;
            first.SecondarySymTable = n.SymTable;
            first.Accept(this);
            var currentScopeSpec = first.ScopeSpec;

            var line = ((IdentifierNode)first.LeftmostChildNode).Token.StartLine;

            for (int i = 1; i < children.Count - 1; ++i)
            {
                if (string.IsNullOrEmpty(currentScopeSpec))
                {
                    _errorStream.WriteLine($"Use of variable with no scopespec.");
                    break;
                }

                var classTable = _globalTable.GetClassSymbolTableByName(currentScopeSpec);
                if (classTable == null)
                {
                    _errorStream.WriteLine($"ScopeSpec \"{currentScopeSpec}\" refers to a non existing class.");
                    break;
                }

                children[i].SymTable = classTable;
                children[i].SecondarySymTable = n.SymTable;
                children[i].Accept(this);
                currentScopeSpec = children[i].ScopeSpec;
            }

            var lhsType = children[children.Count - 2].ExprType;

            if (!string.Equals(lhsType.Type, rhsType.Type) || !rhsType.Dims.SequenceEqual(lhsType.Dims))
            {
                _errorStream.WriteLine($"Assignment type missmatch! {lhsType.Type} <-> {rhsType.Type} (line: {line})");
            }
        }


        



        public void Visit(FuncCallParamsNode n)
        {
            var children = n.GetChildren();

            ITable statementsSymTable;
            ASTNodeBase currentNode = n;
            while (!(currentNode is StatementsNode))
            {
                currentNode = currentNode.ParentNode;
                if (currentNode == null)
                {
                    throw new Exception("StatementsNode is somehow not a distant parent of this node...");
                }
            }

            statementsSymTable = currentNode.SymTable;

            foreach (var node in children)
            {
                node.SymTable = statementsSymTable;
                node.Accept(this);
            }

            foreach (var child in children)
            {
                n.ParamsTypes.Add(child.ExprType);
            }
        }

        public void Visit(ExpressionNode n)
        {
            var children = n.GetChildren();
            foreach (var node in children)
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }

            if (children.Count == 3)
            {
                n.ExprType = (TypeConstants.BoolType, new List<int>());
            }
            else if (children.Count == 1)
            {
                n.ExprType = children[0].ExprType;
            }
        }

        public void Visit(ArithExprNode n)
        {
            var child = n.GetChildren().Single();

            child.SymTable = n.SymTable;
            child.Accept(this);
            n.ExprType = child.ExprType;
        }

        public void Visit(IndicesNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
                if (!string.Equals(node.ExprType.Type, TypeConstants.IntType) || node.ExprType.Dims.Count != 0)
                {
                    _errorStream.WriteLine("Expression used in array index must be of int type!");
                }
            }
        }

        public void Visit(FloatNumNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(VisibilityNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(MemberDeclNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(MainFuncNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = _globalTable.FunctionSymbolTable.Entries.Cast<FunctionSymbolTableEntry>().Where(x => string.Equals(x.Name, "main")).FirstOrDefault();
                if (node.SymTable == null)
                {
                    _errorStream.WriteLine("No FunctionSymbolTableEntry for \"main()\" found!!!");
                }

                node.Accept(this);
            }
        }
    }
}
