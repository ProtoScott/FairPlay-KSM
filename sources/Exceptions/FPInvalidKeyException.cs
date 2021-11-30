using System;

namespace Protostream.FairPlay.Exceptions
{
    public sealed class FPInvalidKeyException: FPException
    {
        public FPInvalidKeyException(string context, string message, Exception ex = null) : base(context, message, ex) { }
    }
}
