using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using RS1_2024_25.API.Helper;

namespace RS1_2024_25.API.Data.Models
{
    public class Product : IMyBaseEntity
    {
        [Key]
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

        [ForeignKey(nameof(Subcategory))]
        public int SubcategoryId { get; set; }
        public Subcategory? Subcategory { get; set; }
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        [ForeignKey(nameof(ProductType))]
        public int ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }
        [ForeignKey(nameof(SkinType))]
        public int SkinTypeId { get; set; }
        public SkinType? SkinType { get; set; }

    }
}
