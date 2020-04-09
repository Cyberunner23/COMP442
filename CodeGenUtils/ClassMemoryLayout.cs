using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenUtils
{
    public class ClassMemoryLayout
    {
        private int _currentOffset;
        public int TotalSize { get { return _currentOffset; } }

        // var name <-> (size, offset)
        public Dictionary<string, (int size, int offset)> OffsetMap { get; private set; }

        public ClassMemoryLayout()
        {
            _currentOffset = 0;
            OffsetMap = new Dictionary<string, (int size, int offset)>();
        }

        public void AddEntry(string varName, int size)
        {
            OffsetMap.Add(varName, (size, _currentOffset));
            _currentOffset += size;
        }

        public int GetOffset(string name)
        {
            return OffsetMap[name].offset;
        }

        public int GetSize(string name)
        {
            return OffsetMap[name].size;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            var list = OffsetMap.ToList();
            list.Reverse();

            sb.AppendLine("-------------------------------------");
            foreach (var item in list)
            {
                sb.AppendLine($"{item.Value.offset, 4} | {item.Value.size,4} | {item.Key}");
            }
            sb.AppendLine("-------------------------------------");

            return sb.ToString();
        }
    }
}
