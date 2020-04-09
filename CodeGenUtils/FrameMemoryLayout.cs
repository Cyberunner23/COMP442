using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenUtils
{
    public enum LayoutEntryType
    {
        Return,
        SelfAddr,
        Argument,
        Variable,
        TemporaryVariable
    }

    public class FrameMemoryLayout
    {
        private int _currentOffset;
        private int _currentTempVarID;

        public int TotalSize { get { return -_currentOffset; } }

        // name <-> (LayoutEntryType, size, offset)
        public Dictionary<string, (LayoutEntryType type, int size, int offset)> OffsetMap { get; private set; }

        public FrameMemoryLayout()
        {
            _currentOffset = 0;
            _currentTempVarID = 0;
            OffsetMap = new Dictionary<string, (LayoutEntryType type, int size, int offset)>();

            AddReturnEntry();
            AddSelfAddrEntry();
        }

        public int GetOffset(string name)
        {
            return OffsetMap[name].offset;
        }

        public int GetSize(string name)
        {
            return OffsetMap[name].size;
        }

        public void AddArgumentEntry(string name, int size)
        {
            AddEntry(name, LayoutEntryType.Argument, size);
        }

        public void AddVariableEntry(string name, int size)
        {
            AddEntry(name, LayoutEntryType.Variable, size);
        }

        public string AddTemporaryVariable()
        {
            string name = $"__temp_{_currentTempVarID}__";
            AddEntry(name, LayoutEntryType.TemporaryVariable, 4);
            _currentTempVarID++;

            return name;
        }

        private void AddReturnEntry()
        {
            AddEntry("__returnaddr__", LayoutEntryType.Return, 4);
        }

        private void AddSelfAddrEntry()
        {
            AddEntry("__selfaddr__", LayoutEntryType.SelfAddr, 4);
        }

        private void AddEntry(string name, LayoutEntryType type, int size)
        {
            _currentOffset -= size;
            OffsetMap.Add(name, (type, size, _currentOffset));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            var list = OffsetMap.ToList();

            sb.AppendLine("-------------------------------------");
            foreach (var item in list)
            {
                sb.AppendLine($"{item.Value.offset, 4} | {item.Value.size,4} | {item.Value.type, -17} | {item.Key}");
            }
            sb.AppendLine("-------------------------------------");

            return sb.ToString();
        }

    }
}
