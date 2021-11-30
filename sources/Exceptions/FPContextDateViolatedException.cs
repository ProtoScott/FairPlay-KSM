using System;

namespace Protostream.FairPlay.Exceptions
{
    public sealed class FPContextDateViolatedException: FPException
    {
        public FPContextDateViolatedException(string context, string message, Exception ex = null) : base(context, message, ex) { }
    }
}
