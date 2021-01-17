using Microsoft.AspNetCore.Mvc;
using MyWebsite.Domain.Entities;
using MyWebsite.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly DataManager dataManager;

        public PurchaseController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Buy(Guid id)
        {
            ViewBag.Phone = dataManager.Phones.GetPhoneById(id);
            return View(new Order());
        }
        [HttpPost]
        public string Buy(Order order)
        {
            dataManager.Orders.SaveOrder(order);
            return "Спасибо, " + order.User + ", за покупку!";
        }
    }
}
