using Microsoft.EntityFrameworkCore;
using Backend.DAL.Entities;
using Backend.DAL.Interfaces;
using Backend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Boolean> removeUser(String username)
        {
            var userEntity = await _context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
            if (userEntity == null)
            {
                return false; // nu exista acest user
            }
            _context.Remove(userEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> emailExist(string email)
        {
            var userEntity = await _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            if (userEntity == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> usernameExist(string username)
        {
            var userEntity = await _context.Users.Where(x => x.UserName.ToLower() == username.ToLower()).FirstOrDefaultAsync();
            if (userEntity == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<UserModel> toUserModel(User userEntity)
        {
            var userModel = new UserModel
            {
                UserName = userEntity.UserName,
                Email = userEntity.Email,
                FirstName =userEntity.FirstName,
                LastName = userEntity.LastName,
                IBAN = userEntity.IBAN
            };
            return userModel;
        }

        async Task<List<UserModel>> IUserRepository.GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            var list = new List<UserModel>();
            foreach (var user in users)
            {
                var userModel = await toUserModel(user);
                list.Add(userModel);
            }
            return list;
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            var user = await _context.Users.Where(a => a.UserName.Equals(username)).FirstOrDefaultAsync();
            if (user != null)
            {
                var userReturn = await toUserModel(user);
                return userReturn;
            }
            else
            {
                var userReturn = new UserModel();
                return userReturn;
            }
        }

        public async Task<int> addMoneyFromCard(string username, int idCard,int amount)
        {
            var user = await _context.Users.Where(a => a.UserName.Equals(username)).FirstOrDefaultAsync();
            var card = await _context.Cards.Where(c => c.Id.Equals(idCard)).FirstOrDefaultAsync();
            if (card == null)
                return 1;
            if (user == null)
                return 2;
            if (user.Id != card.UserId)
                return 3;
            if (amount > card.Sold)
                return 5;
            user.Sold = user.Sold + amount;
            card.Sold = card.Sold - amount;
            _context.Update(card);
            _context.Update(user);
            await _context.SaveChangesAsync();
            return 4;
        }

        public async Task<string> getIBAN(string username)
        {
            var user = await _context.Users.Where(a => a.UserName.Equals(username)).FirstOrDefaultAsync();
            if (user != null)
                return user.IBAN;
            else
                return "error";
        }

        public async Task<int> checkSold(string username)
        {
            var user = await _context.Users.Where(a => a.UserName.Equals(username)).FirstOrDefaultAsync();
            if (user == null)
                return -1;
            else
            {
                return user.Sold;
            }
        }

        public async Task<List<CardModelAdd>> getUserCards(string username)
        {
            var user = await _context.Users.Where(a => a.UserName.Equals(username)).FirstOrDefaultAsync();
            if (user == null)
                return new List<CardModelAdd>();
            var cards = await _context.Cards.Where(a=>a.UserId.Equals(user.Id)).ToListAsync();
            var list = new List<CardModelAdd>();
            foreach (var card in cards)
            {
                var cardModel = new CardModelAdd
                {
                    Pin = card.Pin,
                    CVV = card.CVV,
                    MonthExp = card.MonthExp,
                    YearExp = card.YearExp,
                    Sold = card.Sold
                };
                list.Add(cardModel);
            }
            return list;
        }

        public async Task<List<string>> getFriendsUsername(string username)
        {
            var user = await _context.Users.Where(a => a.UserName.Equals(username)).FirstOrDefaultAsync();
            if (user == null)
                return new List<string>();
            var friends = await _context.Friends.Where(a => a.UserId.Equals(user.Id)).ToListAsync();
            var list = new List<string>();
            foreach (var friend in friends)
            {   
                list.Add(friend.UserName);
            }
            return list;
        }
    }
}
