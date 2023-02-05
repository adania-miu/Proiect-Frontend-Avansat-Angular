using Backend.BLL.Interfaces;
using Backend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BLL.Managers
{
    public class TranzactionManager : ITranzactionManager
    {
        private readonly ITranzactieRepository _tranzactionRepository;
        public TranzactionManager(ITranzactieRepository TranzactionRepository)
        {
            _tranzactionRepository = TranzactionRepository;
        }
        public async Task<int> createTransactionIBAN(string IBAN1, int suma, string IBAN2)
        {
            return await _tranzactionRepository.createTransactionIBAN(IBAN1, suma, IBAN2);
        }

        public async Task<int> createTransactionUsername(string username1, int suma, string username2)
        {
            return await _tranzactionRepository.createTransactionUsername(username1, suma, username2);
        }
    }
}
