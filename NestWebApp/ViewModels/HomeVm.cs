namespace NestWebApp.ViewModels
{
    public record HomeVm
    {
        public List<Slider> Sliders { get; set; }
        public List<IndexProductVm> IndexProductVms { get; set; }
    }

    public record IndexProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public byte Rating { get; set; }
        public string BrandName { get; set; }
        public double Price { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
