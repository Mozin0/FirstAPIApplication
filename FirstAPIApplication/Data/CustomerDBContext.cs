using ClassModels;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIApplication.Data
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options)
        {

        }
        
        public DbSet<Customer> Customers { get; set; }
    }
}
