using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdsSharp.Generator.Data
{
    public class ByteLayout
    {
        public string Name { get; set; } = "Default";
        public int Opcode { get; set; } = 0;
        public bool VerA { get; set; } = true;
        public bool VerB { get; set; } = false;
        public List<ByteLayoutSegment> Segments { get; set; } = new List<ByteLayoutSegment>();
        public int InheritedIndex { get; set; } = -1;

        public override string ToString()
        {
            return $"{Convert.ToString(Opcode, 2).PadLeft(4, '0')}{(VerA ? "A" : "")}{(VerB ? "B" : "")} - {Name}";
        }
    }
}
