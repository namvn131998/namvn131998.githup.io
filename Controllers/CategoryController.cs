using OnlineShop.Data;
using OnlineShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
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
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        [HttpGet]
        public IActionResult AddNewCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewCategory(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display order can't be the same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult EditCategory(int id) { 
            var category = _db.Categories.Find(id);
            
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display order can't be the same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
