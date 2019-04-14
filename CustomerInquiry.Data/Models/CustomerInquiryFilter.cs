using System.ComponentModel.DataAnnotations;

namespace CustomerInquiry.Data.Models
{
    public class CustomerInquiryFilter
    {
        public int? CustomerId { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }
}
