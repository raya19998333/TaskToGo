using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
            var tasks = _db.todoTasks.ToList();

            return View(tasks);
        }
    }
}
