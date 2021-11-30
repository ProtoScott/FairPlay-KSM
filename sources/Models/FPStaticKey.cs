using Protostream.FairPlay.Interfaces;
using Protostream.sources.Extensions;

namespace Protostream.FairPlay.Models
{
    public class FPStaticKey: IContentKey
    {
        public byte[] Key { get; private set; }
    
        public byte[] IV { get; private set; }

        public FPStaticKey(string keyHex, string ivHex) {
            this.Key = keyHex.HexToByteArray();
            this.IV = ivHex.HexToByteArray();
        }

        public FPStaticKey(byte[] key, byte[] iv) {
            this.Key = key;
            this.IV = iv;
        }
    }
}
