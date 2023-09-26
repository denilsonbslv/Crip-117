using Crip_117.Interfaces;
using Crip_117.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Crip_117.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptographyController : ControllerBase
    {
        private readonly ICryptographyService cryptographyService;

        public CryptographyController(ICryptographyService cryptographyService)
        {
            this.cryptographyService = cryptographyService;
        }

        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] string text)
        {
            try
            {
                AccentuationHandler AH = new AccentuationHandler();

                var teste = AH.HandleAccentuation('´');
                
                string encryptedText = cryptographyService.Encrypt(text);
                return Ok(encryptedText);
            }
            catch (Exception ex)
            {
                return BadRequest($"Encryption failed: {ex.Message}");
            }
        }

        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] string encryptedText)
        {
            try
            {
                string decryptedText = cryptographyService.Decrypt(encryptedText);
                return Ok(decryptedText);
            }
            catch (Exception ex)
            {
                return BadRequest($"Decryption failed: {ex.Message}");
            }
        }
    }
}
