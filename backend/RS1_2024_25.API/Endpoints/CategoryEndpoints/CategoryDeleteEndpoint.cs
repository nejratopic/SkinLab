namespace RS1_2024_25.API.Endpoints.CategoryEndpoints;

using global::RS1_2024_25.API.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using System.Threading;
using System.Threading.Tasks;

[Route("categories")]
public class CategoryDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var category = await db.Categories.SingleOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (category == null)
            throw new KeyNotFoundException("Category not found");

        db.Categories.Remove(category);
        await db.SaveChangesAsync(cancellationToken);
    }
}

