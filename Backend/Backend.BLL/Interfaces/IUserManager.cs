using Backend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BLL.Interfaces
{
    public interface IUserManager
    {
        Task<Boolean> removeUser(String username);
        Task<Boolean> emailExist(String email);
        Task<Boolean> usernameExist(String username);
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserByName(string username);
        Task<int> addMoneyFromCard(string username, int idCard, int amount);
        Task<string> getIBAN(string username);
        Task<int> checkSold(string username);
        Task<List<CardModelAdd>> getUserCards(string username);
        Task<List<string>> getFriendsUsername(string username);

    }
}
