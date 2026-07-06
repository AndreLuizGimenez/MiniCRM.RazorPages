using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniCRM.RazorPages.Data;
using MiniCRM.RazorPages.Models;

namespace MiniCRM.RazorPages.Pages.Customers;

public class EditModel : PageModel
{
    private readonly MiniCrmDbContext _context;

    public EditModel(MiniCrmDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Customer Customer { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer is null)
        {
            return NotFound();
        }

        Customer = customer;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (id != Customer.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var customerToUpdate = await _context.Customers.FindAsync(id);

        if (customerToUpdate is null)
        {
            return NotFound();
        }

        customerToUpdate.Nome = Customer.Nome.Trim();
        customerToUpdate.Email = Customer.Email.Trim();
        customerToUpdate.Telefone = Customer.Telefone?.Trim();
        customerToUpdate.Documento = Customer.Documento?.Trim();
        customerToUpdate.Status = Customer.Status;

        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Cliente atualizado com sucesso.";
        return RedirectToPage("./Details", new { id = customerToUpdate.Id });
    }
}
