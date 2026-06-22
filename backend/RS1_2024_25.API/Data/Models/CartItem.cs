using RS1_2024_25.API.Data.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RS1_2024_25.API.Data.Models
{
    public class CartItem
    {
        [Key]
        public int ID { get; set; }
        public int Quantity { get; set; } 

        [ForeignKey(nameof(Cart))]
        public int CartId { get; set; }
        public Cart? Cart { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
