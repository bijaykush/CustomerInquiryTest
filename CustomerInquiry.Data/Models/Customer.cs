using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerInquiry.Data.Models
{
    [Table("Customers")]
    public class Customer
    {
        public Customer()
        {
            RecentTransactions = new Collection<Transaction>();
        }

        [Key]
        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "Customer Id should not contain characters")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "Customer Id should not contain characters")]
        public long CustomerId { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string CustomerName { get; set; }

        [Column(TypeName = "varchar(25)")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string ContactEmail { get; set; }

        [Range(0, Int64.MaxValue, ErrorMessage = "Mobile number should not contain characters")]
        [StringLength(10, ErrorMessage = "Mobile number should have 10 digits")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        public ICollection<Transaction> RecentTransactions { get; set; }
    }
}
