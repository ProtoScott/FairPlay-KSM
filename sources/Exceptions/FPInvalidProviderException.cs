using System;

namespace Protostream.FairPlay.Exceptions
{
    public sealed class FPInvalidProviderException: FPException
    {
        public FPInvalidProviderException(string context, string message, Exception ex = null) : base(context, message, ex) { }
    }
}
