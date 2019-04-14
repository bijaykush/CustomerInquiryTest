using CustomerInquiry.Data.Models;
using System;
using System.Threading.Tasks;

namespace CustomerInquiry.Data.Repositories
{
    public interface ICustomerRepository: IDisposable
    {
        Task<CustomerProfile> GetCustomersAsync(CustomerInquiryFilter customerInquiry);
    }
}
