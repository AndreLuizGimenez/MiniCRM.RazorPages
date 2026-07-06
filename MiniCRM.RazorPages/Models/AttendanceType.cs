using System.ComponentModel.DataAnnotations;

namespace MiniCRM.RazorPages.Models;

public enum AttendanceType
{
    [Display(Name = "WhatsApp")]
    WhatsApp = 1,

    [Display(Name = "Ligação")]
    Ligacao = 2,

    [Display(Name = "E-mail")]
    Email = 3,

    [Display(Name = "Reunião")]
    Reuniao = 4
}
