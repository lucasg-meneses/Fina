using System.ComponentModel.DataAnnotations;

namespace Fina.Core.Request.Categories
{
    public class GetCategoryByIdRequest : Request
    {
        [Required(ErrorMessage ="Identificador inválido")]
        public long Id { get; set; }
    }
}
