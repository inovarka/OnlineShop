using OnlineShop.Services;
using OnlineShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Controllers
{
    public class ShopController : Controller
    {
        CheckoutViewModel model = new CheckoutViewModel();

        ProductsService productService = new ProductsService();

        public ActionResult Checkout()
        {
            var CartProductsCookie = Request.Cookies["CartProducts"];

            if(CartProductsCookie !=null)
            {
                model.CartProductIDs = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();

                model.CartProducts = productService.GetProducts(model.CartProductIDs);
            }

            return View(model);
        }
    }
}