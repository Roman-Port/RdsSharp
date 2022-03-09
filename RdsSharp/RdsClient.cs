using RdsSharp.Client;
using RdsSharp.Frames;
using RdsSharp.Frames.Types;
using System;

namespace RdsSharp
{
    public delegate void RdsClient_ValueChangedEventArgs<T>(RdsClient client, T value);
    public delegate void RdsClient_PsPartialUpdateEventArgs(RdsClient client, char[] ps, int updatedSegment);
    public delegate void RdsClient_PsCompleteUpdateEventArgs(RdsClient client, string ps);
    public delegate void RdsClient_AlternateFrequenciesUpdateEventArgs(RdsClient client, int[] alternateFrequencies);

    public class RdsClient
    {
        public RdsClient()
        {
            //Add events to update
            afCollection.OnUpdated += (RdsAlternativeFrequencyCollection collection) => OnAlternateFrequenciesUpdated?.Invoke(this, AlternateFrequencies);
        }

        private ushort? pi;
        private bool? trafficProgram;
        private int? pty;

        public event RdsClient_ValueChangedEventArgs<ushort> OnPiCodeChanged;
        public event RdsClient_ValueChangedEventArgs<bool> OnTrafficProgramChanged;
        public event RdsClient_ValueChangedEventArgs<int> OnPtyChanged;

        public void PushFrame(ulong frame)
        {
            PushFrame(RdsFrameFactory.DecodeFrame(frame));
        }

        public void PushFrame(RdsFrame frame)
        {
            //Set global items
            UpdateValue(ref pi, frame.PiCode, OnPiCodeChanged);
            UpdateValue(ref trafficProgram, frame.Tp, OnTrafficProgramChanged);
            UpdateValue(ref pty, frame.Pty, OnPtyChanged);

            //Handle specific features
            if (frame is BasicTuningFrame basicTuning)
                ProcessBasicTuning(basicTuning);
            if (frame is BasicTuningAfFrame af)
                ProcessAlternateFrequencies(af);
        }

        public void Reset()
        {
            //Clear all global items
            pi = null;
            trafficProgram = null;
            pty = null;
        }

        /* Basic Tuning */

        private bool? stereo;
        private bool? artificialHead;
        private bool? compressed;
        private bool? dynamicPty;
        private bool? trafficAnnouncement;
        private bool? isMusic;

        private char[] psBuffer = new char[8];
        private char[] psCompleteBuffer = new char[8];
        private int psSetRegions;

        public bool? Stereo => stereo;
        public bool? ArtificialHead => artificialHead;
        public bool? Compressed => compressed;
        public bool? DynamicPty => dynamicPty;
        public bool? TrafficAnnouncement => trafficAnnouncement;
        public bool? IsMusic => isMusic;
        public string PsComplete => new string(psCompleteBuffer);
        public char[] PsPartial => psBuffer;

        public event RdsClient_PsPartialUpdateEventArgs OnPsPartialUpdate;
        public event RdsClient_PsCompleteUpdateEventArgs OnPsCompleteUpdate;
        public event RdsClient_ValueChangedEventArgs<bool> OnFlagStereoChanged;
        public event RdsClient_ValueChangedEventArgs<bool> OnFlagArtificialHeadChanged;
        public event RdsClient_ValueChangedEventArgs<bool> OnFlagCompressedChanged;
        public event RdsClient_ValueChangedEventArgs<bool> OnFlagDynamicPtyChanged;
        public event RdsClient_ValueChangedEventArgs<bool> OnFlagTrafficAnnouncementChanged;
        public event RdsClient_ValueChangedEventArgs<bool> OnFlagIsMusicChanged;

        private void ProcessBasicTuning(BasicTuningFrame frame)
        {
            //Process the DI flags depending on the segment address
            switch (frame.SegmentAddress)
            {
                case 0: UpdateValue(ref dynamicPty, frame.Di, OnFlagDynamicPtyChanged); break;
                case 1: UpdateValue(ref compressed, frame.Di, OnFlagCompressedChanged); break;
                case 2: UpdateValue(ref artificialHead, frame.Di, OnFlagArtificialHeadChanged); break;
                case 3: UpdateValue(ref stereo, frame.Di, OnFlagStereoChanged); break;
            }

            //Process the two "static" flags that don't depend on the segment address
            UpdateValue(ref trafficAnnouncement, frame.Ta, OnFlagTrafficAnnouncementChanged);
            UpdateValue(ref isMusic, frame.Music, OnFlagIsMusicChanged);

            //Update the PS regions using the segment address
            psSetRegions |= 1 << frame.SegmentAddress;
            psBuffer[(frame.SegmentAddress * 2) + 0] = frame.ProgramServiceA;
            psBuffer[(frame.SegmentAddress * 2) + 1] = frame.ProgramServiceB;

            //Send event
            OnPsPartialUpdate?.Invoke(this, psBuffer, frame.SegmentAddress);

            //Check if we have a complete PS string
            if (psSetRegions == 15 && frame.SegmentAddress == 3)
            {
                //Check if anything has actually changed to avoid sending duplicate events
                bool changed = false;
                for (int i = 0; i < psBuffer.Length; i += 2)
                    changed = changed || psBuffer[i] != psCompleteBuffer[i];

                //Copy to complete buffer
                psBuffer.CopyTo(psCompleteBuffer, 0);

                //Reset set regions for next run
                psSetRegions = 0;

                //Send event if nessessary
                if (changed)
                    OnPsCompleteUpdate?.Invoke(this, new string(psCompleteBuffer));
            }
        }

        /* Alternate frequencies */

        private RdsAlternativeFrequencyCollection afCollection = new RdsAlternativeFrequencyCollection();

        public int[] AlternateFrequencies => afCollection.AlternateFrequencies;
        public bool AfsReceived => afCollection.AfsReceived;

        public event RdsClient_AlternateFrequenciesUpdateEventArgs OnAlternateFrequenciesUpdated;

        private void ProcessAlternateFrequencies(BasicTuningAfFrame frame)
        {
            //Push to collection for processing
            afCollection.PushCommand((byte)frame.AlternateFreqA);
            afCollection.PushCommand((byte)frame.AlternateFreqB);
        }

        /* UTIL */

        private void UpdateValue<T>(ref T? stored, T incoming, RdsClient_ValueChangedEventArgs<T> evt) where T : struct
        {
            if (!stored.HasValue || !stored.Value.Equals(incoming))
            {
                stored = incoming;
                evt?.Invoke(this, incoming);
            }
        }
    }
}
