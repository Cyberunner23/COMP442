using System;

namespace Parser.Utils
{

    // Inspired from https://stackoverflow.com/questions/2579734/get-the-type-name
    public class TypePrintUtils
    {
        public static string StringifyType(Type t)
        {
            return t.Name;
        }
    }
}
