using SmartCardReader.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardReader.Library.Helpers
{
    public static class UsbHelpers
    {
        public static List<USBDeviceInfo> GetConnectedUSBDevices()
        {
            string query = @"Select * From Win32_USBHub";
            var devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(query))
            {
                collection = searcher.Get();
            }

            foreach(var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                    (string)device.GetPropertyValue("DeviceID"),
                    (string)device.GetPropertyValue("PNPDeviceID"),
                    (string)device.GetPropertyValue("Description")
                ));
            }

            collection.Dispose();
            return devices;

        }
    }
}
