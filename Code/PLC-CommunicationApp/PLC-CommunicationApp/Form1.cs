using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;


namespace PLC_CommunicationApp
{
    public partial class Form1 : Form
    {
        MQTTClient client;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(BrokerIpTB.Text))
            {
                MessageBox.Show("Please enter a valid IP.");
                return;
            }

            client = new MQTTClient(BrokerIpTB.Text, 10, 2);
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(UsernameTB.Text))
            {
                MessageBox.Show("Please enter a valid username.");
                return;
            }

            if (String.IsNullOrWhiteSpace(PasswordTB.Text))
            {
                MessageBox.Show("Please enter a valid password.");
                return;
            }

            if (client == null)
            {
                MessageBox.Show("Initialize the client object first.");
                return;
            }

            client.Connect(UsernameTB.Text, PasswordTB.Text);

        }

        private void PublishBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TopicTB.Text))
            {
                MessageBox.Show("Please enter a valid topic.");
                return;
            }

            if (String.IsNullOrWhiteSpace(PubMsgTB.Text))
            {
                MessageBox.Show("Please enter a valid password.");
                return;
            }

            if (client == null)
            {
                MessageBox.Show("Initialize the client object first.");
                return;
            }

            client.Publish(TopicTB.Text, PubMsgTB.Text);

        }

        private void SubscribeBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TopicTB.Text))
            {
                MessageBox.Show("Please enter a valid topic.");
                return;
            }

            if (client == null)
            {
                MessageBox.Show("Initialize the client object first.");
                return;
            }

            client.Subscribe(TopicTB.Text);

        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            if(client == null)
            { MessageBox.Show("Initialize and connect a client first."); return; }

            if (client.Read() != String.Empty)
            { subscribeLB.Items.Add(client.Read()); }

        }
    }
}
