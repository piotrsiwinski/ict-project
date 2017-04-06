using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardReader.Library.Classes
{
    public class APDUCommand
    {
        public APDUCommand(byte bCla, byte bIns, byte bP1, byte bP2, byte[] baData, byte bLe)
        {

        }
        /*public void Update(APDUParam apduParam)
        {

        }*/
        //public override string ToString();
        public byte Class;
        public byte Ins;
        public byte P1;
        public byte P2;
        public byte[] Data;
        public byte Le;
    }
}
