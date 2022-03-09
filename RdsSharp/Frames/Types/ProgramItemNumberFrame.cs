using System;

namespace RdsSharp.Frames.Types
{
    public class ProgramItemNumberFrame : RdsFrame
    {
        public ProgramItemNumberFrame(ulong raw) : base(raw) {}

        public int ProgramItemNumber
        {
            get => ReadInt(48, 16);
            set => WriteInt(48, 16, value);
        }
    

    }
}