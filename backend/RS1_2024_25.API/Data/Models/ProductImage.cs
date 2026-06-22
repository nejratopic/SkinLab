using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using RS1_2024_25.API.Helper;

namespace RS1_2024_25.API.Data.Models
{
    public class ProductImage : IMyBaseEntity
    {
        [Key]
        public int ID { get; set; } 
        public string ImageUrl { get; set; } 
        public bool IsMainImage { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
