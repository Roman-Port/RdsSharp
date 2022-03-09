using System;
using System.Collections.Generic;
using System.Text;

namespace RdsSharp.Client
{
    public delegate void RdsAlternativeFrequencyCollection_UpdatedEventArgs(RdsAlternativeFrequencyCollection collection);

    public class RdsAlternativeFrequencyCollection
    {
        public RdsAlternativeFrequencyCollection()
        {
            Reset();
        }

        public int[] AlternateFrequencies => alternateFrequencies;
        public bool AfsReceived => success;

        public event RdsAlternativeFrequencyCollection_UpdatedEventArgs OnUpdated;

        /// <summary>
        /// If set, the system is waiting for the next "start of list" command to begin doing anything. Set to true upon reset or if there was an error.
        /// </summary>
        private bool reset;

        /// <summary>
        /// The number of frequencies in the list that are waiting.
        /// </summary>
        private int waiting;

        /// <summary>
        /// Set if the next frequency is set to be mediumwave.
        /// </summary>
        private bool isNextMw;

        /// <summary>
        /// Set to true when an AF collection is successfully fully retrieved.
        /// </summary>
        private bool success;

        /// <summary>
        /// Array of frequencies being read. Size is the original number of waiting items.
        /// </summary>
        private int[] readingFrequencies;

        /// <summary>
        /// Array of the last successfully received block of AFs
        /// </summary>
        private int[] alternateFrequencies;

        /// <summary>
        /// Resets the current state, clearing all current AFs
        /// </summary>
        public void Reset()
        {
            reset = true;
            success = false;
            waiting = 0;
            isNextMw = false;
            readingFrequencies = null;
            alternateFrequencies = new int[0];
        }

        /// <summary>
        /// Pushes a new command and processes it. There are two of these per RDS frame.
        /// </summary>
        /// <param name="command"></param>
        public void PushCommand(byte command)
        {
            //Handle
            if (command >= 224 && command <= 249)
            {
                //0-25 AFs follow. Subtract 224 to get value. Reset...
                reset = false;
                isNextMw = false;
                waiting = command - 224;

                //Create the reading frequencies array
                if (readingFrequencies == null || readingFrequencies.Length != waiting)
                    readingFrequencies = new int[waiting];
            }
            else if (!reset && command >= 1 && command < 205)
            {
                //Frequency code
                if (waiting > 0)
                {
                    //Convert command to a frequency
                    int freq;
                    if (isNextMw)
                        freq = 0; //MW not currently implemented
                    else
                        freq = 87500000 + (command * 100000);

                    //Reset flag
                    isNextMw = false;

                    //Write to our internal list
                    readingFrequencies[readingFrequencies.Length - waiting] = freq;
                    waiting--;
                } else
                {
                    //We are in an invalid state. We are not actively expecting more frequencies!
                    reset = true;
                }
            }
            else if (!reset && command == 250)
            {
                //A single LF/MF AF follows
                isNextMw = true;
            }

            //Check if we have successfully retrieved all of the AFs
            if (!reset && waiting == 0)
            {
                //Check if the list has changed
                if (!success || AreAfsUpdated())
                {
                    //Copy to the new AFs buffer
                    if (alternateFrequencies.Length != readingFrequencies.Length)
                        alternateFrequencies = new int[readingFrequencies.Length];
                    readingFrequencies.CopyTo(alternateFrequencies, 0);

                    //Set
                    success = true;

                    //Send event
                    OnUpdated?.Invoke(this);
                }

                //Enter reset state until next time
                reset = true;
            }
        }

        private bool AreAfsUpdated()
        {
            if (alternateFrequencies.Length != readingFrequencies.Length)
                return true;
            for (int i = 0; i < alternateFrequencies.Length; i++)
            {
                if (alternateFrequencies[i] != readingFrequencies[i])
                    return true;
            }
            return false;
        }
    }
}
