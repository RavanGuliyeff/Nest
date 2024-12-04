
namespace NestWebApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TypeController : Controller
    {
		AppDbContext _db;

		public TypeController(AppDbContext db)
		{
			_db = db;
		}

		public async Task<IActionResult> Index()
		{
			List<ProType> types = await _db.Types.Include(x => x.Products).ToListAsync();
			return View(types);

		}

		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateTypeVm vm)
		{
			if (vm == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return View(vm);
			}


			ProType type = new ProType()
			{
				Name = vm.Name
			};

			await _db.Types.AddAsync(type);
			await _db.SaveChangesAsync();


			return RedirectToAction(nameof(Index));
		}



		public async Task<IActionResult> Update(int? id)
		{
			if (id == null || !(_db.Types.Any(t => t.Id == id)))
			{
				return BadRequest();
			}

			ProType type = await _db.Types.FirstOrDefaultAsync(t => t.Id == id);

			UpdateTypeVm vm = new UpdateTypeVm()
			{
				Id = type.Id,
				Name = type.Name
			};

			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateTypeVm vm)
		{
			if (vm == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return View(vm);
			}

			ProType oldType = await _db.Types.FirstOrDefaultAsync(c => c.Id == vm.Id);

			ProType type = new ProType()
			{
				Name = vm.Name
			};

			oldType.Name = vm.Name;

			await _db.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}


		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null || !(_db.Types.Any(t => t.Id == id)))
			{
				return BadRequest();
			}

			ProType type = _db.Types.FirstOrDefault(t => t.Id == id);

			_db.Types.Remove(type);
			await _db.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}
	}
}
