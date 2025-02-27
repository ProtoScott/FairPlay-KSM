using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Protostream.Support.Throws;
using Protostream.Support.Binary;

namespace Protostream.FairPlay.Entities.Payload 
{
    sealed internal class ProtocolSupportedPayload 
    {
        private ReadOnlyMemory<byte> Storage { get; set; }

        internal IEnumerable<UInt32> Versions { get => Enumerable.Range(0, this.Storage.Length / 4).Select((i) => BinaryConverter.ReadUInt32(this.Storage.Slice(i * 4, 4), BinaryConverter.Endianess.BigEndian)); }
        
        internal byte[] Binary { get => this.Storage.ToArray(); }

        internal ProtocolSupportedPayload(ReadOnlyMemory<byte> buffer)
        {
            // ArgumentThrow.IfNull(() => buffer, "Invalid buffer length. The buffer must not be null.", nameof(buffer)); /* STRUCT CAN NOT BE NULL. */
            ArgumentThrow.IfLengthNotMultiple(buffer, 4, $"Invalid buffer length. The buffer must contains the exact number of bytes to fill entity '{this.GetType().FullName}'.", nameof(buffer));

            this.Storage = buffer.Slice(0);
        }

        internal ProtocolSupportedPayload(IEnumerable<UInt32> versions)
        {
            ArgumentThrow.IfNull(versions, "Invalid version array. Version array can not be null.", nameof(versions));

            var stream = new MemoryStream();
            foreach (var version in versions) stream.Write(BinaryConverter.WriteUInt32(version, BinaryConverter.Endianess.BigEndian));
            this.Storage = new ReadOnlyMemory<byte>(stream.ToArray());
        }
    }
}
