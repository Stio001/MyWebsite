using MyWebsite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Domain.Repositories.Abstract
{
    public interface IPhonesRepository
    {
        IQueryable<Phone> GetPhones();
        Phone GetPhoneById(Guid id);
        void SavePhone(Phone entity);
        void DeletePhone(Guid id);
    }
}
