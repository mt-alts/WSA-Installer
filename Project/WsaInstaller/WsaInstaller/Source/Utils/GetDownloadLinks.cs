using System;
using System.Net;
using System.Text.RegularExpressions;

namespace WsaInstaller.Utils
{
    internal class GetDownloadLinks
    {
        private static readonly string downLink = Properties.Resources.downloadLinks;

        public static string[] GetLinks()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    string info = webClient.DownloadString(downLink);

                    Regex regex = new Regex(@"\[(.*?)\]");
                    MatchCollection matches = regex.Matches(info);

                    string[] links = new string[matches.Count];

                    for (int i = 0; i < matches.Count; i++)
                    {
                        string link = matches[i].Groups[1].Value;
                        links[i] = link;
                    }

                    return links;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}