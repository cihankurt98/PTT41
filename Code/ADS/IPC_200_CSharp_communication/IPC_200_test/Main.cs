using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TwinCAT.Ads;

namespace IPC_200_test
{
    public partial class Main : Form
    {
        TcAdsClient tcAds;
        bool test = false;
        public Main()
        {
            InitializeComponent();

            reading();
            //writing();
        }

        void connect()
        {
            tcAds = new TcAdsClient();

            tcAds.Connect("5.59.204.132.1.1", 851);
        }

        void disconnect()
        {
            tcAds.Dispose();
        }

        void reading()
        {
            connect();
            // creates a stream with a length of 4 byte 
            AdsStream ds = new AdsStream(4);
            BinaryReader br = new BinaryReader(ds);

            // reads a DINT from PLC
            tcAds.Read(0x4020, 0, ds);

            ds.Position = 0;
            label1.Text = br.ReadInt32().ToString();
            disconnect();
        }

        void writing()
        {
            connect();
            // creates a stream with a length of 4 byte
            AdsStream ds = new AdsStream(4);
            BinaryWriter bw = new BinaryWriter(ds);

            ds.Position = 0;

            int temp = 0;
            int.TryParse(textBox1.Text, out temp);
            bw.Write(temp);

            // writes a DINT to PLC
            tcAds.Write(0x4020, 0, ds);
            disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reading();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writing();
        }
    }
}
