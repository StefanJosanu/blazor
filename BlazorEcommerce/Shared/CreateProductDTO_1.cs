using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorEcommerce.Shared;

public class ProductDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    [Column(TypeName = "decimal(18, 6)")]
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public Guid StockLocationId { get; set; } 
}
