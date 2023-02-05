using Microsoft.EntityFrameworkCore;
using Backend.DAL.Entities;
using Backend.DAL.Interfaces;
using Backend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Backend.DAL.Repositories
{
    public class TranzactionRepository : ITranzactieRepository
    {
        public readonly AppDbContext _context;
        public TranzactionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> createTransactionIBAN(string IBAN1, int suma, string IBAN2)
        {
            var user1 = await _context.Users.Where(x => Equals(x.IBAN,IBAN1)).FirstOrDefaultAsync();
            var user2 = await _context.Users.Where(x => Equals(x.IBAN, IBAN2)).FirstOrDefaultAsync();
            if ((user1 == null)||(user2==null))
            {
                return 0;
            }
            if (user1.Sold<suma)
            {
                return 1;
            }
            else
            {
                user2.Sold = user2.Sold + suma;
                user1.Sold = user1.Sold - suma;
                var transaction = new Tranzactie
                {
                    Suma = suma,
                    UserId = user1.Id
                };
                _context.Tranzactii.Add(transaction);
                await _context.SaveChangesAsync();
                return 2;
            }
        }

        public async Task<int> createTransactionUsername(string username1, int suma, string username2)
        {
            var user1 = await _context.Users.Where(x => x.UserName == username1).FirstOrDefaultAsync();
            var user2 = await _context.Users.Where(x => x.UserName == username2).FirstOrDefaultAsync();
            if ((user1 == null) || (user2 == null))
            {
                return 0;
            }
            if (user1.Sold < suma)
            {
                return 1;
            }
            else
            {
                user2.Sold = user2.Sold + suma;
                user1.Sold = user1.Sold - suma;
                var transaction = new Tranzactie
                {
                    Suma = suma,
                    UserId = user1.Id
                };
                _context.Tranzactii.Add(transaction);
                await _context.SaveChangesAsync();
                return 2;
            }
        }
    }
}
