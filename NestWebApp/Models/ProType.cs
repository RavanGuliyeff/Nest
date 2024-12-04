namespace NestWebApp.Models
{
    public class ProType:BaseEntity
    {
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
