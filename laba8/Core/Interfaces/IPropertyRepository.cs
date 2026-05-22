using System;
using System.Collections.Generic;
using laba8.Core.Domain.Models;

namespace laba8.Core.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<RealEstateProperty> GetAll();
        RealEstateProperty GetById(Guid id);
        void Add(RealEstateProperty property);
        void Update(RealEstateProperty property);
        bool Delete(Guid id);
    }
}