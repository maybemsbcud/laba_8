using System;
using System.Collections.Generic;
using System.Linq;
using laba8.Core.Domain.Models;
using laba8.Core.Domain.Enums;
using laba8.Core.Interfaces;

namespace laba8.Core.Application
{
    public class SearchService
    {
        private readonly IClientRepository _clientRepo;
        private readonly IPropertyRepository _propertyRepo;

        public SearchService(IClientRepository clientRepo, IPropertyRepository propertyRepo)
        {
            _clientRepo = clientRepo;
            _propertyRepo = propertyRepo;
        }

        public IEnumerable<Client> SearchClients(string keyword)
        {
            return _clientRepo.GetAll().Where(c => 
                c.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) || 
                c.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                c.BankAccountNumber.Contains(keyword));
        }

        public IEnumerable<RealEstateProperty> SearchProperties(string keyword)
        {
            return _propertyRepo.GetAll().Where(p => 
                p.Address.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        // Глобальний пошук по всіх даних
        public IEnumerable<object> GlobalSearch(string keyword)
        {
            var matchedClients = SearchClients(keyword).Cast<object>();
            var matchedProperties = SearchProperties(keyword).Cast<object>();
            
            return matchedClients.Concat(matchedProperties);
        }

        // Розширений пошук клієнта (за прізвищем та бажаним типом нерухомості)
        public IEnumerable<Client> AdvancedSearch(string lastName, PropertyType type)
        {
            return _clientRepo.GetAll().Where(c => 
                c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase) && 
                c.DesiredPropertyType == type);
        }
    }
}