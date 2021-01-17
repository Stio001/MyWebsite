using Microsoft.EntityFrameworkCore;
using MyWebsite.Domain.Entities;
using MyWebsite.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Domain.Repositories.EntityFramework
{
    public class EFOrdersRepository : IOrdersRepository
    {
        private readonly AppDbContext context;
        public EFOrdersRepository(AppDbContext context)
        {
            this.context = context;
        }

        void IOrdersRepository.DeleteOrder(Guid id)
        {
            context.Orders.Remove(new Order() { Id = id });
        }

        Order IOrdersRepository.GetOrderById(Guid id)
        {
            return context.Orders.FirstOrDefault(or => or.Id == id);
        }

        IQueryable<Order> IOrdersRepository.GetOrders()
        {
            return context.Orders;
        }

        void IOrdersRepository.SaveOrder(Order entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
