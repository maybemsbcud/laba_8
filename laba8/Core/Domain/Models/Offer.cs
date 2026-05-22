using System;
using System.Collections.Generic;

namespace laba8.Core.Domain.Models
{
    public class Offer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Client TargetClient { get; set; }
        public List<RealEstateProperty> Properties { get; private set; } = new List<RealEstateProperty>();

        // n < 5 означає максимум 4 об'єкти
        public bool AddProperty(RealEstateProperty property)
        {
            if (Properties.Count < 4 && property.IsAvailable)
            {
                Properties.Add(property);
                return true;
            }
            return false;
        }

        // Клієнт відхиляє пропозицію
        public void RejectProperty(RealEstateProperty property)
        {
            Properties.Remove(property);
        }
    }
}