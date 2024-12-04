using Microsoft.AspNetCore.Mvc;
using NestWebApp.DAL;

namespace NestWebApp.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliderList = await _db.Sliders.ToListAsync();
            List<Product> products = await _db.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Include(p=> p.Brand)
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .ToListAsync();

            List<IndexProductVm> vms = new List<IndexProductVm>();

            foreach (Product product in products)
            {
                IndexProductVm vm = new IndexProductVm()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Rating = product.Rating,
                    Price = product.Price,
                    CategoryName = product.Category.Name,
                    BrandName = product.Brand.Name,
                    ProductImages = product.ProductImages
                };
                vms.Add(vm);
            }

            HomeVm model = new HomeVm()
            {
                Sliders = sliderList,
                IndexProductVms = vms
            };

            return View(model);
        }
    }
}
