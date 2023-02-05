using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Entities
{
    public class Card
    {
        public int Id { get; set; } 
        public string Pin { get; set; }
        public string CVV { get; set; }
        public int UserId { get; set; }
        public int Sold { get; set; }
        public int MonthExp { get; set; }
        public int YearExp { get; set; }
        public User User { get; set; }
    }
}
