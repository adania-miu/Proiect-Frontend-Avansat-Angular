using Backend.BLL.Interfaces;
using Backend.DAL.Interfaces;
using Backend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BLL.Managers
{
    public class CardManager : ICardManager
    {
        private readonly ICardRepository _cardRepository;
        public CardManager(ICardRepository CardRepository)
        {
            _cardRepository = CardRepository;
        }
        public async Task<bool> addCard(CardModelAdd card, string username)
        {
            return await _cardRepository.addCard(card,username);
        }

        public async Task<int> checkSold(int id)
        {
            return await _cardRepository.checkSold(id);
        }

        public async Task<bool> removeCard(int id)
        {
            return await _cardRepository.removeCard(id);
        }
    }
}
