using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskaria.Data;
using Taskaria.Models;

namespace Taskaria.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string tableType)
        {
            List<Taskaria.Models.Task> tasks;

            switch (tableType)
            {
                case "notCompleted":
                    tasks = _context.Tasks.Where(t => !t.IsCompleted).ToList();
                    break;
                case "completed":
                    tasks = _context.Tasks.Where(t => t.IsCompleted).ToList();
                    break;
                default:
                    tasks = _context.Tasks.ToList();
                    tableType = "all"; 
                    break;
            }

            ViewData["CurrentTable"] = tableType; 

            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Taskaria.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(task);
        }

        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Taskaria.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(task).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(task);
        }

        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _context.Tasks.Find(id);
            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var task = _context.Tasks.Find(id);

            return View(task);
        }

        public IActionResult MarkAsCompleted(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task != null && !task.IsCompleted)
            {
                task.MarkAsCompleted();
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
