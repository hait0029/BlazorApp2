namespace H4ServersideProgrammering.Codes;

public class AsymetricEncryptionExample
{
    public string PublicKey { get; set; }
    private string PrivateKey { get; set; }

    public AsymetricEncryptionExample()
    {
        // Opretter nøgler:
        using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider())
        {
            PublicKey = rsa.ToXmlString(false);
            PrivateKey = rsa.ToXmlString(true);
        }
    }

    public string Encrypt(string dataToEncrypt, string publicKey)
    {
        using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider())
        {
            // Import the public key
            rsa.FromXmlString(publicKey);

            // Convert the string to bytes
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(dataToEncrypt);

            // Encrypt the data
            byte[] encryptedDataAsByteArray = rsa.Encrypt(System.Text.Encoding.UTF8.GetBytes(dataToEncrypt), false);
            var encryptedDataAsString = Convert.ToBase64String(encryptedDataAsByteArray);

            return encryptedDataAsString;
        }
    }

    public string Decrypt(string textToDecrypt)
    {
        using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider())
        {
            // Import the private key
            rsa.FromXmlString(PrivateKey);

            byte[] decryptedDataAsByteArray = rsa.Decrypt(Convert.FromBase64String(textToDecrypt), false);
            string decryptedDataAsString = System.Text.Encoding.UTF8.GetString(decryptedDataAsByteArray);

            return decryptedDataAsString;
        }
    }
}
