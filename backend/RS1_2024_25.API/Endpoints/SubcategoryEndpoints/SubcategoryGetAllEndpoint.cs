using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using System;
using static RS1_2024_25.API.Endpoints.SubcategoryEndpoints.SubcategoryGetAllEndpoint;

namespace RS1_2024_25.API.Endpoints.SubcategoryEndpoints;
[Route("subcategories")]

public class SubcategoryGetAllEndpoint
(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<SubcategoryGetAllResponse[]>
{
    [HttpGet("all")]
    public override async Task<SubcategoryGetAllResponse[]> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await db.Subcategories
                        .Select(s => new SubcategoryGetAllResponse
                        {
                            ID = s.ID,
                            Name = s.Name,
                            CategoryName = s.Category!.Name,
                            Description = s.Description,
                            CreatedAt = s.CreatedAt,
                            UpdatedAt = s.UpdatedAt
                        })
                        .ToArrayAsync(cancellationToken);

        return result;
    }

    public class SubcategoryGetAllResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required string CategoryName { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }

    }
}



