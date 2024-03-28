using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Controllers {

    public class CustomerController(DataContext db) : Controller {

        private readonly DataContext _dataContext = db;

        public IActionResult Register()
        {
        return View(new Customer());
        }

public IActionResult CustomerList() {
    var customers = _dataContext.Customers.ToList();
    return View(customers); // Pass the list of customers to the view
}


    [HttpPost]
    public IActionResult Register(Customer customer){

        bool companyNameExists = _dataContext.Customers.Any(c => c.CompanyName.ToUpper() == customer.CompanyName.ToUpper());
        if (companyNameExists) 
        {
            ModelState.AddModelError("CompanyName", "Company Name must be unique.");
        }
            if (ModelState.IsValid) {
                _dataContext.AddCustomer(customer);
                _dataContext.SaveChanges();

                //redirect to show all customers after adding one to db
                return RedirectToAction("CustomerList");
            }
            return View(customer);
        }
    }
}