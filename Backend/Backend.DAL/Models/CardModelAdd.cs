using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Models
{
    public class CardModelAdd  
    {
        public string Pin { get; set; }
        public string CVV { get; set; }
        public int MonthExp { get; set; }
        public int YearExp { get; set; }
        public int Sold { get; set; }
    }
}
