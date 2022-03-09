using System;

namespace RdsSharp.Frames.Types
{
    public class RadioTextFrame : RdsFrame
    {
        public RadioTextFrame(ulong raw) : base(raw) {}

        public int TextSegment
        {
            get => ReadInt(28, 4);
            set => WriteInt(28, 4, value);
        }
    
        public bool TextAB
        {
            get => ReadBool(27, 1);
            set => WriteBool(27, 1, value);
        }
    
        public char RadioTextA
        {
            get => ReadChar(32, 8);
            set => WriteChar(32, 8, value);
        }
    
        public char RadioTextB
        {
            get => ReadChar(40, 8);
            set => WriteChar(40, 8, value);
        }
    
        public char RadioTextC
        {
            get => ReadChar(48, 8);
            set => WriteChar(48, 8, value);
        }
    
        public char RadioTextD
        {
            get => ReadChar(56, 8);
            set => WriteChar(56, 8, value);
        }
    

    }
}