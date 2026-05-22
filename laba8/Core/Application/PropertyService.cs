using System;
using System.Collections.Generic;
using System.Linq;
using laba8.Core.Domain.Models;
using laba8.Core.Interfaces;

namespace laba8.Core.Application
{
    public class PropertyService
    {
        private readonly IPropertyRepository _repository;

        public PropertyService(IPropertyRepository repository)
        {
            _repository = repository;
        }

        public void AddProperty(RealEstateProperty property) => _repository.Add(property);
        public void UpdateProperty(RealEstateProperty property) => _repository.Update(property);
        public bool RemoveProperty(Guid id) => _repository.Delete(id);
        public RealEstateProperty GetProperty(Guid id) => _repository.GetById(id);
        public IEnumerable<RealEstateProperty> GetAllProperties() => _repository.GetAll();

        // Сортування за вимогами ТЗ
        public IEnumerable<RealEstateProperty> SortPropertiesByType() 
            => _repository.GetAll().OrderBy(p => p.Type);

        public IEnumerable<RealEstateProperty> SortPropertiesByPrice() 
            => _repository.GetAll().OrderBy(p => p.Price);
    }
}