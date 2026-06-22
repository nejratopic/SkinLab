namespace RS1_2024_25.API.Endpoints.SubcategoryEndpoints;

using global::RS1_2024_25.API.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using System.Threading;
using System.Threading.Tasks;

[Route("subcategories")]
public class SubcategoryDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var subcategory = await db.Subcategories.SingleOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (subcategory == null)
            throw new KeyNotFoundException("Subcategory not found");

        db.Subcategories.Remove(subcategory);
        await db.SaveChangesAsync(cancellationToken);
    }
}


