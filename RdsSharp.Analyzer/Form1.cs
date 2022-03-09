using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RdsSharp.Frames;

namespace RdsSharp.Analyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RdsClient client = new RdsClient();
            client.OnPsCompleteUpdate += Client_OnPsCompleteUpdate;
            client.OnAlternateFrequenciesUpdated += Client_OnAlternateFrequenciesUpdated;
            using (FileStream fs = new FileStream("C:\\Users\\Roman\\Desktop\\rds_test_frames_alt.txt", FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    ulong raw = ulong.Parse(sr.ReadLine());
                    var frame = RdsFrameFactory.DecodeFrame(raw);
                    client.PushFrame(frame);
                    Console.WriteLine(frame.GroupType);
                }
            }
        }

        private void Client_OnAlternateFrequenciesUpdated(RdsClient client, int[] alternateFrequencies)
        {
            Console.WriteLine("AFS UPDATED");
        }

        private void Client_OnPsCompleteUpdate(RdsClient client, string ps)
        {
            Console.WriteLine(ps + " COMPLETE");
        }
    }
}
