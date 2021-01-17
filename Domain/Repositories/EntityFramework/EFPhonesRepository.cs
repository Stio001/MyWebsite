using Microsoft.EntityFrameworkCore;
using MyWebsite.Domain.Entities;
using MyWebsite.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Domain.Repositories.EntityFramework
{
    public class EFPhonesRepository : IPhonesRepository
    {
        private readonly AppDbContext context;
        public EFPhonesRepository(AppDbContext context)
        {
            this.context = context;
        }

        void IPhonesRepository.DeletePhone(Guid id)
        {
            context.Phones.Remove(new Phone() { Id = id });
            context.SaveChanges();
        }

        Phone IPhonesRepository.GetPhoneById(Guid id)
        {
            return context.Phones.FirstOrDefault(ph => ph.Id == id);
        }

        IQueryable<Phone> IPhonesRepository.GetPhones()
        {
            return context.Phones;
        }

        void IPhonesRepository.SavePhone(Phone entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
