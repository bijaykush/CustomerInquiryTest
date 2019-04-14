using CustomerInquiry.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerInquiry.Data.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        [Range(0, Int64.MaxValue, ErrorMessage = "Customer Id should not contain characters")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [DataType(DataType.DateTime)]
        
        public DateTime TransactionDateTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal Amount { get; set; }

        public CurrencyCode CurrencyCode { get; set; }

        public TransactionStatus Status { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

    }
}
