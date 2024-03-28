using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options) { }

  public DbSet<Category> Categories { get; set; }
  public DbSet<Product> Products { get; set; }

   public DbSet<Discount> Discounts { get; set; }

   public DbSet<Customer> Customers { get; set; }

   //addCustomer Method 
   public void AddCustomer(Customer customer) {
    Customers.Add(customer);
    SaveChanges();
   }
}