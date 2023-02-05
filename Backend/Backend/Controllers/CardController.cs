using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.BLL.Interfaces;
using Backend.DAL.Models;
using System;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardManager _cardManager;
        public CardController(ICardManager cardManager)
        {
            _cardManager = cardManager;
        }

        [HttpPost("addCardToUser")]
        public async Task<IActionResult> addCard(CardModelAdd card, string username)
        {
            var result = await _cardManager.addCard(card,username);

            return Ok(result);
        }

        [HttpGet("checkSold")]
        public async Task<IActionResult> checkSold(int id)
        {
            return Ok(await _cardManager.checkSold(id));
        }

        [HttpDelete("removeCard")]
        public async Task<IActionResult> removeCard(int id)
        {
            Boolean result = await _cardManager.removeCard(id);
            if (result == true)
            {
                return Ok("success");
            }
            else
            {
                return BadRequest("Card does not exist");
            }
        }
    }
}
