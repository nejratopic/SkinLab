using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;
using System.ComponentModel.DataAnnotations.Schema;
using static RS1_2024_25.API.Endpoints.ProductEndpoints.ProductGetByIdEndpoint;

namespace RS1_2024_25.API.Endpoints.ProductEndpoints;
[Route("products")]

public class ProductGetByIdEndpoint
(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithResult<ProductGetByIdResponse>
{
    [HttpGet("{id}")]
    public override async Task<ProductGetByIdResponse> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var Product = await db.Products
                            .Where(c => c.ID == id)
                            .Select(c => new ProductGetByIdResponse
                            {
                                ID = c.ID,
                                Name = c.Name,
                                Description = c.Description,
                                Price = c.Price,
                                CreatedAt = c.CreatedAt,
                                UpdatedAt = c.UpdatedAt,
                                StockQuantity = c.StockQuantity,
                                PackSize = c.PackSize,
                                Ingredients = c.Ingredients,
                                HowToUse = c.HowToUse,
                                Subcategory = c.Subcategory,
                                Brand = c.Brand,
                                ProductType = c.ProductType,
                                SkinType = c.SkinType
                            })
                            .FirstOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (Product == null)
            throw new KeyNotFoundException("Product not found");

        return Product;
    }

    public class ProductGetByIdResponse
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
