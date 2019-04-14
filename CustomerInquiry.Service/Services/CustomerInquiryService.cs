using CustomerInquiry.Data.Models;
using CustomerInquiry.Data.Repositories;
using CustomerInquiry.Service.DTO;
using CustomerInquiry.Service.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.Service.Services
{
    public class CustomerInquiryService : ICustomerInquiryService
    {
        private readonly ICustomerRepository _customerRepository;


        public CustomerInquiryService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerProfileDTO> GetCustomerProfile(CustomerInquiryFilterDTO customerInquiry)
        {
            try
            {
                CustomerProfileDTO customerProfileDTO = null;

                var customerInquiryFilter = new CustomerInquiryFilter
                {
                    CustomerId = customerInquiry.CustomerId,
                    Email = customerInquiry.Email
                };

                var customerProfile = await _customerRepository.GetCustomersAsync(customerInquiryFilter);

                if (customerProfile == null) return customerProfileDTO;

                customerProfileDTO = new CustomerProfileDTO
                {
                    CustomerId = customerProfile.CustomerId,
                    Name = customerProfile.Name,
                    Email = customerProfile.Email,
                    MobileNumber = customerProfile.Email,
                    RecentTransactions = customerProfile.RecentTransactions.Select(x => new TransactionDTO
                    {
                        TransactionId = x.TransactionId,
                        Amount = x.Amount,
                        Date = x.TransactionDateTime,
                        CurrencyCode = x.CurrencyCode.ToString(),
                        TransactionStatus = x.Status.ToString()
                    }).ToList()
                };

                return customerProfileDTO;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
