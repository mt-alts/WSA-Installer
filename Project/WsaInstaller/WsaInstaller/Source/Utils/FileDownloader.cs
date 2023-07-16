using System;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace WsaInstaller.Utils
{
    internal class FileDownloader
    {
        public event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;
        public event EventHandler<AsyncCompletedEventArgs> DownloadCompleted;
        private int count = 0;
        private WebClient webClient = new WebClient();

        public void DownloadFile(string url, string saveDirectory)
        {
            using (WebClient wc = webClient)
            {
                wc.DownloadProgressChanged += (sender, e) => OnDownloadProgressChanged(e);
                wc.DownloadFileCompleted += (sender, e) => OnDownloadCompleted(e);
                wc.DownloadFileAsync(new Uri(url), saveDirectory + "\\" + SaveFileName(url));
            }
        }

        public void Cancel()
        {
            webClient.CancelAsync();
        }

        private string SaveFileName(string url)
        {
            string fileNameFromServer = GetFileName(url);
            if (fileNameFromServer != null && fileNameFromServer.Length > 0)
                return fileNameFromServer;
            fileNameFromServer = "wsa_pack_" + count;
            count++;
            return fileNameFromServer;
        }

        public string GetFileName(string url)
        {
            Uri uri = new Uri(url);
            string fileName = Path.GetFileName(uri.LocalPath);
            return fileName;
        }

        public long GetFileSize(string url)
        {
            long result = -1;
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.Method = "HEAD";
            using (System.Net.WebResponse resp = req.GetResponse())
            {
                if (long.TryParse(resp.Headers.Get("Content-Length"), out long ContentLength))
                {
                    result = ContentLength;
                }
            }
            return result;
        }

        protected virtual void OnDownloadProgressChanged(DownloadProgressChangedEventArgs e)
        {
            DownloadProgressChanged?.Invoke(this, e);
        }

        protected virtual void OnDownloadCompleted(AsyncCompletedEventArgs e)
        {
            DownloadCompleted?.Invoke(this, e);
        }
    }
}
