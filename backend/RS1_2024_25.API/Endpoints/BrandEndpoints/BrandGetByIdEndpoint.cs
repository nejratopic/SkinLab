using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.BrandEndpoints.BrandGetByIdEndpoint;

namespace RS1_2024_25.API.Endpoints.BrandEndpoints;
[Route("brands")]

public class BrandGetByIdEndpoint
(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithResult<BrandGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<BrandGetByIdResponse> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var Brand = await db.Brands
                            .Where(c => c.ID == id)
                            .Select(c => new BrandGetByIdResponse
                            {
                                ID = c.ID,
                                Name = c.Name,
                                Description = c.Description,
                                CreatedAt = c.CreatedAt,
                                UpdatedAt = c.UpdatedAt
                            })
                            .FirstOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (Brand == null)
            throw new KeyNotFoundException("Brand not found");

        return Brand;
    }

    public class BrandGetByIdResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }
}
