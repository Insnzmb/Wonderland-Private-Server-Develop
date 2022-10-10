using RCLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wonderland_Private_Server.Tutorials
{
    public class TempDataBaseDll : RCLibrary.Core.DBConnectInfo
    {
        public IPAddress ServerIP => throw new NotImplementedException();

        public DataBaseTypes Server_Type => throw new NotImplementedException();

        string User { get; }

        string DBConnectInfo.User => throw new NotImplementedException();

        string Pass { get; }

        string DBConnectInfo.Pass => throw new NotImplementedException();

        string DataBase { get; }

        string DBConnectInfo.DataBase => throw new NotImplementedException();

        int Port { get; }
        /// <summary>
        /// IP Address of the Server
       int DBConnectInfo.Port => throw new NotImplementedException();

        public bool VerifyPassword(string check, string with, int useverify = 0)
        {
            throw new NotImplementedException();
        }
        /// </summary>
        //    System.Net.IPAddress ServerIP { get; }
        //    /// <summary>
        //    /// Type of Server we are connecting to
        //    /// </summary>
        //    RCLibrary.Core.DataBaseTypes Server_Type { get; }
        //    /// <summary>
        //    /// Handles Verification
        //    /// 
        //    /// supports mutliple types using the useverify to designate which one to use
        //    /// </summary>
        //    /// <returns>"true if strings match</returns>
        //    bool VerifyPassword(string check, string with, int useverify = 0)
        //    {
        //        //enter code to verify Passwords here
        //        return check == with;
        //    }
        //}
    }
}