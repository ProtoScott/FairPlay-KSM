using System;
using System.IO;
using Protostream.Support.Throws;

namespace Protostream.FairPlay.Entities.Payload
{
    sealed internal class R1Payload 
    {
        private ReadOnlyMemory<byte> Storage { get; set; }

        internal byte[] R1 { get => this.Storage.Slice(0, 44).ToArray(); }
        
        internal byte[] Binary { get => this.Storage.ToArray(); }

        internal R1Payload(ReadOnlyMemory<byte> buffer)
        {
            // ArgumentThrow.IfNull(() => buffer, "Invalid buffer length. The buffer must not be null.", nameof(buffer)); /* STRUCT CAN NOT BE NULL. */
            ArgumentThrow.IfLengthNot(buffer, 44, $"Invalid buffer length. The buffer must contains the exact number of bytes to fill entity '{this.GetType().FullName}'.", nameof(buffer));
            
            this.Storage = buffer.Slice(0, 44);
        }

        internal R1Payload(byte[] random)
        {
            ArgumentThrow.IfLengthNot(random, 44, $"Invalid random buffer length. The buffer must contains 44 bytes.", nameof(random));

            var stream = new MemoryStream();
            stream.Write(random);
            this.Storage = new ReadOnlyMemory<byte>(stream.ToArray());
        }
    }
}
