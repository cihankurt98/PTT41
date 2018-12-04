using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC_CommunicationApp
{
    class ADSConnection
    {
        public List<MQTTClient> MQTTBrokers { get => new List<MQTTClient>(MQTTBrokers); private set { } }
        public string NetId { get => string.Copy(NetId); private set { } }
        public string AdsPort { get => string.Copy(AdsPort); private set { } }

        ADSConnection(string netId, string adsPort)
        {
            if(string.IsNullOrEmpty(netId))
            {
                throw new ArgumentException("_netId == null or empty");
            }

            if(string.IsNullOrEmpty(adsPort))
            {
                throw new ArgumentException("_adsPort == null or empty");
            }

            NetId = netId;
            AdsPort = adsPort;
        }

        private MQTTClient FindBroker()
        {
            return null;
        }

        public bool PublishTo(MQTTClient broker)
        {
            return false;
        }

        public bool ReadNextMessageFrom(MQTTClient broker)
        {
            return false;
        }
    }
}
