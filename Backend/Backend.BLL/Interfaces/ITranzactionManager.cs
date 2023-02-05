using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BLL.Interfaces
{
    public interface ITranzactionManager
    {
        Task<int> createTransactionUsername(string username1, int suma, string username2);
        Task<int> createTransactionIBAN(string IBAN1, int suma, string IBAN2);
    }
}
