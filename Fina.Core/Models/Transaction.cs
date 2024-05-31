using Fina.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ETransactionType TransactionType { get; set; }  = ETransactionType.Withdraw;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? PaidOrReceiveAt { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
