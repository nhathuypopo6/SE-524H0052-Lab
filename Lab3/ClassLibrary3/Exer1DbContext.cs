using System.Data.Entity;

namespace DAL
{
    public class Exer1DbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Student> Students { get; set; }

        public Exer1DbContext() : base("name=MyConn")
        {
        }
    }
}
