using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
           List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display order must not match with the name!");
            }

            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Display order must not match with the name!");
            }

            if (ModelState.IsValid)
            {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
