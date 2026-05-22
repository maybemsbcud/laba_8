using System;
using System.Collections.Generic;
using System.Linq;
using laba8.Core.Domain.Models;
using laba8.Core.Domain.Enums;
using laba8.Core.Interfaces;

namespace laba8.Core.Infrastructure
{
    public class InMemoryPropertyRepository : IPropertyRepository
    {
        private readonly List<RealEstateProperty> _properties = new List<RealEstateProperty>();

        public InMemoryPropertyRepository()
        {
            _properties.Add(new RealEstateProperty { Id = Guid.NewGuid(), Address = "Центр, вул. ім. Микити Олександровича Куценка", Type = PropertyType.ThreeRoom, Price = 120000, IsAvailable = true });
            _properties.Add(new RealEstateProperty { Id = Guid.NewGuid(), Address = "Спальний район, вул. Миру 45", Type = PropertyType.OneRoom, Price = 25000, IsAvailable = true });
            _properties.Add(new RealEstateProperty { Id = Guid.NewGuid(), Address = "Передмістя, вул. Зрадомоги", Type = PropertyType.PrivatePlot, Price = 15000, IsAvailable = true });
        }

        public IEnumerable<RealEstateProperty> GetAll() => _properties;
        
        public RealEstateProperty GetById(Guid id) => _properties.FirstOrDefault(p => p.Id == id);
        
        public void Add(RealEstateProperty property) => _properties.Add(property);
        
        public void Update(RealEstateProperty property)
        {
            var existing = GetById(property.Id);
            if (existing != null)
            {
                existing.Address = property.Address;
                existing.Type = property.Type;
                existing.Price = property.Price;
                existing.IsAvailable = property.IsAvailable;
            }
        }
        
        public bool Delete(Guid id)
        {
            var property = GetById(id);
            if (property != null)
            {
                return _properties.Remove(property);
            }
            return false;
        }
    }
}