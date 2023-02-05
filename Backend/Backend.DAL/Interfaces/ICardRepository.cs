using Backend.DAL.Entities;
using Backend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Interfaces
{
    public interface ICardRepository
    {
            Task<Boolean> removeCard(int id);
            Task<Boolean> addCard(CardModelAdd card, string username);
            Task<int> checkSold(int id);
            public CardModelAdd toCardModel(Card cardEntity);


    }
}
