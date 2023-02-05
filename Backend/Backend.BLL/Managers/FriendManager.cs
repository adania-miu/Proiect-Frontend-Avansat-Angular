using Backend.BLL.Interfaces;
using Backend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BLL.Managers
{
    public class FriendManager : IFriendManager
    {
        private readonly IFriendRepository _friendRepository;
        public FriendManager(IFriendRepository FriendRepository)
        {
            _friendRepository = FriendRepository;
        }
        public async Task<int> addFriend(string username1, string username2)
        {
            return await _friendRepository.addFriend(username1, username2);
        }

        public async Task<int> removeFriend(string username1, string username2)
        {
            return await _friendRepository.removeFriend(username1, username2);
        }
    }
}
