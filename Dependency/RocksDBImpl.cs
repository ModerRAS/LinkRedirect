using LinkRedirect.Interface;
using RocksDbSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkRedirect.Dependency {
    public class RocksDBImpl : IKVDB {
        private DbOptions options;
        private string DBPath;
        private RocksDb db;
        public RocksDBImpl(string DBPath) {
            options = new DbOptions().SetCreateIfMissing(true);
            this.DBPath = DBPath;
            db = RocksDb.Open(options, DBPath);
        }
        public string Get(string K) {
            return db.Get(K);
        }

        public byte[] Get(byte[] K) {
            return db.Get(K);
        }

        public void Put(string K, string V) {
            db.Put(K, V);
        }

        public void Put(byte[] K, byte[] V) {
            db.Put(K, V);
        }

        public void Remove(string K) {
            db.Remove(K);
        }

        public void Remove(byte[] K) {
            db.Remove(K);
        }
    }
}
