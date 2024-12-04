namespace NestWebApp.Areas.Manage.ViewModels.Product
{
    public record UpdateProductVm
    {
        public int Id { get; set; }
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

        public List<ProductImagesVm>? ProductImagesVms { get; set; }
        public List<string> ImageUrls { get; set; }
    }

    public record ProductImagesVm
    {
        public string ImgUrl { get; set; }
        public IFormFile Image { get; set; }
        public bool Primary { get; set; }
    }
}
