using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Entities
{
    public class Friend
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string IBAN { get; set; }
        public int Sold { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }


    }
}
