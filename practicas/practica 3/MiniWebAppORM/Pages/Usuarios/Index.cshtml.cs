using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniWebAppORM.Data;
using MiniWebAppORM.Models;

namespace MiniWebAppORM.Pages.Usuarios;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Usuario> Usuarios { get; set; } = new();

    [BindProperty]
    public Usuario NuevoUsuario { get; set; } = new();

    public async Task OnGetAsync()
    {
        Usuarios = await _context.Usuarios.ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Usuarios.Add(NuevoUsuario);
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }
}
