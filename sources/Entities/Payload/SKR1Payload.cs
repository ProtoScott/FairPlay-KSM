using System;
using System.IO;
using Protostream.Support.Throws;

namespace Protostream.FairPlay.Entities.Payload
{
    sealed internal class SKR1Payload 
    {
        private ReadOnlyMemory<byte> Storage { get; set; }

        internal byte[] IV { get => this.Storage.Slice(0, 16).ToArray(); }
        internal byte[] Parcel { get => this.Storage.Slice(16, 96).ToArray(); }
        
        internal byte[] Binary { get => this.Storage.ToArray(); }

        internal SKR1Payload(ReadOnlyMemory<byte> buffer)
        {
            // ArgumentThrow.IfNull(() => buffer, "Invalid buffer length. The buffer must not be null.", nameof(buffer)); /* STRUCT CAN NOT BE NULL. */
            ArgumentThrow.IfLengthNot(buffer, 112, $"Invalid buffer length. The buffer must contains the exact number of bytes to fill entity '{this.GetType().FullName}'.", nameof(buffer));
            
            this.Storage = buffer.Slice(0, 112);
        }

        internal SKR1Payload(byte[] iv, byte[] parcel)
        {
            ArgumentThrow.IfLengthNot(iv, 16, "Invalid IV buffer length. The buffer must contains 16 bytes.", nameof(iv));
            ArgumentThrow.IfLengthNot(parcel, 96, "Invalid parcel buffer length. The buffer must contains 96 bytes.", nameof(parcel));

            var stream = new MemoryStream();
            stream.Write(iv);
            stream.Write(parcel);
            this.Storage = new ReadOnlyMemory<byte>(stream.ToArray());
        }
    }
}
