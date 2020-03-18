using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            // TODO

            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }

        public void Visit(IfNode n)
        {
            //TODO 

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
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
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

            // TODO(AFL): Type check
        }


        private KeyValuePair<string, int> ExtractSubVarCallNode(SubVarCallNode node)
        {
            var children = node.GetChildren();
            var name = ((IdentifierNode)children[0]).Token.Lexeme;
            var numDims = ((IndicesNode)children[1]).GetChildren().Count;

            return new KeyValuePair<string, int>(name, numDims);
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

            if (children[0].ExprType != children[1].ExprType)
            {
                _errorStream.WriteLine("");
            }
            else
            {
                n.ExprType = children[0].ExprType;
            }
        }

        public void Visit(MultOpNode n)
        {

            var children = n.GetChildren();
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }

            if (children[0].ExprType != children[1].ExprType)
            {
                _errorStream.WriteLine("");
            }
            else
            {
                n.ExprType = children[0].ExprType;
            }
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
            first.Accept(this);

            var currentScopeSpec = first.ScopeSpec;
            foreach (var node in children.Skip(1))
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

                node.SymTable = classTable;
                node.Accept(this);
                currentScopeSpec = node.ScopeSpec;
            }
        }

        

        



















        public void Visit(VarFuncCallNode n)
        {
            var children = n.GetChildren();

            var first = children.First();
            first.SymTable = n.SymTable;
            first.Accept(this);

            var currentScopeSpec = first.ScopeSpec;
            foreach (var node in children.Skip(1))
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

                node.SymTable = classTable;
                node.Accept(this);
                currentScopeSpec = node.ScopeSpec;
            }

            n.ExprType = children.Last().ExprType;
        }

        public void Visit(AssignmentNode n)
        {
            foreach (var node in n.GetChildren())
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }


        public void Visit(SubVarCallNode n)
        {
            var children = n.GetChildren();
            foreach (var node in children)
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }

            var varNameToken = ((IdentifierNode)children[0]).Token;
            n.VarName = varNameToken.Lexeme;
            n.NumDims = ((IndicesNode)children[1]).NumDims;

            Dictionary<string, (string, List<int>)> varsInScope;
            switch (n.SymTable)
            {
                case FunctionSymbolTableEntry f:
                    {
                        n.ScopeSpec = f.ScopeSpec;
                        varsInScope = f.GetVariablesInScope()
                                                 .Concat(_globalTable.GetClassSymbolTableByName(f.ScopeSpec)
                                                                     ?.GetVariablesInScope() ?? new Dictionary<string, (string, List<int>)>())
                                                 .ToDictionary(x => x.Key, x => x.Value);
                    }
                    break;
                case ClassSymbolTable s:
                    {
                        n.ScopeSpec = s.ClassName;
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
                n.ExprType = typeDims;
                if (n.ExprType.Dims.Count != n.NumDims)
                {
                    _errorStream.WriteLine($"Data member \"{n.VarName}\" ({varNameToken.StartLine}:{varNameToken.StartColumn})" +
                        $" used with wrong number of dims, expected: {typeDims.Dims.Count}, had: {n.NumDims}");
                }
            }
        }

        public void Visit(SubFuncCallNode n)
        {
            var children = n.GetChildren();
            foreach (var node in children)
            {
                node.SymTable = n.SymTable;
                node.Accept(this);
            }

            var token = ((IdentifierNode)children[0]).Token;
            n.FuncName = token.Lexeme;

            List<FunctionSymbolTableEntry> candidateFuncsInScope;
            switch (n.SymTable)
            {
                case FunctionSymbolTableEntry f:
                    {
                        n.ScopeSpec = f.ScopeSpec;

                        // Same name, in class or free function
                        candidateFuncsInScope = _globalTable.FunctionSymbolTable.Entries
                            .Cast<FunctionSymbolTableEntry>() 
                            .Where(x => string.Equals(x.Name, n.FuncName) && (string.Equals(x.ScopeSpec, n.ScopeSpec) || string.IsNullOrEmpty(x.ScopeSpec)))
                            .ToList();
                    }
                    break;
                case ClassSymbolTable s:
                    {
                        n.ScopeSpec = s.ClassName;

                        // Same name, in class
                        candidateFuncsInScope = _globalTable.FunctionSymbolTable.Entries
                            .Cast<FunctionSymbolTableEntry>()
                            .Where(x => string.Equals(x.Name, n.FuncName) && (string.Equals(x.ScopeSpec, n.ScopeSpec) || !string.IsNullOrEmpty(x.ScopeSpec)))
                            .ToList();
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
            funcParams.Accept(this);
            var funcParamTypes = funcParams.ParamsTypes;

            var matchingFunc = candidateFuncsInScope.FirstOrDefault(x => x.Params.Select(y => y.Type).SequenceEqual(funcParamTypes));
            if (matchingFunc == null)
            {
                _errorStream.WriteLine($"Use of function: \"{n.FuncName}\" ({token.StartLine}:{token.StartColumn}) with invalid parameters (no matching overload was found)");
            }
            else
            {
                n.ExprType = (matchingFunc.ReturnType.Lexeme, new List<int>());
            }
        }

        public void Visit(FuncCallParamsNode n)
        {
            var children = n.GetChildren();
            foreach (var node in children)
            {
                node.SymTable = n.SymTable;
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
                n.ExprType = (TypeConstants.BoolType, new List<int>() { 0 });
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
                node.SymTable = n.SymTable;
                node.Accept(this);
            }
        }
    }
}
