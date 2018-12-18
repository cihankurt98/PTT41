using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Diagnostics;

namespace PLC_CommunicationApp
{
    class MQTTClient
    {
        public int ID { get; private set; }
        public readonly byte QOS;

        private MqttClient client;
        private bool ackPub;
        private RollingBuffer buffer;
        private ADSConnection adsCon;


        public MQTTClient(string IP, int bufferLength, byte QOS, int ID, ADSConnection ads)
        {
            if(bufferLength < 1)
            {
                throw new ArgumentOutOfRangeException("bufferLength");
            }

            if( QOS < 0 || QOS > 2)
            {
                throw new ArgumentOutOfRangeException("QOS");
            }

            if(ads == null)
            {
                throw new ArgumentNullException("ads");
            }

            buffer = new RollingBuffer(bufferLength);
            this.QOS = QOS;
            this.ID = ID;

            ackPub = true;
            client = new MqttClient(IP);

            adsCon = ads;
        }

        public void Connect(string username, string password)
        {
            if(String.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("username");
            }

            if(string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("password");
            }

            client.Connect(Guid.NewGuid().ToString(), username, password);

        }

        public void Publish(string topic, string message)
        {
            if(String.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentNullException("topic");
            }

            if(string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("message");
            }
            
            ushort msgId = client.Publish(topic,                                    // topic
                                          Encoding.UTF8.GetBytes(message),          // message body
                                          QOS,                                      // QoS level
                                          false);                                   // retained

            if (ackPub)
            {
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
                ackPub = false;
            }
        }

        public void Subscribe(string topic)
        {
            if(String.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentNullException("topic");
            }

            ushort msgId = client.Subscribe(new string[] { topic }, 
                                            new byte[]   { QOS   } );
        }

        void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Debug.WriteLine("Subscribed for id = " + e.MessageId);
        }

        public void Unsubscribe(string topic)
        {
            if(String.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentNullException("topic");
            }

            client.Unsubscribe(new string[] { topic });
        }

        /// <summary>
        /// Event which triggers if the MQTT listener receives a new publish from the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            String recvMessage = "Received = " + Encoding.UTF8.GetString(e.Message) + " on topic " + e.Topic;
            Debug.WriteLine(recvMessage);

            buffer.Write( Encoding.UTF8.GetString(e.Message) );

            recvMessage = String.Empty;

        }

        /// <summary>
        /// Reads the oldest data added to the messagebuffer. Increments if the write function overwrites the oldest data.
        /// </summary>
        /// <returns>the oldest data received from the MQTT server</returns>
        public string Read()
        {
            return buffer.Read();
        }
    }
}
