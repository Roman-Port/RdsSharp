using System;

namespace RdsSharp.Frames.Types
{
    public class ProgramTypeNameFrame : RdsFrame
    {
        public ProgramTypeNameFrame(ulong raw) : base(raw) {}

        public bool AB
        {
            get => ReadBool(27, 1);
            set => WriteBool(27, 1, value);
        }
    
        public bool SegmentAddress
        {
            get => ReadBool(31, 1);
            set => WriteBool(31, 1, value);
        }
    
        public char PtynA
        {
            get => ReadChar(32, 8);
            set => WriteChar(32, 8, value);
        }
    
        public char PtynB
        {
            get => ReadChar(40, 8);
            set => WriteChar(40, 8, value);
        }
    
        public char PtynC
        {
            get => ReadChar(48, 8);
            set => WriteChar(48, 8, value);
        }
    
        public char PtynD
        {
            get => ReadChar(56, 8);
            set => WriteChar(56, 8, value);
        }
    

    }
}