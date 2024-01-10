using Microsoft.AspNetCore.DataProtection;

namespace H4ServersideProgrammering.Codes;

/// <summary>
/// 1. Microsoft.AspNetCore.DataProtection
/// 2. builder.Services.AddDataProtection();
/// </summary>
/// <param name="textToEncrypt"></param>
public class SymetricEncriptionExample
{
    private readonly IDataProtector _protector;

    public SymetricEncriptionExample(IDataProtectionProvider protector)
    {
        _protector = protector.CreateProtector("dsdffsf8767fsff@dsfafd");
    }
    
    public string Encrypt(string textToEncrypt)
    {
        return _protector.Protect(textToEncrypt);
    }

    public string Decrypt(string textToDecrypt)
    {
        return _protector.Unprotect(textToDecrypt);
    }
}
