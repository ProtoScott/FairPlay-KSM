using System;

namespace Protostream.FairPlay.Exceptions
{
    public sealed class FPInvalidContextException: FPException
    {
        public FPInvalidContextException(string context, string message, Exception ex = null) : base(context, message, ex) { }
    }
}
