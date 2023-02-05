using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Entities
{
    public class User : IdentityUser<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string? RefreshToken { get; set; }
        public int Sold { get; set; }
        public string IBAN { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Tranzactie> Tranzactii{ get; set; }
        public ICollection<Friend> Friends { get; set; }


    }
}
