using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Neon.CRM.WebApp.Data.Models;

namespace Neon.CRM.WebApp.Pages.Customers;

public class IndexModel : PageModel
{
    private readonly Neon.CRM.WebApp.Data.ApplicationDbContext _context;

    public IndexModel(Neon.CRM.WebApp.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Customer> Customers { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Customers = await _context.Customers
            .Include(c => c.Agent)
            .ToListAsync();
    }
}
