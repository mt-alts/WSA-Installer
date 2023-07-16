namespace WsaInstaller.Utils
{
    internal class MemoryConverter
    {
        public static string ConvertToMemorySize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int sizeIndex = 0;
            double size = bytes;

            while (size >= 1024 && sizeIndex < sizes.Length - 1)
            {
                size /= 1024;
                sizeIndex++;
            }

            return $"{size:0.##} {sizes[sizeIndex]}";
        }
    }
}
