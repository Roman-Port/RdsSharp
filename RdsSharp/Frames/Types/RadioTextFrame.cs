using System;

namespace RdsSharp.Frames.Types
{
    public class RadioTextFrame : RadioTextShortFrame
    {
        public RadioTextFrame(ulong raw) : base(raw) {}

        public char RadioText1A
        {
            get => ReadChar(32, 8);
            set => WriteChar(32, 8, value);
        }
    
        public char RadioText1B
        {
            get => ReadChar(40, 8);
            set => WriteChar(40, 8, value);
        }
    

    }
}