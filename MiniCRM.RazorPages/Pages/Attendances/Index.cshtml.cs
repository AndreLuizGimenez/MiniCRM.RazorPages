using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniCRM.RazorPages.Data;
using MiniCRM.RazorPages.Models;

namespace MiniCRM.RazorPages.Pages.Attendances;

public class IndexModel : PageModel
{
    private readonly MiniCrmDbContext _context;

    public IndexModel(MiniCrmDbContext context)
    {
        _context = context;
    }

    public Customer Customer { get; private set; } = new();

    public async Task<IActionResult> OnGetAsync(int customerId)
    {
        var customer = await _context.Customers
            .Include(customer => customer.Atendimentos)
            .AsNoTracking()
            .FirstOrDefaultAsync(customer => customer.Id == customerId);

        if (customer is null)
        {
            return NotFound();
        }

        Customer = customer;
        return Page();
    }
}
