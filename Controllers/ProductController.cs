using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Northwind.Controllers
{
    public class ProductController(DataContext db) : Controller
    {
         // this controller depends on the DataContext
  private readonly DataContext _dataContext = db;

  public IActionResult Category() {
    var sortedCategories = _dataContext.Categories.OrderBy(c => c.CategoryName).ToList();
    return View(sortedCategories);
  }

  public IActionResult Product(int CategoryId) {
    var products = _dataContext.Products.Where(p => p.CategoryId == CategoryId && !p.Discontinued).ToList();
    return View(products);
  }

  
    }

    
}