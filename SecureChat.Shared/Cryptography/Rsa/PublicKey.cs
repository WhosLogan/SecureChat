using System.Security.Cryptography;

namespace SecureChat.Shared.Cryptography.Rsa;

public sealed class PublicKey
{
    private readonly RSA _rsa;
    public string PublicKeyString { get; init; }

    public PublicKey(string publicKey)
    {
        _rsa = RSA.Create();
        _rsa.ImportFromPem(publicKey);
        PublicKeyString = publicKey;
    }

    public byte[] Encrypt(byte[] data)
        => _rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
}