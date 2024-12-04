namespace NestWebApp.Areas.Manage.ViewModels.Slider
{
    public record CreateSliderVm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
