using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniCRM.RazorPages.Data;
using MiniCRM.RazorPages.Models;

namespace MiniCRM.RazorPages.Pages.Attendances;

public class DeleteModel : PageModel
{
    private readonly MiniCrmDbContext _context;

    public DeleteModel(MiniCrmDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Attendance Attendance { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var attendance = await _context.Attendances
            .Include(attendance => attendance.Cliente)
            .AsNoTracking()
            .FirstOrDefaultAsync(attendance => attendance.Id == id);

        if (attendance is null)
        {
            return NotFound();
        }

        Attendance = attendance;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var attendance = await _context.Attendances.FindAsync(Attendance.Id);

        if (attendance is null)
        {
            return NotFound();
        }

        var customerId = attendance.ClienteId;

        _context.Attendances.Remove(attendance);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Atendimento excluído com sucesso.";
        return RedirectToPage("/Customers/Details", new { id = customerId });
    }
}
