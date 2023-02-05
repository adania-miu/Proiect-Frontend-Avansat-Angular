using Microsoft.EntityFrameworkCore;
using Backend.DAL.Entities;
using Backend.DAL.Interfaces;
using Backend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Repositories
{
    public class CardRepository : ICardRepository
    {
        public readonly AppDbContext _context;
        public CardRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> addCard(CardModelAdd card, string username)
        {
            var user = await _context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
            if (user == null)
                return false;
            else {
                var cardModel = new Card
                {
                    CVV = card.CVV,
                    Pin = card.Pin,
                    MonthExp = card.MonthExp,
                    YearExp = card.YearExp,
                    Sold = card.Sold,
                    UserId = user.Id
                };
                _context.Cards.Add(cardModel);
                await _context.SaveChangesAsync();
                return true;
            }

        }

        public async Task<int> checkSold(int id)
        {
            var card = await _context.Cards.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (card == null)
            {
                return 0;
            }
            return card.Sold;
        }

        public async Task<bool> removeCard(int id)
        {
            var card = await _context.Cards.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (card == null)
            {
                return false;
            }
            _context.Remove(card);
            await _context.SaveChangesAsync();
            return true;
        }

        public CardModelAdd toCardModel(Card cardEntity)
        {
            var cardModel = new CardModelAdd
            {
                Pin = cardEntity.Pin,
                CVV = cardEntity.CVV,
                MonthExp = cardEntity.MonthExp,
                YearExp = cardEntity.YearExp,
                Sold = cardEntity.Sold
            };
            return cardModel;
        }
    }
}
