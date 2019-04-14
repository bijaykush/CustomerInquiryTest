using System.Collections.Generic;

namespace CustomerInquiry.Data.Models
{
    public class CustomerProfile
    {
        public CustomerProfile()
        {
            RecentTransactions = new List<Transaction>();
        }
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public List<Transaction> RecentTransactions { get; set; }
    }
}
