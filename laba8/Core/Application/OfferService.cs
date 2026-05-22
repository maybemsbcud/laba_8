using System.Collections.Generic;
using System.Linq;
using laba8.Core.Domain.Models;
using laba8.Core.Interfaces;

namespace laba8.Core.Application
{
    public class OfferService
    {
        private readonly IPropertyRepository _propertyRepository;

        public OfferService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        // Пошук нерухомості під конкретного клієнта
        public IEnumerable<RealEstateProperty> FindMatchingAvailableProperties(Client client)
        {
            return _propertyRepository.GetAll().Where(p => 
                p.IsAvailable && 
                p.Type == client.DesiredPropertyType && 
                p.Price <= client.MaxBudget);
        }
    }
}