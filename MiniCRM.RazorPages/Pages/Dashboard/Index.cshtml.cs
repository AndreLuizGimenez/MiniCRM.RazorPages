using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniCRM.RazorPages.Data;
using MiniCRM.RazorPages.Models;

namespace MiniCRM.RazorPages.Pages.Dashboard;

public class IndexModel : PageModel
{
    private readonly MiniCrmDbContext _context;

    public IndexModel(MiniCrmDbContext context)
    {
        _context = context;
    }

    public int TotalClientes { get; private set; }
    public int TotalNovos { get; private set; }
    public int TotalEmNegociacao { get; private set; }
    public int TotalFechados { get; private set; }
    public int TotalPerdidos { get; private set; }
    public IList<Attendance> UltimosAtendimentos { get; private set; } = new List<Attendance>();

    public async Task OnGetAsync()
    {
        TotalClientes = await _context.Customers.CountAsync();
        TotalNovos = await _context.Customers.CountAsync(customer => customer.Status == CustomerStatus.Novo);
        TotalEmNegociacao = await _context.Customers.CountAsync(customer => customer.Status == CustomerStatus.EmNegociacao);
        TotalFechados = await _context.Customers.CountAsync(customer => customer.Status == CustomerStatus.Fechado);
        TotalPerdidos = await _context.Customers.CountAsync(customer => customer.Status == CustomerStatus.Perdido);

        UltimosAtendimentos = await _context.Attendances
            .Include(attendance => attendance.Cliente)
            .OrderByDescending(attendance => attendance.DataAtendimento)
            .Take(5)
            .ToListAsync();
    }
}
