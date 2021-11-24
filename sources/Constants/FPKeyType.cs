namespace Protostream.sources.Constants
{
    /// <summary>
    /// FairPlay Streaming Programing Guide.pdf
    /// </summary>
    public enum FPKeyType : uint
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0x0,

        /// <summary>
        /// Rental and lease key types for persistence
        /// Content key can be persisted with unlimited validity duration.
        /// </summary>
        PersistedUnlimited = 0x3df2d9fb,

        /// <summary>
        /// Rental and lease key types for persistence
        /// Content key can be persisted, and its validity duration is 
        /// limited to the “Rental Duration” value.
        /// </summary>
        PersistedRental = 0x18f06048,

        /// <summary>
        /// Rental and lease key types
        /// Content key valid for lease only.
        /// </summary>
        LeaseOnly = 0x1a4bde7e,

        /// <summary>
        /// Rental and lease key types
        /// Content key valid for rental only.
        /// </summary>
        RentalOnly = 0x3dfe45a0,

        /// <summary>
        /// Rental and lease key types
        /// Content key valid for both lease and rental.
        /// </summary>
        LeaseAndRental = 0x27b59bde
    }
}
