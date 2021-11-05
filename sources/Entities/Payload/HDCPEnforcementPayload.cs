using System;
using System.IO;
using FoolishTech.Support.Binary;
using FoolishTech.Support.Throws;

namespace FoolishTech.FairPlay.Entities.Payload
{
    sealed internal class HDCPEnforcementPayload 
    {
        private ReadOnlyMemory<byte> Storage { get; set; }

        internal FPHDCPContentType Type { get => ((FPHDCPContentType)BinaryConverter.ReadUInt64(this.Storage.Slice(0, 8), BinaryConverter.Endianess.BigEndian)).DefinedOrDefault(); }
        
        internal byte[] Binary { get => this.Storage.ToArray(); }

        internal HDCPEnforcementPayload(ReadOnlyMemory<byte> buffer)
        {
            // ArgumentThrow.IfNull(() => buffer, "Invalid buffer length. The buffer must not be null.", nameof(buffer)); /* STRUCT CAN NOT BE NULL. */
            ArgumentThrow.IfLengthNot(buffer, 8, $"Invalid buffer length. The buffer must contains the exact number of bytes to fill entity '{this.GetType().FullName}'.", nameof(buffer));

            this.Storage = buffer.Slice(0, 8);
        }

        internal HDCPEnforcementPayload(FPHDCPContentType type)
        {
            var stream = new MemoryStream();
            stream.Write(BinaryConverter.WriteUInt64((UInt64)type.DefinedOrDefault(), BinaryConverter.Endianess.BigEndian));
            this.Storage = new ReadOnlyMemory<byte>(stream.ToArray());
        }
    }

    public enum FPHDCPContentType : ulong
    {
        /// <summary>
        /// HDCP not required.
        /// </summary>
        NOT_REQUIRED = 0xef72894ca7895b78,

        /// <summary>
        /// HDCP Type 2 is required.
        /// HDCP Repeater may NOT:
        /// Output the content to ANY non-HDCP Protected interface; including:
        ///     Other Content Protection
        ///     Any analog Interface
        /// </summary>
        TYPE_0 = 0x40791ac78bd5c571,

        /// <summary>
        /// HDCP Type 1 is required.
        /// HDCP Repeater may NOT:
        /// Re-encrypt onto a lower HDCP version (e.g. HDCP 2.2 -> HDCP 2.0)
        /// Output the content to ANY non-HDCP Protected interface; including:
        ///     Other Content Protection
        ///     Any analog Interface
        /// </summary>
        TYPE_1 = 0x285a0863bba8e1d3
    }

    internal static class HDCPTypeRequierementExtensions 
    {
        public static FPHDCPContentType DefinedOrDefault(this FPHDCPContentType state)
        {   
            return Enum.IsDefined(typeof(FPHDCPContentType), state) ? state : FPHDCPContentType.TYPE_0;
        }
    } 
}
