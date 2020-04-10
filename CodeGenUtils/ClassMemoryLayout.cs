using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenUtils
{
    public class ClassMemoryLayoutEntry
    {
        public (string type, List<int> dims) VarType { get; set; }
        public int TypeSize { get; set; }
        public int Size { get; set; }
        public int Offset { get; set; }
    }

    public class ClassMemoryLayout
    {
        private int _currentOffset;
        public int TotalSize { get { return _currentOffset; } }

        // var name <-> (size, offset)
        public Dictionary<string, ClassMemoryLayoutEntry> OffsetMap { get; private set; }

        public ClassMemoryLayout()
        {
            _currentOffset = 0;
            OffsetMap = new Dictionary<string, ClassMemoryLayoutEntry>();
        }

        public void AddEntry((string type, List<int> dims) varType, string varName, int typeSize, int size)
        {
            OffsetMap.Add(varName, new ClassMemoryLayoutEntry()
            {
                VarType = varType,
                TypeSize = typeSize,
                Offset = _currentOffset,
                Size = size
            });
            _currentOffset += size;
        }

        public int GetOffset(string name)
        {
            return OffsetMap[name].Offset;
        }

        public int GetSize(string name)
        {
            return OffsetMap[name].Size;
        }

        public int GetTypeSize(string name)
        {
            return OffsetMap[name].TypeSize;
        }

        public (string type, List<int> dims) GetVarType(string name)
        {
            return OffsetMap[name].VarType;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            var list = OffsetMap.ToList();
            list.Reverse();

            sb.AppendLine("-------------------------------------");
            sb.AppendLine($"  Offset | TypeSize | TotalSize | VariableName | Type");
            foreach (var item in list)
            {
                sb.Append($"{item.Value.Offset, 8} | {item.Value.TypeSize,8} | {item.Value.Size,9} | {item.Key, 12} | {item.Value.VarType.type}");

                foreach (var dim in item.Value.VarType.dims)
                {
                    sb.Append($"[{dim}]");
                }

                sb.AppendLine();
            }
            sb.AppendLine("-------------------------------------");

            return sb.ToString();
        }
    }
}
