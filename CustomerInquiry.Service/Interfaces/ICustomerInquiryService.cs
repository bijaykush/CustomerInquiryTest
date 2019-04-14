using CustomerInquiry.Service.DTO;
using System.Threading.Tasks;

namespace CustomerInquiry.Service.Interfaces
{
    public interface ICustomerInquiryService
    {
        Task<CustomerProfileDTO> GetCustomerProfile(CustomerInquiryFilterDTO customerInquiry);
    }
}
