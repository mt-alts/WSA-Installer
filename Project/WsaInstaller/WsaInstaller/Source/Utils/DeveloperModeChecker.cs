using System;
using System.Diagnostics;

namespace WsaInstaller.Utils
{
    internal class DeveloperModeChecker
    {
        private static readonly string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\AppModelUnlock";
        private static readonly string registryValue = "AllowDevelopmentWithoutDevLicense";

        public static bool IsDeveloperModeEnbled()
        {
            if (RegistryReader.GetX32DwordFromLocalMachine(registryPath, registryValue) == 1)
            {
                return true;
            }
            return false;
        }

        internal static void OpenDeveloperSettings()
        {
            try
            {
                Process.Start("ms-settings:developers");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
