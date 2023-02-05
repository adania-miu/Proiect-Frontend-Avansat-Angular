using Backend.BLL.Interfaces;
using Backend.DAL.Interfaces;
using Backend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BLL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepo;
        public UserManager(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<Boolean> removeUser(string username)
        {
            return await _userRepo.removeUser(username);
        }

        public async Task<bool> emailExist(string email)
        {
            return await _userRepo.emailExist(email);
        }

        public async Task<bool> usernameExist(string username)
        {
            return await _userRepo.usernameExist(username);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _userRepo.GetAllUsers();
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            return await _userRepo.GetUserByName(username);

        }

        public async Task<int> addMoneyFromCard(string username, int idCard, int amount)
        {
            return await _userRepo.addMoneyFromCard(username, idCard, amount);
        }

        public async Task<string> getIBAN(string username)
        {
            return await _userRepo.getIBAN(username);
        }

        public async Task<int> checkSold(string username)
        {
            return await _userRepo.checkSold(username);
        }

        public async Task<List<CardModelAdd>> getUserCards(string username)
        {
            return await _userRepo.getUserCards(username);
        }

        public async Task<List<string>> getFriendsUsername(string username)
        {
            return await _userRepo.getFriendsUsername(username);
        }
    }
}
