using System;
using laba8.Core.Domain.Enums;

namespace laba8.Core.Domain.Models
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BankAccountNumber { get; set; }
        
        public PropertyType DesiredPropertyType { get; set; }
        public decimal MaxBudget { get; set; }
    }
}