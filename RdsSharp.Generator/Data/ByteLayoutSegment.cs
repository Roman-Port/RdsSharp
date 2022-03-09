using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdsSharp.Generator.Data
{
    public class ByteLayoutSegment
    {
        public string Title { get; set; }
        public int BitOffset { get; set; }
        public int BitWidth { get; set; }
        public ByteLayoutType BitType { get; set; }
    }
}
