using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Interfaces
{
    public interface IFriendRepository
    {
        Task<int> addFriend(string username1, string username2);
        Task<int> removeFriend(string username1, string username2);
    }
}
