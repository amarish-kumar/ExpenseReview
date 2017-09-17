using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReimbursementApp.Data;
using ReimbursementApp.DbContext;

namespace ReimbursementApp.Controllers
{
    public class HomeController : Controller
    {
        private ExpenseReviewDbContext _dbContext;

        public HomeController(ExpenseReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var expenses = _dbContext.Expenses.ToList();
            return View(expenses);
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
