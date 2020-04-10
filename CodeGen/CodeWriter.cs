using System;
using System.IO;
using System.Linq;

namespace CodeGen
{
    public class CodeWriter
    {
        private StreamWriter _codeStream;

        public CodeWriter(StreamWriter codeStream)
        {
            _codeStream = codeStream;
        }

        public void WriteComment(string comment)
        {
            _codeStream.WriteLine();
            _codeStream.WriteLine($"% {comment}");
        }

        public void WriteTag(string tag)
        {
            _codeStream.WriteLine();
            _codeStream.WriteLine(tag);
        }

        public void WriteInstruction(Instructions instruction, params string[] arguments)
        {
            _codeStream.Write($"    {instruction.ToString().ToLower()} ");

            if (arguments.Length == 0)
            {
                _codeStream.WriteLine();
                return;
            }

            var numArguments = InstructionsConstants.ArgumentNumMap[instruction];
            if (numArguments != -1 && numArguments != arguments.Length)
            {
                throw new InvalidOperationException($"Instruction: '{instruction}' must be used with {numArguments} arguments");
            }

            var args = arguments.OfType<string>();
            _codeStream.Write(args.First());

            foreach (var arg in args.Skip(1))
            {
                _codeStream.Write($",{arg}");
            }

            _codeStream.WriteLine();
        }
    }
}
