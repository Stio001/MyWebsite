using Microsoft.EntityFrameworkCore;
using MyWebsite.Domain.Entities;
using MyWebsite.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;
        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }

        void ITextFieldsRepository.DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }

        TextField ITextFieldsRepository.GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.FirstOrDefault(tf => tf.CodeWord == codeWord);
        }

        TextField ITextFieldsRepository.GetTextFieldById(Guid id)
        {
            return context.TextFields.FirstOrDefault(tf => tf.Id == id);
        }

        IQueryable<TextField> ITextFieldsRepository.GetTextFields()
        {
            return context.TextFields;
        }

        void ITextFieldsRepository.SaveTextField(TextField entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
