using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using RS1_2024_25.API.Helper;

namespace RS1_2024_25.API.Data.Models
{
    public class Subcategory : IMyBaseEntity
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }  
        public string Description { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category? Category { get; set; } 
    }
}
