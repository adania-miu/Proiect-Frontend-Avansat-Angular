using Microsoft.AspNetCore.Mvc;
using Backend.BLL.Interfaces;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : Controller
    {
        private readonly IFriendManager _friendManager;
        public FriendController(IFriendManager friendManager)
        {
            _friendManager = friendManager;
        }
        [HttpPost("addFriend")]
        public async Task<IActionResult> addFriend(string username1, string username2)
        {
            var result = await _friendManager.addFriend(username1, username2);

            if (result == 0)
            {
                return BadRequest("No users found!");
            }
            if (result == 1)
            {
                return BadRequest("An user can not be his own friend!");
            }
            if (result == 2)
            {
                return BadRequest("The selected user is already a friend!");
            }
            return Ok("Succes!");
        }
        [HttpDelete("removeFriend")]
        public async Task<IActionResult> removeFriend(string username1, string username2)
        {
            var result = await _friendManager.removeFriend(username1, username2);

            if (result == 0)
            {
                return BadRequest("No users found!");
            }
            if (result == 1)
            {
                return BadRequest("An user can not be his own friend!");
            }
            if (result == 2)
            {
                return BadRequest("The selected user is not a friend!");
            }
            return Ok("Succes!");
        }
    }
}
