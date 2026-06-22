using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helper;

namespace RS1_2024_25.API.Data.Models
{
    public class Review : IMyBaseEntity
    {
        [Key]
        public int ID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        [ForeignKey(nameof(MyAppUser))]
        public int MyAppUserId { get; set; }
        public MyAppUser? MyAppUser { get; set; }
    }
}
