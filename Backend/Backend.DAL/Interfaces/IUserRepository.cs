using Backend.DAL.Entities;
using Backend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<Boolean> removeUser(String username);
        Task<Boolean> emailExist(String email);
        Task<Boolean> usernameExist(String username);
        Task<string> getIBAN(String username);
        Task<int> checkSold(String username);
        Task<UserModel> toUserModel(User userEntity);
        Task<UserModel> GetUserByName(string username);
        Task<int> addMoneyFromCard(string username, int idCard, int amount);
        Task<List<CardModelAdd>> getUserCards(string username);
        Task<List<string>> getFriendsUsername(string username);

    }
}
