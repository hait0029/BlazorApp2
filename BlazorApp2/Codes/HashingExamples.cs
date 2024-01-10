using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BlazorApp2.Components.Pages;

namespace BlazorApp2.Codes;

internal class HashingExamples
{
    /// <summary>
    /// Commonly used to encode binary data for storage or transfer over media that can only deal with ASCII text.
    /// The hashed value is always the same.
    /// The hashed value is not encrypted and can be reversed.
    /// </summary>
    public static string Base64Hashing(string textToHash)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);

        string base64 = Convert.ToBase64String(inputBytes);

        return base64;
    }

    public static string MD5Hashing(string textToHash)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);

        MD5 md5 = MD5.Create();
        byte[] hash = md5.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();
        foreach (byte b in hash)
        {
            sb.Append(b.ToString("X2"));
        }

        return sb.ToString();
    }

    public string SHA1Hashing(string textToHash)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);

        SHA1 sha1 = SHA1.Create();
        byte[] hash = sha1.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();
        foreach (byte b in hash)
        {
            sb.Append(b.ToString("X2"));
        }

        return sb.ToString();
    }

    public string SHA256Hashing(string textToHash)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);

        SHA256 sha256 = SHA256.Create();
        byte[] hash = sha256.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();
        foreach (byte b in hash)
        {
            sb.Append(b.ToString("X2"));
        }

        return sb.ToString();
    }
    
    public string AESHashing(string textToHash)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);

        Aes aes = Aes.Create();
        byte[] hash = aes.Key;

        StringBuilder sb = new StringBuilder();
        foreach (byte b in hash)
        {
            sb.Append(b.ToString("X2"));
        }

        return sb.ToString();
    }

    public string HMACHashing(string textToHash)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);

        HMACSHA1 hmac = new HMACSHA1();
        //HMACSHA256 hmac = new HMACSHA256();
        byte[] hash = hmac.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();
        foreach (byte b in hash)
        {
            sb.Append(b.ToString("X2"));
        }

        return sb.ToString();
    }

    /// <summary>
    /// Requires the Microsoft.AspNetCore.Cryptography.KeyDerivation package.
    /// </summary>
    /// <param name="textToHash"></param>
    /// <returns></returns>
    public static string PBKDF2Hashing(string textToHash, string salt)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);
        byte[] saltAsbytes = Encoding.ASCII.GetBytes(salt);
        var hashAlgorithm = new System.Security.Cryptography.HashAlgorithmName("SHA256");

        var hashedTextAsBytes = System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2(inputBytes, saltAsbytes, 3, hashAlgorithm, 32);

        string hashed = Convert.ToBase64String(hashedTextAsBytes);

        return hashed;
    }

    public static bool PBKDF2VerifyHashing(string textToHash, string salt, string hashedValue)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);
        byte[] saltAsbytes = Encoding.ASCII.GetBytes(salt);
        var hashAlgorithm = new System.Security.Cryptography.HashAlgorithmName("SHA256");

        var hashedTextAsBytes = System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2(inputBytes, saltAsbytes, 1000, hashAlgorithm, 32);

        string hashed = Convert.ToBase64String(hashedTextAsBytes);

        bool hash = hashed == hashedValue;
        return hash;
    }

    /// <summary>
    /// Requires the BCrypt.Net-Next package.
    /// </summary>
    /// <param name="textToHash"></param>
    /// <returns></returns>
    public static string BCryptHashing(string textToHash)
    {
        string hash = BCrypt.Net.BCrypt.HashPassword(textToHash);

        return hash;
    }

    public static bool BCryptVerifyHashing(string textToHash, string hashedValue)
    {
        bool hash = BCrypt.Net.BCrypt.Verify(textToHash, hashedValue);
        return hash;
    }
}
