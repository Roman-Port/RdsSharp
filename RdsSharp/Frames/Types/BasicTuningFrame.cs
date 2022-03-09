using System;

namespace RdsSharp.Frames.Types
{
    public class BasicTuningFrame : RdsFrame
    {
        public BasicTuningFrame(ulong raw) : base(raw) {}

        public bool Ta
        {
            get => ReadBool(27, 1);
            set => WriteBool(27, 1, value);
        }
    
        public bool Music
        {
            get => ReadBool(28, 1);
            set => WriteBool(28, 1, value);
        }
    
        public bool Di
        {
            get => ReadBool(29, 1);
            set => WriteBool(29, 1, value);
        }
    
        public int SegmentAddress
        {
            get => ReadInt(30, 2);
            set => WriteInt(30, 2, value);
        }
    
        public char ProgramServiceA
        {
            get => ReadChar(48, 8);
            set => WriteChar(48, 8, value);
        }
    
        public char ProgramServiceB
        {
            get => ReadChar(56, 8);
            set => WriteChar(56, 8, value);
        }
    

    }
}