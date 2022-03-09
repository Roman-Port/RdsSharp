using System;

namespace RdsSharp.Frames.Types
{
    public class OpenDataApplicationIdentificationFrame : RdsFrame
    {
        public OpenDataApplicationIdentificationFrame(ulong raw) : base(raw) {}

        public int ApplicationGroupType
        {
            get => ReadInt(27, 5);
            set => WriteInt(27, 5, value);
        }
    
        public int Message
        {
            get => ReadInt(32, 16);
            set => WriteInt(32, 16, value);
        }
    
        public int ApplicationIdentification
        {
            get => ReadInt(48, 16);
            set => WriteInt(48, 16, value);
        }
    

    }
}