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
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Diagnostics;


namespace PLC_CommunicationApp
{
    public partial class Form1 : Form
    {
        MqttClient client;

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

            client = new MqttClient(BrokerIpTB.Text);
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

            client.Connect(Guid.NewGuid().ToString(), UsernameTB.Text, PasswordTB.Text);

        }

        bool test = true;
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

            ushort msgId = client.Publish(TopicTB.Text,                 // topic
                              Encoding.UTF8.GetBytes(PubMsgTB.Text),    // message body
                              MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,       // QoS level
                              false);                                   // retained

            if (test)
            {
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
                test = false;
            }
   
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string recvMessage = "Received = " + Encoding.UTF8.GetString(e.Message) + " on topic " + e.Topic;
            Debug.WriteLine(recvMessage);
      
            //subscribeLB.Items.Add(recvMessage);
            //this.Invoke((MethodInvoker)(() => subscribeLB.Items.Clear())); //Form items aren't thread safe! An invoker is required to make cross thread method calls.
            this.Invoke((MethodInvoker)(() => subscribeLB.Items.Add(recvMessage))); //Form items aren't thread safe! An invoker is required to make cross thread method calls.
            recvMessage = "";
            MessageBox.Show("Test");

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

            ushort msgId = client.Subscribe(new string[] { TopicTB.Text },
                 new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });


        }

        void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Debug.WriteLine("Subscribed for id = " + e.MessageId);
        }

    }
}
