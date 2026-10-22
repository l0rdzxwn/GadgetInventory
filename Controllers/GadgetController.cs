using GadgetInventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace GadgetInventory.Controllers
{
    public class GadgetController : Controller
    {
        public static List<Gadget> _gadget = new List<Gadget>
        {
            new Gadget {Id = 1, Brand = "Apple", ModelName = "iPhone 15", Price = 799.00m},
            new Gadget {Id = 2, Brand = "Samsung", ModelName = "Galaxy S24", Price = 849.00m}
        };

        public IActionResult Index()
        {
            return View(_gadget);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Gadget gadget)
        {
            if (!ModelState.IsValid)
            {
                return View(gadget);
            }

            gadget.Id = _gadget.Count + 1;
            _gadget.Add(gadget);

            return RedirectToAction("Index");
        }
    }
}
