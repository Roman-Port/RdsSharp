using System;
using RdsSharp.Frames.Types;

namespace RdsSharp.Frames
{
    public static class RdsFrameFactory
    {
        public static RdsFrame DecodeFrame(ulong frame)
        {
            switch (RdsFrame.ReadInt(16, 5, frame))
            {
                case 0b00001: return new BasicTuningFrame(frame);
                case 0b00000: return new BasicTuningAfFrame(frame);
                case 0b00100: return new RadioTextFrame(frame);
                case 0b00101: return new RadioTextShortFrame(frame);
                case 0b00011: return new ProgramItemNumberFrame(frame);
                case 0b00010: return new ProgramItemNumberLabellingFrame(frame);
                case 0b00110: return new OpenDataApplicationIdentificationFrame(frame);
                case 0b01000: return new ClockFrame(frame);
                case 0b10100: return new ProgramTypeNameFrame(frame);
                default: return new RdsFrame(frame);
            }
        }
    }
}