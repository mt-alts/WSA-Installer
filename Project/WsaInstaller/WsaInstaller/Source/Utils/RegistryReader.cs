using Microsoft.Win32;

namespace WsaInstaller.Utils
{
    internal class RegistryReader
    {
        public static int GetX32DwordFromLocalMachine(string registryPath, string registryValue)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath);
            if (key != null)
            {
                int value = (int)key.GetValue(registryValue);
                return value;
            }
            return 0;
        }
    }
}
