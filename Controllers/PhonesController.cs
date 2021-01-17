using Microsoft.AspNetCore.Mvc;
using MyWebsite.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Controllers
{
    public class PhonesController : Controller
    {
        public DataManager dataManager;

        public PhonesController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.Phones.GetPhoneById(id));
            }

            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PagePhones");
            return View(dataManager.Phones.GetPhones());
        }
    }
}
