using CustomerInquiry.Common.Enums;
using CustomerInquiry.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerInquiry.Data.DataContext
{
    public static class DbInitializer
    {
        public static void SeedDatabase(CustomerInquiryDBContext context)
        {
            Console.WriteLine("Seeding... - Start");

            var customers = new List<Customer>
            {
                new Customer {CustomerId = 123456, CustomerName = "Bijay Kushawaha", ContactEmail = "bijaykush2012@gmail.com", MobileNumber = "9849881591"},
                new Customer {CustomerId = 1234567890, CustomerName = "Ajay Kushawaha", ContactEmail = "ajaykush2012@gmail.com", MobileNumber = "9849881591"},
            };

            var transactions = new List<Transaction>
            {
                new Transaction { Customer = customers[0], Amount = 300, Status = TransactionStatus.Success, CurrencyCode = CurrencyCode.USD, TransactionDateTime = DateTime.UtcNow },
                new Transaction { Customer = customers[0], Amount = 500, Status = TransactionStatus.Failed, CurrencyCode = CurrencyCode.JPY, TransactionDateTime = DateTime.UtcNow }
            };

            if (!context.Customers.Any() && !context.Transactions.Any())
            {
                context.Customers.AddRange(customers);
                context.Transactions.AddRange(transactions);
                context.SaveChanges();
            }

            Console.WriteLine("Seeding... - End");
        }
    }
}
