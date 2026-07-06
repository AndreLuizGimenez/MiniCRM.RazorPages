using System.ComponentModel.DataAnnotations;

namespace MiniCRM.RazorPages.Models;

public enum CustomerStatus
{
    [Display(Name = "Novo")]
    Novo = 1,

    [Display(Name = "Em negociação")]
    EmNegociacao = 2,

    [Display(Name = "Fechado")]
    Fechado = 3,

    [Display(Name = "Perdido")]
    Perdido = 4
}
