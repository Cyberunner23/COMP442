using Parser.SymbolTable;
using Parser.SymbolTable.Function;
using Parser.Utils;
using System.Collections.Generic;
using System.Text;

namespace CodeGen
{
    static class Utils
    {
        public static IEnumerable<T> FastReverse<T>(this IList<T> items)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        public static IEnumerable<T> SkipLast<T>(this IList<T> items, int skipAmount = 1)
        {
            for (int i = 0; i < items.Count - skipAmount; ++i)
            {
                yield return items[i];
            }
        }

        public static string GetTag(FunctionSymbolTableEntry entry)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(entry.ScopeSpec))
            {
                sb.Append($"{entry.ScopeSpec}_");
            }

            sb.Append($"{entry.Name}_");

            foreach (var param in entry.Params)
            {
                sb.Append($"{param.Type.type}_");
                foreach (var dim in param.Type.dims)
                {
                    sb.Append($"{dim}_");
                }
            }

            sb.Append(entry.ReturnType.Lexeme);

            return sb.ToString();
        }

        public static int GetTypeFullSize(GlobalSymbolTable globalSymbolTable, (string type, List<int> dims) type)
        {
            int size;
            if (string.Equals(type.type, TypeConstants.IntType))
            {
                size = TypeConstants.IntTypeSize;
            }
            else if (string.Equals(type.type, TypeConstants.FloatType))
            {
                size = TypeConstants.FloatTypeSize;
            }
            else if (string.Equals(type.type, TypeConstants.VoidType))
            {
                size = 0;
            }
            else
            {
                var classTable = globalSymbolTable.GetClassSymbolTableByName(type.type);
                size = classTable.MemoryLayout.TotalSize;
            }

            foreach (var dim in type.dims)
            {
                size *= dim;
            }

            return size;
        }
    }
}
