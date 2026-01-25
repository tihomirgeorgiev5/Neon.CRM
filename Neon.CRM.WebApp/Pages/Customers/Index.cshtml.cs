using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Neon.CRM.WebApp.Data.Models;

namespace Neon.CRM.WebApp.Pages.Customers;

public class IndexModel(TenantDbContextFactory tenantDbContextFactory) : PageModel
{
 
    public IList<Customer> Customers { get;set; } = default!;

    public async Task OnGetAsync()
    {
        var context = tenantDbContextFactory.Create();
        Customers = await context.Customers
            .Include(c => c.Agent)
            .ToListAsync();
    }
}
