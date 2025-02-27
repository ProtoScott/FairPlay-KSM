using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Options;
using Protostream.sources.Extensions;
using Protostream.sources.Options;
using Protostream.Support.Throws;

namespace Protostream.FairPlay
{
    public sealed class FPProvider
    {
        internal X509Certificate RSACertificate { get; private set; }
        internal RSAParameters RSAKey { get; private set; }
        internal byte[] ASKey { get; private set; }

        public string Identifier { get => this.RSACertificate.GetCertHashString(); }
        public string Name { get => this.RSACertificate.Subject; }
        public byte[] Hash { get => this.RSACertificate.GetCertHash(); }
        public byte[] Certificate { get => this.RSACertificate.Export(X509ContentType.Cert); }

        public FPProvider(IOptions<FPProviderOptions> providerOptions)
        {
            ArgumentThrow.IfNull(providerOptions, "Invalid App Settings.", nameof(providerOptions));
            ArgumentThrow.IfNull(providerOptions.Value, "Invalid App Settings.", nameof(providerOptions));

            if (string.IsNullOrWhiteSpace(providerOptions.Value.CertificateBase64))
            {
                throw new Exception("FairPlay Certificate must not be null");
            }
            if (string.IsNullOrWhiteSpace(providerOptions.Value.AskHex))
            {
                throw new Exception("Application Secret Key must not be null");
            }

            Init(Convert.FromBase64String(providerOptions.Value.CertificateBase64),
                 providerOptions.Value.CertificatePassphrase,
                 providerOptions.Value.AskHex.HexToByteArray());
        }

        public FPProvider(byte[] certificate, string password, byte[] ask)
        {
            Init(certificate, password, ask);
        }

        private void Init(byte[] certificate, string password, byte[] ask)
        {
            ArgumentThrow.IfNull(certificate, "Invalid FairPlay Certificate. Certificate can not be null.", nameof(certificate));
            ArgumentThrow.IfNull(password, "Invalid FairPlay Certificate passphrase. Passphrase can not be null.", nameof(password));
            ArgumentThrow.IfLengthNot(ask, 16, "Invalid Application Secret Key. ASK buffer should be 16 bytes.", nameof(ask));

            try
            {
                X509Certificate2 X509 = new X509Certificate2(certificate, password, X509KeyStorageFlags.Exportable);

                using (var rsa = X509.GetRSAPrivateKey())
                {
                    this.RSACertificate = X509;
                    this.RSAKey = rsa.ExportParameters(true);
                    this.ASKey = ask;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid FairPlay Certificate. Certificate can not be read.", nameof(certificate), ex);
            }
        }
    }
}
