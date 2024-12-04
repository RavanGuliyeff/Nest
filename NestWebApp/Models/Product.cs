using Microsoft.CodeAnalysis.Options;

namespace NestWebApp.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Rating { get; set; }
        public double Price { get; set; }
        public string SKU { get; set; }
        public string MFG { get; set; }
        public int Stock { get; set; }
        public string Life { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int TypeId { get; set; }
        public ProType? Type { get; set; }

        public List<ProductImage>? ProductImages { get; set; }
        public List<ProductTag>? ProductTags { get; set; }

    }
}
