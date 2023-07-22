using System;
using System.IO;

namespace WsaInstaller.Utils
{
    internal class TempFolder
    {
        private string path;

        public void CreateRandom()
        {
            string tempDir = GetTempDirectory();
            path = GenerateUniqueFolderName(tempDir);

            while (Directory.Exists(path))
            {
                path = GenerateUniqueFolderName(tempDir);
            }

            Directory.CreateDirectory(path);
        }

        public void Delete()
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            
        }

        static string GenerateUniqueFolderName(string path)
        {
            string folderName = Path.Combine(path, GenerateRandomFileName(6));
            return folderName;
        }

        private static string GetTempDirectory()
        {
            string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string tempDirectory = System.IO.Path.Combine(tempPath, "Temp");
            return tempDirectory;
        }

        private static string GenerateRandomFileName(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";
            Random random = new Random();
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(0, chars.Length)];
            }

            string dirName = new string(stringChars);
            return dirName;
        }

        public string GetPath()
        {
            return path;
        }
    }
}
