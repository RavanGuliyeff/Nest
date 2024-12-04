namespace NestWebApp.Areas.Manage.ViewModels.Product
{
    public record CreateProductVm
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public byte Rating { get; set; }
        public string SKU { get; set; }
        public byte MFGMonth { get; set; }
        public ushort MFGYear { get; set; }
        public int Stock { get; set; }
        public string Life { get; set; }
        public double Price { get; set; }
        public int BrandId { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public IFormFile? MainPhoto { get; set; }
        public List<IFormFile>? Images { get; set; }
        public List<int> TagIds { get; set; }
       
    }
}
