using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace PLC_CommunicationApp
{
    class ADSClient
    {
        TcAdsClient tcAds;

        private void Connect(string netID, int port)
        {
            if(String.IsNullOrEmpty(netID))
            { throw new ArgumentNullException(netID); }

            if(port < 0 || port > 99999)
            { throw new ArgumentOutOfRangeException("port"); }

            tcAds = new TcAdsClient();
            tcAds.Connect("5.17.58.102.1.1", 851); //needs netID
        }

        private void Disconnect()
        {
            tcAds.Dispose();
        }

        private void Send(int message)
        {
            // creates a stream with a length of 4 byte
            AdsStream ds = new AdsStream(4);
            BinaryWriter bw = new BinaryWriter(ds);

            ds.Position = 0;
            bw.Write(100);

            // writes a DINT to PLC
            tcAds.Write(0x4020, 0, ds);
        }

        private string Recv()
        {
            // creates a stream with a length of 4 byte 
            AdsStream ds = new AdsStream(4);
            BinaryReader br = new BinaryReader(ds);

            // reads a DINT from PLC
            tcAds.Read(0x4020, 0, ds);

            ds.Position = 0;
            return br.ReadInt32().ToString();
        }
    }
}
