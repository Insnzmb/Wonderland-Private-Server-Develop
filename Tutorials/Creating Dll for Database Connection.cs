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
    }
}