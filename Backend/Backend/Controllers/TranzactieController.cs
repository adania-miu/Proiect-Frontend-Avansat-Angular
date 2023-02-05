using Microsoft.AspNetCore.Mvc;
using Backend.BLL.Interfaces;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranzactieController : Controller
    {
        private readonly ITranzactionManager _tranzactionManager;
        public TranzactieController(ITranzactionManager tranzactieManager)
        {
            _tranzactionManager = tranzactieManager;
        }

        [HttpPost("createTransactionWithUsername")]
        public async Task<IActionResult> CreateTransactionUsername(string username1, int suma, string username2)
        {
            var result = await _tranzactionManager.createTransactionUsername(username1,suma, username2);
            if (result == 0)
                return BadRequest("No users found");
            if (result == 1)
                return BadRequest("Insufficient balance!");
            return Ok("Succes!");
        }

        [HttpPost("createTransactionWithIBAN")]
        public async Task<IActionResult> CreateTransactionWithIBAN(string IBAN1, int suma, string IBAN2)
        {
            var result = await _tranzactionManager.createTransactionIBAN(IBAN1, suma, IBAN2);
            if (result == 0)
                return BadRequest("No users found");
            if (result == 1)
                return BadRequest("Insufficient balance!");
            return Ok("Succes!");
        }
    }
}
