using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerInquiry.Service.DTO
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }

        [DisplayFormat(DataFormatString = "{0: DD/MM/YY HH/MM}")]
        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string TransactionStatus { get; set; }
    }
}
