using System;

namespace Punku.Hash
{
    public abstract class Hash
    {
        protected byte[] hash;

        public override string ToString ()
        {
            return ByteArrayPrinter.ToHexString (hash);
        }
    }
}

