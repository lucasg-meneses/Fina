﻿using System.ComponentModel.DataAnnotations;

namespace Fina.Core.Request.Categories
{
    public class UpdatedCategoryRequest : Request
    {
        [Required(ErrorMessage = "Identificador inválido")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Titulo inválido")]
        [MaxLength(80, ErrorMessage = "o titulo deve conter até 80 caracteres")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição inválida")]
        public string Description { get; set; } = string.Empty;
    }
}
