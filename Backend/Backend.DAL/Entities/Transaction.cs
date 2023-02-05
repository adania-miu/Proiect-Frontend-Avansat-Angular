using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIsAPI.DAL.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Suma { get; set; }
        public int UserSendId { get; set; }
        public int UserReceiveId { get; set; }
        public virtual User UserSend { get; set; }
        public virtual User UserReceive { get; set; }

        public Transaction(int suma, int userSend, int userReceive)
        {
            this.Suma = suma;
            this.UserSendId = userSend;
            this.UserReceiveId = userReceive;
        }

    }
}
