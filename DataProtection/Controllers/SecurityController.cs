using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataProtection.Controllers
{
    [ApiController]
    [Route("controller")]
    public class SecurityController : ControllerBase
    {
        private readonly IDataProtector dataProtector;

        public SecurityController(IDataProtectionProvider dataProtectionProvider)
        {
            this.dataProtector = dataProtectionProvider.CreateProtector("secret");
        }


        [HttpGet]
        public IActionResult Index()
        {
            string plainText = "deneme";
            string encryptedText = dataProtector.Protect(plainText);
            string decryptedText = dataProtector.Unprotect(plainText);

            return Ok(new { plainText, encryptedText, decryptedText });
        }
    }
}
