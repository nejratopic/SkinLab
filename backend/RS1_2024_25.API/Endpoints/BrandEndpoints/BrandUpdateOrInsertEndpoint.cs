using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;
using System.ComponentModel.DataAnnotations;
using static RS1_2024_25.API.Endpoints.BrandEndpoints.BrandUpdateOrInsertEndpoint;

namespace RS1_2024_25.API.Endpoints.BrandEndpoints;
[Route("brands")]

public class BrandUpdateOrInsertEndpoint
(ApplicationDbContext db) : MyEndpointBaseAsync
        .WithRequest<BrandUpdateOrInsertRequest>
        .WithActionResult<BrandUpdateOrInsertResponse>
{
    [HttpPost]  // Using POST to support both create and update
    public override async Task<ActionResult<BrandUpdateOrInsertResponse>> HandleAsync([FromBody] BrandUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = (request.ID == null || request.ID == 0);
        Brand? Brand;

        if (isInsert)
        {

            Brand = new Brand();
            Brand.CreatedAt = DateTime.Now;
            db.Brands.Add(Brand);
        }
        else
        {

            Brand = await db.Brands.FindAsync(new object[] { request.ID }, cancellationToken);

            if (Brand == null)
            {
                throw new KeyNotFoundException("Brand not found");
            }
        }

        // Set common properties for both insert and update operations
        Brand.Name = request.Name;
        Brand.Description = request.Description;

        Brand.UpdatedAt = DateTime.Now;



        // Save changes to the database
        await db.SaveChangesAsync(cancellationToken);

        return new BrandUpdateOrInsertResponse
        {
            ID = Brand.ID,
            Name = Brand.Name,
            Description = Brand.Description,
            UpdatedAt = Brand.UpdatedAt,
            CreatedAt = Brand.CreatedAt
        };

    }

    public class BrandUpdateOrInsertRequest
    {
        [Required]
        public int? ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }

    public class BrandUpdateOrInsertResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }

    }
}


