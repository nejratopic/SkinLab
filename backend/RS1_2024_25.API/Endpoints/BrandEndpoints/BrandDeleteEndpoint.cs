namespace RS1_2024_25.API.Endpoints.BrandEndpoints;

using global::RS1_2024_25.API.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using System.Threading;
using System.Threading.Tasks;

[Route("brands")]
public class ProductDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var Brand = await db.Brands.SingleOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (Brand == null)
            throw new KeyNotFoundException("Brand not found");

        db.Brands.Remove(Brand);
        await db.SaveChangesAsync(cancellationToken);
    }
}

