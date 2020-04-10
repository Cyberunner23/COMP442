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

    public class FrameMemoryLayoutEntry
    {
        public LayoutEntryType EntryType { get; set; }
        public int TypeSize { get; set; }
        public (string type, List<int> dims) VarType { get; set; }
        public int Size { get; set; }
        public int Offset { get; set; }
    }

    public class FrameMemoryLayout
    {
        private int _currentOffset;
        private int _currentTempVarID;

        public int TotalSize { get { return -_currentOffset; } }

        // name <-> (LayoutEntryType, size, offset)
        public Dictionary<string, FrameMemoryLayoutEntry> OffsetMap { get; private set; }

        public FrameMemoryLayout()
        {
            _currentOffset = 0;
            _currentTempVarID = 0;
            OffsetMap = new Dictionary<string, FrameMemoryLayoutEntry>();

            AddReturnEntry();
            AddSelfAddrEntry();
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

        public void AddArgumentEntry((string type, List<int> dims) varType, string name, int typeSize, int size)
        {
            AddEntry(varType, name, LayoutEntryType.Argument, typeSize, size);
        }

        public void AddVariableEntry((string type, List<int> dims) varType, string name, int typeSize, int size)
        {
            AddEntry(varType, name, LayoutEntryType.Variable, typeSize, size);
        }

        public string AddTemporaryVariable()
        {
            string name = $"__temp_{_currentTempVarID}__";
            AddEntry((null, null), name, LayoutEntryType.TemporaryVariable, 4, 4);
            _currentTempVarID++;

            return name;
        }

        private void AddReturnEntry()
        {
            AddEntry((null, null), "__returnaddr__", LayoutEntryType.Return, 4, 4);
        }

        private void AddSelfAddrEntry()
        {
            AddEntry((null, null), "__selfaddr__", LayoutEntryType.SelfAddr, 4, 4);
        }

        private void AddEntry((string type, List<int> dims) varType, string name, LayoutEntryType entryType, int typeSize, int size)
        {
            _currentOffset -= size;
            OffsetMap.Add(name, new FrameMemoryLayoutEntry()
            {
                EntryType = entryType,
                VarType = varType,
                TypeSize = typeSize,
                Offset = _currentOffset,
                Size = size
            });
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            var list = OffsetMap.ToList();

            sb.AppendLine("-------------------------------------");
            sb.AppendLine($"  Offset | TypeSize | TotalSize | {"EntryType",-17} | {"VariableName", -14} | Type");
            foreach (var item in list)
            {
                if (item.Value.VarType.type == null || item.Value.VarType.dims == null)
                {
                    sb.AppendLine($"{item.Value.Offset,8} | {item.Value.TypeSize,8} | {item.Value.Size,9} | {item.Value.EntryType,-17} | {item.Key, -14} |");
                }
                else
                {
                    sb.Append($"{item.Value.Offset,8} | {item.Value.TypeSize,8} | {item.Value.Size,9} | {item.Value.EntryType,-17} | {item.Key,-14} | {item.Value.VarType.type}");

                    foreach (var dim in item.Value.VarType.dims)
                    {
                        sb.Append($"[{dim}]");
                    }

                    sb.AppendLine();
                }
                
            }
            sb.AppendLine("-------------------------------------");

            return sb.ToString();
        }

    }
}
