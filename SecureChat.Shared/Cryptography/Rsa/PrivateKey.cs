using System.Security.Cryptography;

namespace SecureChat.Shared.Cryptography.Rsa;

public sealed class PrivateKey
{
    public PublicKey PublicKey { get; }
    private readonly RSA _rsa;

    public PrivateKey(string path)
    {
        _rsa = RSA.Create(4096);
        try
        {
            _rsa.ImportFromPem(File.ReadAllText(path));
        }
        catch (FileNotFoundException)
        {
            // File does not exist, lets create a key then
            SaveKey(path);
        }
        
        PublicKey = new PublicKey(_rsa.ExportRSAPublicKeyPem());
    }

    private void SaveKey(string path)
    {
        File.WriteAllText(path, _rsa.ExportRSAPrivateKeyPem());
    }

    public byte[] Decrypt(byte[] data)
        => _rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA256);
}