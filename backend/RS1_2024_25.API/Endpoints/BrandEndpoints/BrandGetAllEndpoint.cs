using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.BrandEndpoints.BrandGetAllEndpoint;

namespace RS1_2024_25.API.Endpoints.BrandEndpoints;
[Route("brands")]

public class BrandGetAllEndpoint
(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<BrandGetAllResponse[]>
{
    [HttpGet("all")]
    public override async Task<BrandGetAllResponse[]> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await db.Brands
                        .Select(c => new BrandGetAllResponse
                        {
                            ID = c.ID,
                            Name = c.Name,
                            Description = c.Description,
                            CreatedAt = c.CreatedAt,
                            UpdatedAt = c.UpdatedAt
                        })
                        .ToArrayAsync(cancellationToken);

        return result;
    }

    public class BrandGetAllResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }

    }
}



