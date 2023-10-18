using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigTiffany210
{
    public class ModemState
    {
        public String ICCID = "0000";
        public String IP = "10.10.10.10";
    }
    public struct MemeoryInformation
    {
        public UInt32 MainAppStartAddress;
        public UInt32 MainAppEndAddress;
        public UInt32 UpdateStorageStartAddress;
        public UInt32 UpdateStorageEndAddress;
    }

    public struct SimCardInformation
    {
        public string ICCID1;
        public string ICCID2;
    }

    public struct AuthInformation
    {
        public string Login;
        public string Password;
    }

    public struct NbfiServerInformation
    {
        public string Server;
        public UInt16 Port;
    }

    public class LteConfig
    {
        public enum AuthType
        {
            PAP = 0,
            CHAP = 1
        }
        public enum NetworkType
        {
            AUTO = 0,
            GSM = 1,
            LTE = 2
        }
        public enum SimCard
        {
            SIM1 = 0,
            SIM2 = 1
        }

        public enum NbfiInterface
        {
            LTE = 0,
            WA1470 = 1
        }

        SimCard Sim;
        AuthType SimAuth;
        NetworkType Network;

        public string APN = "";
        public string Login = "";
        public string Password = "";
        public string NbfiServer = "";
        public int NbfiPort = 16384;
        public int HeartBeat = 3;

        public String Serialize()
        {
            return "1;" + Sim + ";" + SimAuth + ";" + Network + ";"
                + APN + ";" + Login + ";" + Password + ";"
                + NbfiServer + ";" + NbfiPort + ";" + HeartBeat;
        }
    }
}
