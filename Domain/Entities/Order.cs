using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Domain.Entities
{
    public class Order : EntityBase
    {
        [Required(ErrorMessage = "Введите ФИО")]
        [Display(Name = "ФИО")]
        public string User { get; set; } // имя фамилия покупателя

        [Required(ErrorMessage = "Введите адрес")]
        [Display(Name = "Адрес")]
        public string Address { get; set; } // адрес покупателя

        [Required(ErrorMessage = "Введите контактный номер телефона")]
        [Display(Name = "Контатный номер телефона")]
        public string ContactPhone { get; set; } // контактный телефон покупателя

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
