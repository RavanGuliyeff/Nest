namespace NestWebApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BrandController : Controller
    {
        AppDbContext _db;

        public BrandController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Brand> model = await _db.Brands.Include(x => x.Products).ToListAsync();
            return View(model);

        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandVm vm)
        {
            if (vm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }


            Brand brand = new Brand()
            {
                Name = vm.Name
            };

            await _db.Brands.AddAsync(brand);
            await _db.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || !(_db.Brands.Any(t => t.Id == id)))
            {
                return BadRequest();
            }

            Brand brand = await _db.Brands.FirstOrDefaultAsync(t => t.Id == id);

            UpdateBrandVm vm = new UpdateBrandVm()
            {
                Id = brand.Id,
                Name = brand.Name
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandVm vm)
        {
            if (vm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Brand oldBrand = await _db.Brands.FirstOrDefaultAsync(c => c.Id == vm.Id);

            Brand brand = new Brand()
            {
                Name = vm.Name
            };

            oldBrand.Name = vm.Name;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null || !(_db.Types.Any(t => t.Id == id)))
            {
                return BadRequest();
            }

            Brand brand = _db.Brands.FirstOrDefault(t => t.Id == id);

            _db.Brands.Remove(brand);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
