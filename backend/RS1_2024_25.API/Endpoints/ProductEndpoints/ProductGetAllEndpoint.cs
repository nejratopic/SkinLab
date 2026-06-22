using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;
using System.ComponentModel.DataAnnotations.Schema;
using static RS1_2024_25.API.Endpoints.ProductEndpoints.ProductGetAllEndpoint;

namespace RS1_2024_25.API.Endpoints.ProductEndpoints;
[Route("products")]

public class ProductGetAllEndpoint
(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<ProductGetAllResponse[]>
{
    [HttpGet("all")]
    public override async Task<ProductGetAllResponse[]> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await db.Products
                        .Select(c => new ProductGetAllResponse
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

    public class ProductGetAllResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int StockQuantity { get; set; }
        public string PackSize { get; set; }
        public string Ingredients { get; set; }
        public string HowToUse { get; set; }
        public Subcategory? Subcategory { get; set; }
        public Brand? Brand { get; set; }
        public ProductType? ProductType { get; set; }
        public SkinType? SkinType { get; set; }
    }
}



