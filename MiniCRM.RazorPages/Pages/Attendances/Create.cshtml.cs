using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniCRM.RazorPages.Data;
using MiniCRM.RazorPages.Models;

namespace MiniCRM.RazorPages.Pages.Attendances;

public class CreateModel : PageModel
{
    private readonly MiniCrmDbContext _context;

    public CreateModel(MiniCrmDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Attendance Attendance { get; set; } = new();

    public IList<SelectListItem> CustomerOptions { get; private set; } = new List<SelectListItem>();

    public async Task OnGetAsync(int? customerId)
    {
        Attendance = new Attendance
        {
            ClienteId = customerId ?? 0,
            DataAtendimento = DateTime.Now
        };

        await LoadCustomerOptionsAsync(customerId);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await LoadCustomerOptionsAsync(Attendance.ClienteId);

        var customerExists = await _context.Customers.AnyAsync(customer => customer.Id == Attendance.ClienteId);
        if (!customerExists)
        {
            ModelState.AddModelError("Attendance.ClienteId", "Selecione um cliente válido.");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        Attendance.Observacao = Attendance.Observacao.Trim();
        Attendance.ProximoPasso = Attendance.ProximoPasso?.Trim();

        _context.Attendances.Add(Attendance);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Atendimento registrado com sucesso.";
        return RedirectToPage("/Customers/Details", new { id = Attendance.ClienteId });
    }

    private async Task LoadCustomerOptionsAsync(int? selectedCustomerId)
    {
        CustomerOptions = await _context.Customers
            .AsNoTracking()
            .OrderBy(customer => customer.Nome)
            .Select(customer => new SelectListItem
            {
                Value = customer.Id.ToString(),
                Text = $"{customer.Nome} - {customer.Email}",
                Selected = selectedCustomerId.HasValue && customer.Id == selectedCustomerId.Value
            })
            .ToListAsync();
    }
}
