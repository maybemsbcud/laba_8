using System;
using System.Collections.Generic;
using laba8.Core.Domain.Models;

namespace laba8.Core.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll();
        Client GetById(Guid id);
        void Add(Client client);
        void Update(Client client);
        bool Delete(Guid id);
    }
}