using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using System;
using static RS1_2024_25.API.Endpoints.CategoryEndpoints.CategoryGetAllEndpoint;

namespace RS1_2024_25.API.Endpoints.CategoryEndpoints;
[Route("categories")]

public class CategoryGetAllEndpoint
(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<CategoryGetAllResponse[]>
{
    [HttpGet("all")]
    public override async Task<CategoryGetAllResponse[]> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await db.Categories
                        .Select(c => new CategoryGetAllResponse
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

    public class CategoryGetAllResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }

    }
}



