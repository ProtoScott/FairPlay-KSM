using Protostream.FairPlay.Entities.Payload;
using Protostream.sources.Constants;

namespace Protostream.sources.Models
{
    public class FPLicenseOptions
    {
        public FPHDCPContentType HDCPContentType { get; set; }

        public FPKeyType KeyType { get; set; }

        public int LicenseDuration { get; set; }

        public int RentalDuration { get; set; }

        public FPLicenseOptions()
        {
            HDCPContentType = FPHDCPContentType.TYPE_0;

            KeyType = FPKeyType.LeaseOnly;

            // 3 hours
            LicenseDuration = 10800;
        }
    }
}
