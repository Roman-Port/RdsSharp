using System;

namespace RdsSharp.Frames.Types
{
    public class ProgramItemNumberLabellingFrame : ProgramItemNumberFrame
    {
        public ProgramItemNumberLabellingFrame(ulong raw) : base(raw) {}

        public int Default
        {
            get => ReadInt(48, 1);
            set => WriteInt(48, 1, value);
        }
    
        public int RadioPagingCodes
        {
            get => ReadInt(27, 5);
            set => WriteInt(27, 5, value);
        }
    
        public bool LinkageActuator
        {
            get => ReadBool(32, 1);
            set => WriteBool(32, 1, value);
        }
    
        public int VariantCode
        {
            get => ReadInt(33, 3);
            set => WriteInt(33, 3, value);
        }
    
        public int SlowLabellingData
        {
            get => ReadInt(36, 12);
            set => WriteInt(36, 12, value);
        }
    

    }
}