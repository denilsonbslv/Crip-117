using Crip_117.Interfaces;
using Crip_117.Utilities;

namespace Crip_117.Services
{
    public class CryptographyService : ICryptographyService
    {
        // Implementação da interface
        string ICryptographyService.Decrypt(string text)
        {
            throw new NotImplementedException();
        }

        string ICryptographyService.Encrypt(string text)
        {
            return new AlphabetEnumerator().GetAlphabetValue(text);
        }
    }
}
