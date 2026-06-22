using RS1_2024_25.API.Data.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RS1_2024_25.API.Helper;

namespace RS1_2024_25.API.Data.Models
{
    public class Wishlist : IMyBaseEntity
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Products))]
        public int ProductsId { get; set; }
        public Product? Products { get; set; }
        [ForeignKey(nameof(MyAppUser))]
        public int MyAppUserId { get; set; }
        public MyAppUser? MyAppUser { get; set; }
        public DateTime CreatedAt { get; set; }  

    }
}
