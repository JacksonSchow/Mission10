using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

// Controller for the orders--we wanted to use a different controller because this is dealing with a different table and different data in the database

namespace Bookstore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repo { get; set; }
        private Cart cart { get; set; }

        public OrderController (IOrderRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Order()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Order(Order order)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.Items.ToArray();
                repo.SaveOrder(order);
                cart.ClearCart();

                return RedirectToPage("/Confirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
