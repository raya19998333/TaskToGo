using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskToGo.Context;
using TaskToGo.Models;

namespace TaskToGo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var tasks = _db.todoTasks.Include(w => w.taskCategory).ToList();
            return View(tasks);
        }

        public IActionResult Details(int id)
        {
            var todo = _db.todoTasks.Include(w => w.taskCategory).FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        public IActionResult Create()
        {
            ViewBag.CategoriesList = new SelectList(_db.TaskCategories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(TodoTask obj)
        {
            if (ModelState.IsValid)
            {
                _db.todoTasks.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("ViewTasks");
            }

            ViewBag.CategoriesList = new SelectList(_db.TaskCategories, "Id", "Name");
            return View(obj);
        }

        public IActionResult Update(int id)
        {
            var todo = _db.todoTasks.Include(w => w.taskCategory).FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();

            ViewBag.CategoriesList = new SelectList(_db.TaskCategories, "Id", "Name");
            return View(todo);
        }

        [HttpPost]
        public IActionResult Update(TodoTask obj)
        {
            if (ModelState.IsValid)
            {
                _db.todoTasks.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("ViewTasks");
            }

            ViewBag.CategoriesList = new SelectList(_db.TaskCategories, "Id", "Name");
            return View(obj);
        }

        public IActionResult ViewTasks()
        {
            var tasks = _db.todoTasks.Include(t => t.taskCategory).ToList();
            return View(tasks); // يعيد ViewTasks.cshtml
        }

        // ✅ حذف المهمة
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _db.todoTasks.Find(id);
            if (task == null) return NotFound();

            _db.todoTasks.Remove(task);
            _db.SaveChanges();

            return RedirectToAction("ViewTasks");
        }
    }
}
