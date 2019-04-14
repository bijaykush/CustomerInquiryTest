using System.ComponentModel.DataAnnotations;

namespace CustomerInquiry.Service.DTO
{
    public class CustomerInquiryFilterDTO
    {
        public int? CustomerId { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }
}
