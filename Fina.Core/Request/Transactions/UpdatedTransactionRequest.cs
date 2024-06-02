
using System.ComponentModel.DataAnnotations;
using Fina.Core.Enums;

namespace Fina.Core.Request.Transactions
{
    public class UpdatedTransactionRequest : Request
    {

        [Required(ErrorMessage = "Identificador inválido")]
        public long Id { get; set; }
        [Required(ErrorMessage = "Titulo inválido")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Categoria inválida")]
        public long CategoryId { get; set; }

        [Required(ErrorMessage = "Valor inválido")]
        public decimal Amount { get; set; }
        public ETransactionType TransactionType { get; set; }
    }
}


