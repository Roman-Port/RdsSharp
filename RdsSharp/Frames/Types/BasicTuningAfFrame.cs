using System;

namespace RdsSharp.Frames.Types
{
    public class BasicTuningAfFrame : BasicTuningFrame
    {
        public BasicTuningAfFrame(ulong raw) : base(raw) {}

        public int AlternateFreqA
        {
            get => ReadInt(32, 8);
            set => WriteInt(32, 8, value);
        }
    
        public int AlternateFreqB
        {
            get => ReadInt(40, 8);
            set => WriteInt(40, 8, value);
        }
    

    }
}