using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniCRM.RazorPages.Data;
using MiniCRM.RazorPages.Models;

namespace MiniCRM.RazorPages.Pages.Customers;

public class IndexModel : PageModel
{
    private readonly MiniCrmDbContext _context;

    public IndexModel(MiniCrmDbContext context)
    {
        _context = context;
    }

    [BindProperty(SupportsGet = true)]
    public string? SearchTerm { get; set; }

    public IList<Customer> Customers { get; private set; } = new List<Customer>();

    public async Task OnGetAsync()
    {
        var query = _context.Customers
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(SearchTerm))
        {
            var search = SearchTerm.Trim();
            query = query.Where(customer =>
                customer.Nome.Contains(search) ||
                customer.Email.Contains(search));
        }

        Customers = await query
            .OrderBy(customer => customer.Nome)
            .ToListAsync();
    }
}
