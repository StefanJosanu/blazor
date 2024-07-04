using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class CreateProductDTO
    { 
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid StockLocationId { get; set; }
    }
}
