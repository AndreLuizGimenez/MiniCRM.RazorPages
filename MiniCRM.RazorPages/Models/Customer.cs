using System.ComponentModel.DataAnnotations;

namespace MiniCRM.RazorPages.Models;

public class Customer
{
    public int Id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(120, ErrorMessage = "O nome deve ter no máximo 120 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
    [StringLength(150, ErrorMessage = "O e-mail deve ter no máximo 150 caracteres.")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Telefone")]
    [Phone(ErrorMessage = "Informe um telefone válido.")]
    [StringLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
    public string? Telefone { get; set; }

    [Display(Name = "Documento")]
    [StringLength(30, ErrorMessage = "O documento deve ter no máximo 30 caracteres.")]
    public string? Documento { get; set; }

    [Display(Name = "Data de cadastro")]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    [Display(Name = "Status")]
    [Required(ErrorMessage = "O status do cliente é obrigatório.")]
    public CustomerStatus Status { get; set; } = CustomerStatus.Novo;

    public ICollection<Attendance> Atendimentos { get; set; } = new List<Attendance>();
}
