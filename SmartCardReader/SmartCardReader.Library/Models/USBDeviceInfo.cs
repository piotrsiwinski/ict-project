using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardReader.Library.Models
{
    public class USBDeviceInfo
    {
        public string DeviceId{ get; private set; }
        public string PnpDeviceId { get; private set; }
        public string Description { get; private set; }

        public USBDeviceInfo(string deviceId, string pnpDeviceId, string description)
        {
            this.DeviceId = deviceId;
            this.PnpDeviceId = pnpDeviceId;
            this.Description = description;
        }
    }
}
