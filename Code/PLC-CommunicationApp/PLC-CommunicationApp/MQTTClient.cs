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
        public MqttClient Client { get; private set; }
        public Array[string] MessageBuffer
        {
            get
            {
                return new List<string>(MessageBuffer);
            }
            private set
            {

            }
        }




    }
}
