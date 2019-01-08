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
        string PLCID = "5.17.58.102.1.1";
        int PLCPort = 851;

        TcAdsClient adsClient;

        //VARIABLES
        int[] PalletArray = new int[25];
        int[] DrinksArray = new int[25];
        int FreeCola;
        int FreeFanta;
        bool NoBottle;
        bool NoCover;

        //HANDLE VARIABLES
        int[] hPalletArray = new int[25];
        int[] hDrinksArray = new int[25];
        int hFreeCola;
        int hFreeFanta;
        int hNoBottle;
        int hNoCover;

        public Main()
        {
            InitializeComponent();

            connect();

            timer1.Start();
        }

        void connect()
        {
            adsClient = new TcAdsClient();
            adsClient.Connect(PLCID, PLCPort);

            //ARRAYS
            for (int i = 0; i < 25; i++)
            {
                hPalletArray[i] = adsClient.CreateVariableHandle("MAIN.PalletArray[" + (i + 1) + "]");
                hDrinksArray[i] = adsClient.CreateVariableHandle("MAIN.DrinkArray[" + (i + 1) + "]");
            }
            //OTHER VARIABLES
            hFreeCola = adsClient.CreateVariableHandle("MAIN.FreeCola");
            hFreeFanta = adsClient.CreateVariableHandle("MAIN.FreeFanta");
            hNoBottle = adsClient.CreateVariableHandle("MAIN.NoBottle");
            hNoCover = adsClient.CreateVariableHandle("MAIN.NoCover");

            reading();
        }

        void disconnect()
        {
            adsClient.Dispose();
        }

        void reading()
        {
            try
            {
                //ARRAYS
                for (int i = 0; i < 25; i++)
                {               
                    if (PalletArray[i] != (int)adsClient.ReadAny(hPalletArray[i], typeof(int)))
                    {
                        PalletArray[i] = (int)adsClient.ReadAny(hPalletArray[i], typeof(int));
                    }
                    if (DrinksArray[i] != (int)adsClient.ReadAny(hDrinksArray[i], typeof(int)))
                    {
                        DrinksArray[i] = (int)adsClient.ReadAny(hDrinksArray[i], typeof(int));
                    }
                }

                //OTHER VARIABLES
                if (FreeFanta != (int)adsClient.ReadAny(hFreeFanta, typeof(int)))
                {
                    FreeFanta = (int)adsClient.ReadAny(hFreeFanta, typeof(int));
                }
                if (FreeCola != (int)adsClient.ReadAny(hFreeCola, typeof(int)))
                {
                    FreeCola = (int)adsClient.ReadAny(hFreeCola, typeof(int));
                }
                if (NoCover != (bool)adsClient.ReadAny(hNoCover, typeof(bool)))
                {
                    NoCover = (bool)adsClient.ReadAny(hNoCover, typeof(bool));
                }
                if (NoBottle != (bool)adsClient.ReadAny(hNoBottle, typeof(bool)))
                {
                    NoBottle = (bool)adsClient.ReadAny(hNoBottle, typeof(bool));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void writing()
        {
            try
            {
                //DE VARIABELEN DIE JE WILT SCHRIJVEN
                //adsClient.WriteAny(htest1, int.Parse(textBox1.Text));
                //for (int i = 0; i < 25; i++)
                //{
                //    adsClient.WriteAny(hPalletArray[i], true);
                //}

                adsClient.WriteAny(hFreeCola, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            reading();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            reading();
        }
    }
}
