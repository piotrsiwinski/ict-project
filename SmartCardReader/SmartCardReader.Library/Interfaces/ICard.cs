using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardReader.Library.Interfaces
{
    public interface ICard
    {
        string[] ListReaders();
        void Connect(string Reader, SHARE ShareMode,
                     PROTOCOL PreferredProtocols);
        void Disconnect(DISCONNECT Disposition);
        APDUResponse Transmit(APDUCommand ApduCmd);
        void BeginTransaction();
        void EndTransaction(DISCONNECT Disposition);
    }
}
