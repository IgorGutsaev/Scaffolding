using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Storage.Abstractions
{
    public class File
    {
        public byte[] Data { get; private set; }

        public string UID { get; private set; }

        static public File Create(string uid, byte[] data)
        {
            if (string.IsNullOrWhiteSpace(uid))
                throw new ArgumentException("UID must be specified!");

            if (data == null || data.Length == 0)
                throw new ArgumentException("Empty content!");

            return new File { UID = uid.Trim(), Data = data };
        }
    }
}
