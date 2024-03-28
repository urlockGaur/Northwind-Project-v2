using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Northwind.Controllers
{
    public class DiscountController(DataContext db) : Controller 
    {
        // this controller depends on the DataContext
  private readonly DataContext _dataContext = db;

    public IActionResult Discount()
    {
        var currentDiscounts = _dataContext.Discounts.Include(d => d.Product).Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now).ToList();
        return View(currentDiscounts);
    }


    }
}