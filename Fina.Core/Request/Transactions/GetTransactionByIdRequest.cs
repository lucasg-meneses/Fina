using System.ComponentModel.DataAnnotations;

namespace Fina.Core.Request.Transactions
{

    public class GetTransactionByIdRequest : Request
    {
        [Required(ErrorMessage = "Identificador inválido")]
        public long Id { get; set; }
    }
}
