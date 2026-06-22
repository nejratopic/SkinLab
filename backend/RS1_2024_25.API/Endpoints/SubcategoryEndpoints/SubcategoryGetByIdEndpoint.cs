using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.SubcategoryEndpoints.SubcategoryGetByIdEndpoint;

namespace RS1_2024_25.API.Endpoints.SubcategoryEndpoints;
[Route("subcategories")]

public class SubcategoryGetByIdEndpoint
(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithResult<SubcategoryGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<SubcategoryGetByIdResponse> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var subcategory = await db.Subcategories
                            .Where(s => s.ID == id)
                            .Select(s => new SubcategoryGetByIdResponse
                            {
                                ID = s.ID,
                                Name = s.Name,
                                CategoryId = s.CategoryId,
                                Description = s.Description,
                                CreatedAt = s.CreatedAt,
                                UpdatedAt = s.UpdatedAt
                            })
                            .FirstOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (subcategory == null)
            throw new KeyNotFoundException("Subcategory not found");

        return subcategory;
    }

    public class SubcategoryGetByIdResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required int CategoryId { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }

}