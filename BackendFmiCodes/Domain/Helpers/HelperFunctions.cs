using System.Security.Cryptography;
using System.Text;

namespace Domain.Helpers;

public class HelperFunctions
{
    public static bool CheckIsValidSignature(string publicKeyBase,string challengeCode, string signature)
    {
        byte[] publicKeyBytes = Convert.FromBase64String(publicKeyBase);
        byte[] signatureBytes = Convert.FromBase64String(signature);
        byte[] challengeBytes = Encoding.UTF8.GetBytes(challengeCode);

        using var rsa = RSA.Create();
        rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);

        return rsa.VerifyData(
            challengeBytes,
            signatureBytes,
            HashAlgorithmName.SHA256,
            RSASignaturePadding.Pkcs1
        );
    }
}