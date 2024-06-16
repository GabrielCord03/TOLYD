using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace TOLYD.Data
{
    public class TesteConexao
    {   
        public static bool IsConnected()
        {
            return Connectivity.NetworkAccess == NetworkAccess.Internet;
        }
    }
}
