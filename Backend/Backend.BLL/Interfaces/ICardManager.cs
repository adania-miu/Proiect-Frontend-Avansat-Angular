using Backend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BLL.Interfaces
{
    public interface ICardManager
    {
        Task<Boolean> removeCard(int id);
        Task<Boolean> addCard(CardModelAdd card, string username);
        Task<int> checkSold(int id);
    }
}
