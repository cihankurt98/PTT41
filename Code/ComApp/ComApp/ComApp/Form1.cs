using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComApp
{
    public partial class Form1 : Form
    {
        private const int MQTTHandle = 1;
        private const int qos = 2;
        private bool ADSConnected;
        private bool MQTTConnected;
        private ADSConnection ADS;

        public Form1()
        {
            InitializeComponent();

            ADSConnected = false;
            MQTTConnected = false;
            ADS = null;

            lblADSIP.Text = "ADS IP:";
            txtBoxADSIP.Text = "";
            lblADSPort.Text = "ADS Port:";
            txtBoxADSPort.Text = "";
            btnCorDADS.Text = "Connect To ADS";

            lblADSIP.Text = "MQTT IP:";
            txtBoxMQTTIP.Text = "";
            btnCorDMQTT.Text = "Connect To MQTT";
        }

        private void btnCorDADS_Click(object sender, EventArgs e)
        {
            if(ADSConnected)
            {
                btnCorDADS.Text = "Connect To ADS";
                btnCorDMQTT.Text = "Connect To MQTT";
                ADSConnected = false;
                MQTTConnected = false;
                ADS = null;
            }
            else
            {
                try
                {
                    ADS = new ADSConnection(txtBoxADSIP.Text, Convert.ToInt32(txtBoxADSPort.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please add valid variables to ADS IP and ADS Port.\nError Message: " + ex.Message);
                    ADS = null;
                    return;
                }

                btnCorDADS.Text = "Disconnect From ADS";
                ADSConnected = true;
            }
        }

        private void btnCorDMQTT_Click(object sender, EventArgs e)
        {
            if(!ADSConnected)
            {
                MessageBox.Show("Please connect to ads before connecting to a mqtt broker.");
                return;
            }

            if(MQTTConnected)
            {
                ADS.RemoveBroker(MQTTHandle);
                btnCorDMQTT.Text = "Connect To MQTT";
                MQTTConnected = false;
            }
            else
            {
                try
                {
                    if (!ADS.AddBroker(txtBoxMQTTIP.Text, qos, MQTTHandle))
                    {
                        MessageBox.Show("Broker connection could not be created.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please add a valid ip to MQTT IP.\nError Message: " + ex.Message);
                    ADS.RemoveBroker(MQTTHandle);
                    return;
                }

                btnCorDMQTT.Text = "Disconnect From MQTT";
                MQTTConnected = true;
            }
        }
    }
}
