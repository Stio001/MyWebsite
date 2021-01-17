using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Domain.Entities
{
    public class Phone : EntityBase
    {
        [Required(ErrorMessage = "Введите название модели")]
        [Display(Name = "Модель")]
        public override string Title { get; set; }

        [Required(ErrorMessage = "Введите название компании производителя")]
        [Display(Name = "Компания производитель")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Введите цену")]
        [Display(Name = "Цена")]
        public int Price { get; set; }
    }
}
