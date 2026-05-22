using System;
using System.Collections.Generic;
using System.Linq;
using laba8.Core.Domain.Models;
using laba8.Core.Domain.Enums;
using laba8.Core.Interfaces;

namespace laba8.Core.Infrastructure
{
    public class InMemoryClientRepository : IClientRepository
    {
        private readonly List<Client> _clients = new List<Client>();

        public InMemoryClientRepository()
        {
            _clients.Add(new Client { Id = Guid.NewGuid(), FirstName = "Олександр", LastName = "Шевченко", BankAccountNumber = "54321111", DesiredPropertyType = PropertyType.TwoRoom, MaxBudget = 50000 });
            _clients.Add(new Client { Id = Guid.NewGuid(), FirstName = "Марія", LastName = "Коваленко", BankAccountNumber = "41492222", DesiredPropertyType = PropertyType.OneRoom, MaxBudget = 30000 });
        }

        public IEnumerable<Client> GetAll() => _clients;
        
        public Client GetById(Guid id) => _clients.FirstOrDefault(c => c.Id == id);
        
        public void Add(Client client) => _clients.Add(client);
        
        public void Update(Client client)
        {
            var existing = GetById(client.Id);
            if (existing != null)
            {
                existing.FirstName = client.FirstName;
                existing.LastName = client.LastName;
                existing.BankAccountNumber = client.BankAccountNumber;
                existing.DesiredPropertyType = client.DesiredPropertyType;
                existing.MaxBudget = client.MaxBudget;
            }
        }
        
        public bool Delete(Guid id)
        {
            var client = GetById(id);
            if (client != null)
            {
                return _clients.Remove(client);
            }
            return false;
        }
    }
}