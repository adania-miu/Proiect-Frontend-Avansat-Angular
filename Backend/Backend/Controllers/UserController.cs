using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.BLL.Interfaces;
using System;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userManager.GetAllUsers());
        }

        [HttpDelete("removeUser")]
        public async Task<IActionResult> RemoveUser(String username)
        {
            Boolean result = await _userManager.removeUser(username);
            if (result == true)
            {
                return Ok("success");
            }
            else
            {
                return BadRequest("Username does not exist");
            }
        }
        [HttpGet("emailExist")]
        public async Task<IActionResult> EmailExist(String email)
        {
            Boolean result = await _userManager.emailExist(email);
            if (result == false)
            {
                return Ok("false");
            }
            else
            {
                return Ok("true");
            }
        }

        [HttpGet("usernameExist")]
        public async Task<IActionResult> UsernameExist(String username)
        {
            Boolean result = await _userManager.usernameExist(username);
            if (result == false)
            {
                return Ok("false");
            }
            else
            {
                return Ok("true");
            }
        }

        [HttpGet("getUserByName")]
        public async Task<IActionResult> GetUserByName(string username)
        {
            var result = await _userManager.GetUserByName(username);
            if (result.UserName != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No user found!");
            }
        }

        [HttpPut("addMoneyFromCard")]
        public async Task<IActionResult> addMoneyFromCard(string username, int idCard,int amount)
        {

            var result = await _userManager.addMoneyFromCard(username,idCard,amount);
            if (result == 1)
                return BadRequest("No card found!");
            if (result == 2)
                return BadRequest("No user found!");
            if (result == 3)
                return BadRequest("This user can not acces this card!");
            if (result == 5)
                return BadRequest("Insufficient balance!");
            return Ok("Success!");
        }
        [HttpGet("getIBAN")]
        public async Task<IActionResult> getIBAN(string username)
        {
            var result = await _userManager.getIBAN(username);
            if (result != "error")
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No IBAN found!");


            }
        }
        [HttpGet("checkSold")]
        public async Task<IActionResult> checkSold(string username)
        {
            var result = await _userManager.checkSold(username);
            if (result != -1)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No user found!");

            }
        }
        [HttpGet("getUserCards")]
        public async Task<IActionResult> getUserCards(string username)
        {
            var result = await _userManager.getUserCards(username);
            return Ok(result);

        }
        [HttpGet("getUserFriends")]
        public async Task<IActionResult> getFriendsUsername(string username)
        {
            var result = await _userManager.getFriendsUsername(username);
            return Ok(result);

        }

    }
}
