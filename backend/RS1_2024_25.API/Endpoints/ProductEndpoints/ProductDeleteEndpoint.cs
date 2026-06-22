namespace RS1_2024_25.API.Endpoints.BrandEndpoints;

using global::RS1_2024_25.API.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using System.Threading;
using System.Threading.Tasks;

[Route("products")]
public class ProductsDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var Product = await db.Products.SingleOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (Product == null)
            throw new KeyNotFoundException("Product not found");

        db.Products.Remove(Product);
        await db.SaveChangesAsync(cancellationToken);
    }
}

