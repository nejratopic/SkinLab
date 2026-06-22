using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using System.ComponentModel.DataAnnotations;
using static RS1_2024_25.API.Endpoints.CategoryEndpoints.CategoryUpdateOrInsertEndpoint;

namespace RS1_2024_25.API.Endpoints.CategoryEndpoints;
[Route("categories")]

public class CategoryUpdateOrInsertEndpoint
(ApplicationDbContext db) : MyEndpointBaseAsync
        .WithRequest<CategoryUpdateOrInsertRequest>
        .WithActionResult<CategoryUpdateOrInsertResponse>
{
    [HttpPost]  // Using POST to support both create and update
    public override async Task<ActionResult<CategoryUpdateOrInsertResponse>> HandleAsync([FromBody] CategoryUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = (request.ID == null || request.ID == 0);
        Category? category;

        if (isInsert)
        {

            category = new Category();
            category.CreatedAt = DateTime.Now;
            db.Categories.Add(category);
        }
        else
        {

            category = await db.Categories.FindAsync(new object[] { request.ID }, cancellationToken);

            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }
        }

        // Set common properties for both insert and update operations
        category.Name = request.Name;
        category.Description = request.Description;

        category.UpdatedAt = DateTime.Now;



        // Save changes to the database
        await db.SaveChangesAsync(cancellationToken);

        return new CategoryUpdateOrInsertResponse
        {
            ID = category.ID,
            Name = category.Name,
            Description = category.Description,
            UpdatedAt = category.UpdatedAt,
            CreatedAt = category.CreatedAt
        };

    }

    public class CategoryUpdateOrInsertRequest
    {
        [Required]
        public int? ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }

    public class CategoryUpdateOrInsertResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }

    }
}


