using FoolishTech.FairPlay.Entities.Payload;
using FoolishTech.sources.Constants;

namespace FoolishTech.sources.Models
{
    public class FPLicenseOptions
    {

        public FPHDCPContentType HDCPContentType { get; set; }

        public FPKeyType KeyType { get; }

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
