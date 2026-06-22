using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.CategoryEndpoints.CategoryGetByIdEndpoint;

namespace RS1_2024_25.API.Endpoints.CategoryEndpoints;
[Route("categories")]

public class CategoryGetByIdEndpoint
(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithResult<CategoryGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<CategoryGetByIdResponse> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var category = await db.Categories
                            .Where(c => c.ID == id)
                            .Select(c => new CategoryGetByIdResponse
                            {
                                ID = c.ID,
                                Name = c.Name,
                                Description = c.Description,
                                CreatedAt = c.CreatedAt,
                                UpdatedAt = c.UpdatedAt
                            })
                            .FirstOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (category == null)
            throw new KeyNotFoundException("Category not found");

        return category;
    }

    public class CategoryGetByIdResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }
}
