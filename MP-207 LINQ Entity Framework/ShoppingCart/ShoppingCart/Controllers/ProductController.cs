using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.ViewModel;
using ShoppingCart.Business;
using ShoppingCart.Models;
using ShoppingCart.DataAcess;

namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
    {

        //  GET: Product
        //private readonly IProductBll productBll = new ProductBll(new DbConnection());
        private readonly IProductBll productBll;
        public ProductController(IProductBll productBll)
        {
            this.productBll = productBll;
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductView p) 
        {
            productBll.AddProduct(p);
            return RedirectToAction("ShowProduct");
        }

        public ActionResult ShowProduct()
        {
            IEnumerable<Product> p = productBll.ShowProduct();
            return View(p);
        }

        public ActionResult CustomerOrderProduct()
        {           
            return View(CartSingleton.GetInstance().GetList());
        }
    }
}