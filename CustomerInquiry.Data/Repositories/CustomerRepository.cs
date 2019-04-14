using System;
using System.Linq;
using System.Threading.Tasks;
using CustomerInquiry.Data.DataContext;
using CustomerInquiry.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInquiry.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private readonly CustomerInquiryDBContext _customerInquiryDBContext;
        public CustomerRepository(CustomerInquiryDBContext customerInquiryDBContext)
        {
            _customerInquiryDBContext = customerInquiryDBContext;
        }


        public async Task<CustomerProfile> GetCustomersAsync(CustomerInquiryFilter customerInquiryFilter)
        {
            var query = (from c in _customerInquiryDBContext.Customers.Include("Transactions")
                        select new CustomerProfile
                        {
                            CustomerId = c.CustomerId,
                            Name = c.CustomerName,
                            Email = c.ContactEmail,
                            MobileNumber = c.MobileNumber,
                            RecentTransactions = c.RecentTransactions.OrderByDescending(x => x.TransactionDateTime).Take(5).ToList()
                        });

            if (string.IsNullOrEmpty(customerInquiryFilter.Email))
            {
                query = query.Where(x => x.CustomerId == customerInquiryFilter.CustomerId);
            }
            else if (customerInquiryFilter.CustomerId == null)
            {
                query = query.Where(x => x.Email == customerInquiryFilter.Email);
            }
            else
            {
                query = query.Where(x => x.CustomerId == customerInquiryFilter.CustomerId && x.Email == customerInquiryFilter.Email);
            }

            return await query.FirstOrDefaultAsync();

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _customerInquiryDBContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
