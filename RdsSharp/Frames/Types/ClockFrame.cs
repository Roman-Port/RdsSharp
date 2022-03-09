using System;

namespace RdsSharp.Frames.Types
{
    public class ClockFrame : RdsFrame
    {
        public ClockFrame(ulong raw) : base(raw) {}

        public int Hour
        {
            get => ReadInt(47, 5);
            set => WriteInt(47, 5, value);
        }
    
        public int Minute
        {
            get => ReadInt(52, 6);
            set => WriteInt(52, 6, value);
        }
    
        public bool LocalTimeSign
        {
            get => ReadBool(58, 1);
            set => WriteBool(58, 1, value);
        }
    
        public int LocalTimeOffset
        {
            get => ReadInt(59, 5);
            set => WriteInt(59, 5, value);
        }
    
        public int DayCode
        {
            get => ReadInt(30, 17);
            set => WriteInt(30, 17, value);
        }
    

    }
}