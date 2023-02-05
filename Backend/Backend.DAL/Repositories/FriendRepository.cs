using Microsoft.EntityFrameworkCore;
using Backend.DAL.Entities;
using Backend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        public readonly AppDbContext _context;
        public FriendRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> addFriend(string username1, string username2)
        {
            var user1 = await _context.Users.Where(x => x.UserName == username1).FirstOrDefaultAsync();
            var user2 = await _context.Users.Where(x => x.UserName == username2).FirstOrDefaultAsync();
            if ((user1 == null) || (user2 == null))
            {
                return 0;
            }
            if (user1==user2)
            {
                return 1;
            }
            var friendVerif = await _context.Friends.Where(x => x.UserId == user1.Id).Where(x => x.FriendId == user2.Id).FirstOrDefaultAsync();
            if (friendVerif != null)
            {
                return 2;
            }
            var friend = new Friend
            {
                FriendId = user2.Id,
                UserId = user1.Id,
                UserName = username2,
                FirstName = user2.FirstName,
                LastName = user2.LastName,
                IBAN = user2.IBAN,
                Sold = user2.Sold
            };
            _context.Friends.Add(friend);
            await _context.SaveChangesAsync();
            return 3;
        }

        public async Task<int> removeFriend(string username1, string username2)
        {
            var user1 = await _context.Users.Where(x => x.UserName == username1).FirstOrDefaultAsync();
            var user2 = await _context.Users.Where(x => x.UserName == username2).FirstOrDefaultAsync();
            if ((user1 == null) || (user2 == null))
            {
                return 0;
            }
            if (user1 == user2)
            {
                return 1;
            }
            var Friend = await _context.Friends.Where(x => x.UserId == user1.Id).Where(x=> x.FriendId == user2.Id).FirstOrDefaultAsync();
            if (Friend == null)
            {
                return 2;
            }
            _context.Friends.Remove(Friend);
            await _context.SaveChangesAsync();
            return 3;
        }
    }
}
