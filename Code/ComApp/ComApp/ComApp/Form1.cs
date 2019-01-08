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
            txtBoxADSIP.Text = "5.17.58.102.1.1";
            lblADSPort.Text = "ADS Port:";
            txtBoxADSPort.Text = "851";
            btnCorDADS.Text = "Connect To ADS";

            lblMQTTIP.Text = "MQTT IP:";
            txtBoxMQTTIP.Text = "192.168.202.44";
            btnCorDMQTT.Text = "Connect To MQTT";

            this.FormClosed += Form_Closed;
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            ADS.Disconnect();
        }

        private void btnCorDADS_Click(object sender, EventArgs e)
        {
            if(ADSConnected)
            {
                btnCorDADS.Text = "Connect To ADS";
                btnCorDMQTT.Text = "Connect To MQTT";
                ADSConnected = false;
                MQTTConnected = false;
                ADS.Disconnect();
                ADS = null;
            }
            else
            {
                try
                {
                    //MessageBox.Show("Given ADS IP: " + txtBoxADSIP.Text);
                    //MessageBox.Show("Given ADS Port: " + txtBoxADSPort.Text);
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
                    //MessageBox.Show("Given MQTT IP: " + txtBoxMQTTIP.Text);

                    if (!ADS.AddBroker(txtBoxMQTTIP.Text, qos, MQTTHandle))
                    {
                        MessageBox.Show("Broker connection could not be created.");
                        return;
                    }
                    string topic = "/test/topic";

                    ADS.MQTTBrokers[0].Connect("username", "password");
                    ADS.MQTTBrokers[0].Subscribe(topic);
                    ADS.Reading(topic);
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
