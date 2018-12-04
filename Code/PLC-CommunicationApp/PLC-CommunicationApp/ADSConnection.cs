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
            if (string.IsNullOrEmpty(netId))
            {
                throw new ArgumentException("_netId == null or empty");
            }

            if (string.IsNullOrEmpty(adsPort))
            {
                throw new ArgumentException("_adsPort == null or empty");
            }

            NetId = netId;
            AdsPort = adsPort;
        }

        public bool AddBroker(string IP, int bufferLength, byte QOS, int ID)
        {
            if(FindBroker(ID) != null)
            {
                return false;
            }

            try
            {
                MQTTBrokers.Add(new MQTTClient(IP, bufferLength, QOS, ID));
            }
            catch (ArgumentNullException e)
            {
                System.Diagnostics.Debug.Print(e.Message);
                return false;
            }
            catch (ArgumentOutOfRangeException e)
            {
                System.Diagnostics.Debug.Print(e.Message);
                return false;
            }

            return true;
        }

        private MQTTClient FindBroker(int id)
        {
            foreach (MQTTClient broker in MQTTBrokers)
            {
                if (id == broker.ID)
                {
                    return broker;
                }
            }

            return null;
        }

        public bool PublishTo(int brokerID, string topic, string message)
        {
            if(string.IsNullOrEmpty(topic))
            {
                throw new ArgumentException("topic == null or empty");
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("message == null or empty");
            }

            MQTTClient foundBroker = FindBroker(brokerID);
            if (foundBroker != null)
            {
                // publish to found connection
                foundBroker.Publish(topic, message);

                return true;
            }

            return false;
        }

        public string ReadNextMessageFrom(int brokerID)
        {
            MQTTClient foundBroker = FindBroker(brokerID);
            if(foundBroker != null)
            {
                return foundBroker.Read();
            }

            return null;
        }
    }
}
