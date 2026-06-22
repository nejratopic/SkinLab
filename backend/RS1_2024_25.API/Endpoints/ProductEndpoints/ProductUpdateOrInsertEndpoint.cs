using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RS1_2024_25.API.Endpoints.ProductEndpoints.ProductUpdateOrInsertEndpoint;

namespace RS1_2024_25.API.Endpoints.ProductEndpoints;
[Route("products")]

public class ProductUpdateOrInsertEndpoint
(ApplicationDbContext db) : MyEndpointBaseAsync
        .WithRequest<ProductUpdateOrInsertRequest>
        .WithActionResult<ProductUpdateOrInsertResponse>
{
    [HttpPost]  // Using POST to support both create and update
    public override async Task<ActionResult<ProductUpdateOrInsertResponse>> HandleAsync([FromBody] ProductUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = (request.ID == null || request.ID == 0);
        Product? Product;

        if (isInsert)
        {

            Product = new Product();
            Product.CreatedAt = DateTime.Now;
            db.Products.Add(Product);
        }
        else
        {

            Product = await db.Products.FindAsync(new object[] { request.ID }, cancellationToken);

            if (Product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
        }

        // Set common properties for both insert and update operations
        Product.Name = request.Name;
        Product.Description = request.Description;
        Product.Price = request.Price;

        Product.CreatedAt = DateTime.Now;   // usually set at creation
        Product.UpdatedAt = DateTime.Now;   // updated automatically

        Product.StockQuantity = request.StockQuantity;
        Product.PackSize = request.PackSize;
        Product.Ingredients = request.Ingredients;
        Product.HowToUse = request.HowToUse;

        Product.SubcategoryId = request.SubcategoryId;
        Product.BrandId = request.BrandId;
        Product.ProductTypeId = request.ProductTypeId;
        Product.SkinTypeId = request.SkinTypeId;



        // Save changes to the database
        await db.SaveChangesAsync(cancellationToken);

        return new ProductUpdateOrInsertResponse
        {
            ID = Product.ID,
            Name = Product.Name,
            Description = Product.Description,
            Price = Product.Price,
            CreatedAt = Product.CreatedAt,
            UpdatedAt = Product.UpdatedAt,
            StockQuantity = Product.StockQuantity,
            PackSize = Product.PackSize,
            Ingredients = Product.Ingredients,
            HowToUse = Product.HowToUse,
            SubcategoryId = Product.SubcategoryId,
            BrandId = Product.BrandId,
            ProductTypeId = Product.ProductTypeId,
            SkinTypeId = Product.SkinTypeId
        };

    }

    public class ProductUpdateOrInsertRequest
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public string PackSize { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string HowToUse { get; set; }

        [Required]
        public int SubcategoryId { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        [Required]
        public int SkinTypeId { get; set; }
    }

    public class ProductUpdateOrInsertResponse
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

        public int SubcategoryId { get; set; }
        public int BrandId { get; set; }
        public int ProductTypeId { get; set; }
        public int SkinTypeId { get; set; }
    }
}
