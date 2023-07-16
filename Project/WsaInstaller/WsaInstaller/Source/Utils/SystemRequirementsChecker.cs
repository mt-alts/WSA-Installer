using System;
using System.IO;
using System.Management;

namespace WsaInstaller.Utils
{
    internal class SystemRequirementsChecker
    {
        public static bool IsSpaceAvaliable(long size)
        {
            string cDrivePath = "C:\\";
            DriveInfo driveInfo = new DriveInfo(cDrivePath);
            long availableSpace = driveInfo.AvailableFreeSpace;

            if (availableSpace >= size)
            {
                return true;
            }
            return false;
        }

        public static bool IsRamEnough(int ramSize)
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
                ulong totalSizeBytes = 0;

                foreach (ManagementObject obj in searcher.Get())
                {
                    ulong sizeBytes = Convert.ToUInt64(obj["Capacity"]);
                    totalSizeBytes += sizeBytes;
                }

                int totalSizeGB = (int)(totalSizeBytes / (1024 * 1024 * 1024));

                if (totalSizeGB <= ramSize)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }
    }
}
