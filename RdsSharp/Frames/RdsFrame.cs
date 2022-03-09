using System;
using System.Collections.Generic;
using System.Text;

namespace RdsSharp.Frames
{
    public class RdsFrame
    {
        public RdsFrame(ulong payload)
        {
            this.payload = payload;
        }

        private ulong payload;

        public ulong Raw => payload;

        public ushort PiCode
        {
            get => (ushort)ReadInt(0, 16);
            set => WriteInt(0, 16, value);
        }

        public int GroupType
        {
            get => ReadInt(16, 5);
            set => WriteInt(16, 5, value);
        }

        public bool Tp
        {
            get => ReadBool(21, 1);
            set => WriteBool(21, 1, value);
        }

        public int Pty
        {
            get => ReadInt(22, 5);
            set => WriteInt(22, 5, value);
        }

        internal static int ReadInt(int bitOffset, int bitWidth, ulong payload)
        {
            return (int)((payload >> (64 - bitWidth - bitOffset)) & (((ulong)1 << bitWidth) - 1));
        }

        internal static void WriteInt(int bitOffset, int bitWidth, int value, ref ulong dst)
        {
            throw new NotImplementedException();
        }

        protected int ReadInt(int bitOffset, int bitWidth)
        {
            return ReadInt(bitOffset, bitWidth, payload);
        }

        protected void WriteInt(int bitOffset, int bitWidth, int value)
        {
            WriteInt(bitOffset, bitWidth, value, ref payload);
        }

        protected char ReadChar(int bitOffset, int bitWidth)
        {
            return (char)ReadInt(bitOffset, bitWidth);
        }

        protected void WriteChar(int bitOffset, int bitWidth, char value)
        {
            WriteInt(bitOffset, bitWidth, (int)value);
        }

        protected bool ReadBool(int bitOffset, int bitWidth)
        {
            return ReadInt(bitOffset, bitWidth) != 0;
        }

        protected void WriteBool(int bitOffset, int bitWidth, bool value)
        {
            WriteInt(bitOffset, bitWidth, value ? 1 : 0);
        }
    }
}
