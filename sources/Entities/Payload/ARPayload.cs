using System;
using System.IO;
using Protostream.Support.Throws;

namespace Protostream.FairPlay.Entities.Payload 
{
    sealed internal class ARPayload 
    {
        private ReadOnlyMemory<byte> Storage { get; set; }

        internal byte[] Seed { get => this.Storage.Slice(0, 16).ToArray(); }

        internal byte[] Binary { get => this.Storage.ToArray(); }

        internal ARPayload(ReadOnlyMemory<byte> buffer)
        {
            // ArgumentThrow.IfNull(() => buffer, "Invalid buffer length. The buffer must not be null.", nameof(buffer)); /* STRUCT CAN NOT BE NULL. */
            ArgumentThrow.IfLengthNot(buffer, 16, $"Invalid buffer length. The buffer must contains the exact number of bytes to fill entity '{this.GetType().FullName}'.", nameof(buffer));
            
            this.Storage = buffer.Slice(0, 16);
        }

        internal ARPayload(byte[] seed)
        {
            ArgumentThrow.IfLengthNot(seed, 16, $"Invalid seed buffer length. The buffer must contains 16 bytes.", nameof(seed));

            var stream = new MemoryStream();
            stream.Write(seed);
            this.Storage = new ReadOnlyMemory<byte>(stream.ToArray());
        }
    }
}
