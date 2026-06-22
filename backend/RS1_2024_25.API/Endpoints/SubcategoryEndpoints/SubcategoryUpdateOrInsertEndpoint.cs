using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using System.ComponentModel.DataAnnotations;
using static RS1_2024_25.API.Endpoints.SubcategoryEndpoints.SubcategoryUpdateOrInsertEndpoint;

namespace RS1_2024_25.API.Endpoints.SubcategoryEndpoints;
[Route("subcategories")]

public class SubcategoryUpdateOrInsertEndpoint
(ApplicationDbContext db) : MyEndpointBaseAsync
        .WithRequest<SubcategoryUpdateOrInsertRequest>
        .WithActionResult<SubcategoryUpdateOrInsertResponse>
{
    [HttpPost]  // Using POST to support both create and update
    public override async Task<ActionResult<SubcategoryUpdateOrInsertResponse>> HandleAsync([FromBody] SubcategoryUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = (request.ID == null || request.ID == 0);
        Subcategory? subcategory;

        if (isInsert)
        {

            subcategory = new Subcategory();
            subcategory.CreatedAt = DateTime.Now;
            db.Subcategories.Add(subcategory);
        }
        else
        {

            subcategory = await db.Subcategories.FindAsync(new object[] { request.ID }, cancellationToken);

            if (subcategory == null)
            {
                throw new KeyNotFoundException("Subcategory not found");
            }
        }

        // Set common properties for both insert and update operations
        subcategory.Name = request.Name;
        subcategory.Description = request.Description;
        subcategory.CategoryId = request.CategoryId;

        subcategory.UpdatedAt = DateTime.Now;



        // Save changes to the database
        await db.SaveChangesAsync(cancellationToken);

        return new SubcategoryUpdateOrInsertResponse
        {
            ID = subcategory.ID,
            Name = subcategory.Name,
            Description = subcategory.Description,
            CategoryId = subcategory.CategoryId,
            UpdatedAt = subcategory.UpdatedAt,
            CreatedAt = subcategory.CreatedAt
        };

    }

    public class SubcategoryUpdateOrInsertRequest
    {
        [Required]
        public int? ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public  int CategoryId { get; set; }

    }

    public class SubcategoryUpdateOrInsertResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required int CategoryId { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }

    }
}



