using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkRedirect.Interface {
    public interface IKVDB {
        void Put(string K, string V);
        void Put(byte[] K, byte[] V);
        string Get(string K);
        byte[] Get(byte[] K);
        void Remove(string K);
        void Remove(byte[] K);
    }
}
