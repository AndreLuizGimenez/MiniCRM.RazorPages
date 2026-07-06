using System.ComponentModel.DataAnnotations;

namespace MiniCRM.RazorPages.Models;

public class Attendance
{
    public int Id { get; set; }

    [Display(Name = "Cliente")]
    [Range(1, int.MaxValue, ErrorMessage = "Selecione um cliente.")]
    public int ClienteId { get; set; }

    public Customer? Cliente { get; set; }

    [Display(Name = "Tipo de atendimento")]
    [Required(ErrorMessage = "O tipo de atendimento é obrigatório.")]
    public AttendanceType TipoAtendimento { get; set; }

    [Display(Name = "Data do atendimento")]
    [Required(ErrorMessage = "A data do atendimento é obrigatória.")]
    [DataType(DataType.DateTime)]
    public DateTime DataAtendimento { get; set; } = DateTime.Now;

    [Display(Name = "Observação")]
    [Required(ErrorMessage = "A observação é obrigatória.")]
    [StringLength(1000, ErrorMessage = "A observação deve ter no máximo 1000 caracteres.")]
    public string Observacao { get; set; } = string.Empty;

    [Display(Name = "Próximo passo")]
    [StringLength(500, ErrorMessage = "O próximo passo deve ter no máximo 500 caracteres.")]
    public string? ProximoPasso { get; set; }
}
