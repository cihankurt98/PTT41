using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace ComApp
{
    class ADSConnection
    {
        public List<MQTTClient> MQTTBrokers { get; private set; }
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
        bool CorrectBottle;

        //HANDLE VARIABLES
        int[] hPalletArray = new int[25];
        int[] hDrinksArray = new int[25];
        int hFreeCola;
        int hFreeFanta;
        int hNoBottle;
        int hNoCover;
        int hCorrectBottle;
        int hBottleAvailable;
        int hColaFanta;

        public ADSConnection(string netId, int adsPort)
        {
            adsClient = new TcAdsClient();
            adsClient.Connect(netId, adsPort);
            MQTTBrokers = new List<MQTTClient>();

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
            hCorrectBottle = adsClient.CreateVariableHandle("MAIN.CorrectBottle");
            hBottleAvailable = adsClient.CreateVariableHandle("MAIN.BottleAvailable");
            hColaFanta = adsClient.CreateVariableHandle("MAIN.ColaFanta");

           
        }

        public void Disconnect()
        {
            adsClient.Dispose();
        }

        public void Reading(string topic)
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
                    FindBroker(1).Publish(topic, "%FreeFanta," + (int)adsClient.ReadAny(hFreeFanta, typeof(int)) + "#");
                    FreeFanta = (int)adsClient.ReadAny(hFreeFanta, typeof(int));
                }
                if (FreeCola != (int)adsClient.ReadAny(hFreeCola, typeof(int)))
                {
                    FindBroker(1).Publish(topic, "%FreeCola," + (int)adsClient.ReadAny(hFreeCola, typeof(int)) + "#");
                    FreeCola = (int)adsClient.ReadAny(hFreeCola, typeof(int));
                }
                if (NoCover != (bool)adsClient.ReadAny(hNoCover, typeof(bool)) && (bool)adsClient.ReadAny(hNoCover, typeof(bool)) == true)
                {
                    FindBroker(1).Publish(topic, "%NoCover#");
                    NoCover = (bool)adsClient.ReadAny(hNoCover, typeof(bool));
                }
                if (NoCover != (bool)adsClient.ReadAny(hNoCover, typeof(bool)) && (bool)adsClient.ReadAny(hNoCover, typeof(bool)) == false)
                {
                    NoCover = (bool)adsClient.ReadAny(hNoCover, typeof(bool));
                }
                if (NoBottle != (bool)adsClient.ReadAny(hNoBottle, typeof(bool)) && (bool)adsClient.ReadAny(hNoBottle, typeof(bool)) == true)
                {
                    FindBroker(1).Publish(topic, "%NoBottle#");
                    NoBottle = (bool)adsClient.ReadAny(hNoBottle, typeof(bool));
                }
                if (NoBottle != (bool)adsClient.ReadAny(hNoBottle, typeof(bool)) && (bool)adsClient.ReadAny(hNoBottle, typeof(bool)) == false)
                {
                    NoBottle = (bool)adsClient.ReadAny(hNoBottle, typeof(bool));
                }
                if (CorrectBottle != (bool)adsClient.ReadAny(hCorrectBottle, typeof(bool)) && (bool)adsClient.ReadAny(hCorrectBottle, typeof(bool)) == true)
                {
                    FindBroker(1).Publish(topic, "%CorrectBottle#");
                    CorrectBottle = (bool)adsClient.ReadAny(hCorrectBottle, typeof(bool));
                }
                if (CorrectBottle != (bool)adsClient.ReadAny(hCorrectBottle, typeof(bool)) && (bool)adsClient.ReadAny(hCorrectBottle, typeof(bool)) == false)
                {
                    FindBroker(1).Publish(topic, "%Free#");
                    CorrectBottle = (bool)adsClient.ReadAny(hCorrectBottle, typeof(bool));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Writing(string msg)
        {
            try
            {
                switch (msg)
                {
                    case "%Cola#":
                        adsClient.WriteAny(hColaFanta, false);
                        adsClient.WriteAny(hBottleAvailable, true);
                        break;
                    case "%Fanta#":
                        adsClient.WriteAny(hColaFanta, true);
                        adsClient.WriteAny(hBottleAvailable, true);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Reading("/test/topic");
        }

        public bool AddBroker(string IP, byte QOS, int ID)
        {
            if (FindBroker(ID) != null)
            {
                return false;
            }

            try
            {
                MQTTBrokers.Add(new MQTTClient(IP, QOS, ID, this));
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

        public bool RemoveBroker(int ID)
        {
            MQTTClient foundBroker = FindBroker(ID);
            if (foundBroker == null)
            {
                return false;
            }

            MQTTBrokers.Remove(foundBroker);

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
    }
}
