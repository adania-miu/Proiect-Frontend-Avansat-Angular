using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Entities
{
    public class Tranzactie
    {
        public int Id { get; set; }
        public int Suma { get; set; }
        public int UserId { get; set; }
        public virtual User User{ get; set; }

    }
}
