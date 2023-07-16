using System;
using System.Net;

namespace WsaInstaller.Utils
{
    internal class WsaInfoLoader
    {
        private static readonly string infoUrl = Properties.Resources.wsaInfo;

        public static string GetInfo()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    return webClient.DownloadString(infoUrl);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
