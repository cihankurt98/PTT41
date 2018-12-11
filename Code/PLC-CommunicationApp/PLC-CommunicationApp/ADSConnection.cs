using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace PLC_CommunicationApp
{
    class ADSConnection
    {
        public List<MQTTClient> MQTTBrokers { get => new List<MQTTClient>(MQTTBrokers); private set { } }
        public string NetId { get => string.Copy(NetId); private set { } }
        public string AdsPort { get => string.Copy(AdsPort); private set { } }
        public TcAdsClient adsClient { get; private set; }

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

        ADSConnection(string netId, int adsPort)
        {
            adsClient = new TcAdsClient();
            adsClient.Connect(netId, adsPort);

            //ARRAYS
            for (int i = 0; i < 25; i++)
            {
                hPalletArray[i] = adsClient.CreateVariableHandle("MAIN.PalletArray[" + (i + 1) + "]");
                hDrinksArray[i] = adsClient.CreateVariableHandle("MAIN.DrinksArray[" + (i + 1) + "]");
            }
            //OTHER VARIABLES
            hFreeCola = adsClient.CreateVariableHandle("MAIN.FreeCola");
            hFreeFanta = adsClient.CreateVariableHandle("MAIN.FreeFanta");
            hNoBottle = adsClient.CreateVariableHandle("MAIN.NoBottle");
            hNoCover = adsClient.CreateVariableHandle("MAIN.NoCover");

            Reading();
        }

        public void Disconnect()
        {
            adsClient.Dispose();
        }

        public void Reading()
        {
            try
            {
                //ARRAYS
                for (int i = 0; i < 25; i++)
                {
                    if (PalletArray[i] != (int)adsClient.ReadAny(hPalletArray[i], typeof(int)))
                    {
                        //send message
                        PalletArray[i] = (int)adsClient.ReadAny(hPalletArray[i], typeof(int));
                    }
                    if (DrinksArray[i] != (int)adsClient.ReadAny(hDrinksArray[i], typeof(int)))
                    {
                        DrinksArray[i] = (int)adsClient.ReadAny(hDrinksArray[i], typeof(int));
                    }
                }

                //OTHER VARIABLES
                if (FreeFanta != (ints)adsClient.ReadAny(hFreeFanta, typeof(int)))
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
                throw new Exception(ex.Message);
                
            }
        }

        public void Writing()
        {
            try
            {
                //DE VARIABELEN DIE JE WILT SCHRIJVEN
                //adsClient.WriteAny(htest1, int.Parse(textBox1.Text));
                for (int i = 0; i < 25; i++)
                {
                    adsClient.WriteAny(hPalletArray[i], true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Reading();
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
