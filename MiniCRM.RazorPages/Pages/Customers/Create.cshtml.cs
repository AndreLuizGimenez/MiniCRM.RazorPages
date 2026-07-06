using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniCRM.RazorPages.Data;
using MiniCRM.RazorPages.Models;

namespace MiniCRM.RazorPages.Pages.Customers;

public class CreateModel : PageModel
{
    private readonly MiniCrmDbContext _context;

    public CreateModel(MiniCrmDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Customer Customer { get; set; } = new();

    public void OnGet()
    {
        Customer.Status = CustomerStatus.Novo;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Customer.Nome = Customer.Nome.Trim();
        Customer.Email = Customer.Email.Trim();
        Customer.Telefone = Customer.Telefone?.Trim();
        Customer.Documento = Customer.Documento?.Trim();
        Customer.DataCadastro = DateTime.Now;

        _context.Customers.Add(Customer);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Cliente cadastrado com sucesso.";
        return RedirectToPage("./Index");
    }
}
