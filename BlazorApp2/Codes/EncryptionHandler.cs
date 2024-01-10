using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
namespace BlazorApp2.Codes
{
    public class EncryptionHandler
    {
        private readonly IDataProtector _protector;
        public string PublicKey { get; }
        private string PrivateKey { get; }
        public EncryptionHandler(IDataProtectionProvider protector)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                PrivateKey = rsa.ToXmlString(true);
                PublicKey = rsa.ToXmlString(false);
                _protector = protector.CreateProtector(PrivateKey);
            }

        }

        public string Encrypt(string textToEncrypt)
        {
            return _protector.Protect(textToEncrypt);
        }

        public string Decrypt(string textToDecrypt)
        {
            return _protector.Unprotect(textToDecrypt);
        }

        public string EncryptForAsymetric(string dataToEncrypt)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Import the public key
                rsa.FromXmlString(PublicKey);

                // Choose to return this for machine to machine communication.
                byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(dataToEncrypt);

                // Encrypt the data
                byte[] encryptedDataAsByteArray = rsa.Encrypt(System.Text.Encoding.UTF8.GetBytes(dataToEncrypt), false);
                var encryptedDataAsString = Convert.ToBase64String(encryptedDataAsByteArray);

                return encryptedDataAsString;
            }
        }

        public string DecryptForAsymetric(string textToDecrypt)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Import the private key
                rsa.FromXmlString(PrivateKey);

                byte[] decryptedDataAsByteArray = rsa.Decrypt(Convert.FromBase64String(textToDecrypt), false);
                string decryptedDataAsString = System.Text.Encoding.UTF8.GetString(decryptedDataAsByteArray);

                return decryptedDataAsString;
            }
        }

    }
        
}
