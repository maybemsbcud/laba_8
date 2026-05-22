using System;
using System.Collections.Generic;
using System.Linq;
using laba8.Core.Domain.Models;
using laba8.Core.Interfaces;

namespace laba8.Core.Application
{
    public class ClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        // Базові CRUD операції
        public void AddClient(Client client) => _repository.Add(client);
        public void UpdateClient(Client client) => _repository.Update(client);
        public bool RemoveClient(Guid id) => _repository.Delete(id);
        public Client GetClient(Guid id) => _repository.GetById(id);
        public IEnumerable<Client> GetAllClients() => _repository.GetAll();

        // Сортування за вимогами ТЗ
        public IEnumerable<Client> SortClientsByName() 
            => _repository.GetAll().OrderBy(c => c.FirstName);

        public IEnumerable<Client> SortClientsBySurname() 
            => _repository.GetAll().OrderBy(c => c.LastName);

        public IEnumerable<Client> SortClientsByBankAccStart() 
            => _repository.GetAll().OrderBy(c => c.BankAccountNumber.FirstOrDefault());
    }
}