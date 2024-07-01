using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcommerce.Server.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid StockLocationId { get; set; }
        public Location StockLocation { get; set; }
    }
}
