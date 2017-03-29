using SmartCardReader.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardReader.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var usbDevices = UsbHelpers.GetConnectedUSBDevices();

            foreach (var usbDevice in usbDevices)
            {
                Console.WriteLine($"Device ID: {usbDevice.DeviceId}, PNP Device ID: {usbDevice.PnpDeviceId}, Description: {usbDevice.Description}");
            }

            Console.Read();
        }
    }
}
