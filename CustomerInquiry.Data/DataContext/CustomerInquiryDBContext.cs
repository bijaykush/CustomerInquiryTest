using CustomerInquiry.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInquiry.Data.DataContext
{
    public class CustomerInquiryDBContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
        }

        public CustomerInquiryDBContext(DbContextOptions<CustomerInquiryDBContext> options)
            : base(options)
        {

        }

    }
}
