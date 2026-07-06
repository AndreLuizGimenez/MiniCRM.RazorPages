using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniCRM.RazorPages.Data;
using MiniCRM.RazorPages.Models;

namespace MiniCRM.RazorPages.Pages.Attendances;

public class EditModel : PageModel
{
    private readonly MiniCrmDbContext _context;

    public EditModel(MiniCrmDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Attendance Attendance { get; set; } = new();

    public IList<SelectListItem> CustomerOptions { get; private set; } = new List<SelectListItem>();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var attendance = await _context.Attendances.FindAsync(id);

        if (attendance is null)
        {
            return NotFound();
        }

        Attendance = attendance;
        await LoadCustomerOptionsAsync(attendance.ClienteId);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (id != Attendance.Id)
        {
            return NotFound();
        }

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

        var attendanceToUpdate = await _context.Attendances.FindAsync(id);

        if (attendanceToUpdate is null)
        {
            return NotFound();
        }

        attendanceToUpdate.ClienteId = Attendance.ClienteId;
        attendanceToUpdate.TipoAtendimento = Attendance.TipoAtendimento;
        attendanceToUpdate.DataAtendimento = Attendance.DataAtendimento;
        attendanceToUpdate.Observacao = Attendance.Observacao.Trim();
        attendanceToUpdate.ProximoPasso = Attendance.ProximoPasso?.Trim();

        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Atendimento atualizado com sucesso.";
        return RedirectToPage("/Customers/Details", new { id = attendanceToUpdate.ClienteId });
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
