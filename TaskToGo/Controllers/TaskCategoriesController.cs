using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TaskToGo.Context;
using TaskToGo.Models;

namespace TaskToGo.Controllers
{
    public class TaskCategoriesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TaskCategoriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /TaskCategories/Categories
        public async Task<IActionResult> Categories()
        {
            var categories = await _db.TaskCategories
                                           .OrderBy(c => c.Name)
                                           .ToListAsync();
            return View(categories);
        }
    }
}
