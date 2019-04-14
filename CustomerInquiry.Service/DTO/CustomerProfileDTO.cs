using System.Collections.Generic;

namespace CustomerInquiry.Service.DTO
{
    public class CustomerProfileDTO
    {
        public CustomerProfileDTO()
        {
            RecentTransactions = new List<TransactionDTO>();
        }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public List<TransactionDTO> RecentTransactions { get; set; }
    }
}
