using System;
using System.Net.NetworkInformation;

namespace WsaInstaller.Utils
{
    internal class InternetConnectionChecker
    {
        private static readonly string host = "github.com";

        public static bool CheckInternetConnection()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = ping.Send(host);
                    return (reply.Status == IPStatus.Success);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
