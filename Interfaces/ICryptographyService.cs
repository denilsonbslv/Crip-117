namespace Crip_117.Interfaces
{
    public interface ICryptographyService
    {
        string Encrypt(string text);
        string Decrypt(string text);
    }
}
