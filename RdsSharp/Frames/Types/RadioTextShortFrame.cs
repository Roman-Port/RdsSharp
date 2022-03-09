using System;

namespace RdsSharp.Frames.Types
{
    public class RadioTextShortFrame : RdsFrame
    {
        public RadioTextShortFrame(ulong raw) : base(raw) {}

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
    
        public char RadioText2A
        {
            get => ReadChar(48, 8);
            set => WriteChar(48, 8, value);
        }
    
        public char RadioText2B
        {
            get => ReadChar(56, 8);
            set => WriteChar(56, 8, value);
        }
    

    }
}