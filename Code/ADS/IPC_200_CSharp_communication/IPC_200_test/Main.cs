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
        string PLCID = "145.93.160.174.1.1";
        int PLCPort = 851;

        TcAdsClient adsClient;
        int htest1;

        public Main()
        {
            InitializeComponent();

            connect();

            reading();
        }

        void connect()
        {
            adsClient = new TcAdsClient();
            adsClient.Connect(PLCID, PLCPort);
            htest1 = adsClient.CreateVariableHandle("MAIN.test");
        }

        void disconnect()
        {
            adsClient.Dispose();
        }

        void reading()
        {
           // connect();
            try
            {
                //ALLE VARIABELEN DIE JE WILT LEZEN
                label1.Text = adsClient.ReadAny(htest1, typeof(int)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //disconnect();
        }

        void writing()
        {
            //connect();
            try
            {
                //DE VARIABELEN DIE JE WILT SCHRIJVEN
                adsClient.WriteAny(htest1, int.Parse(textBox1.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            reading();

            //disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reading();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writing();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnect();
        }
    }
}
