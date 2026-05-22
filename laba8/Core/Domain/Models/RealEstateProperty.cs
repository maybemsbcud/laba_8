using System;
using laba8.Core.Domain.Enums;

namespace laba8.Core.Domain.Models
{
    public class RealEstateProperty
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Address { get; set; }
        public PropertyType Type { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}