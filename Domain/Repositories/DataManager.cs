using MyWebsite.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Domain.Repositories
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IPhonesRepository Phones { get; set; }
        public IOrdersRepository Orders { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, 
            IPhonesRepository phonesRepository, 
            IOrdersRepository ordersRepository)
        {
            TextFields = textFieldsRepository;
            Phones = phonesRepository;
            Orders = ordersRepository;
        }
    }
}
