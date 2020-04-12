using Parser.SymbolTable.Function;
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
    }
}
