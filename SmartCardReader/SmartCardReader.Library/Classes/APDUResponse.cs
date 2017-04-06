using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardReader.Library.Classes
{
    class APDUResponse
    {
        //public APDUResponse(byte[] baData);
        public byte[] Data;
        public byte SW1;
        public byte SW2;
        public ushort Status;
        //public override string ToString();
    }
}
