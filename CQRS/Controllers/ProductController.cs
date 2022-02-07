
using CQRS.BLL.Interfaces.Product;
using CQRS.BLL.Models.Product.CUDHandellerModel;
using CQRS.BLL.Models.Product.QueryHandellerModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Controllers
{
    public class ProductController : Controller
    {
        private IProductHandeller productHandeller;
        private IProductQueryHandeller productQueryHandeller;
        public ProductController(IProductHandeller _productHandeller, IProductQueryHandeller _productQueryHandeller)
        {
            productHandeller = _productHandeller;
            productQueryHandeller = _productQueryHandeller;
        }
        public IActionResult Index()
        {
            var productlist=productQueryHandeller.GetAllProducts();
            return View(productlist);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductHandellerModel vmodel)
        {
            productHandeller.SaveProduct(vmodel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditProduct(int ID)
        {
            var product = productHandeller.FindProduct(ID);
            UpdateProductHandellerModel model = new UpdateProductHandellerModel();
            model.Name = product.Name;
            model.Description = product.Description;
            model.Model = product.Model;

            return View(model);
        }
        [HttpPost]
        public IActionResult EditProduct(UpdateProductHandellerModel vmodel)
        {
            productHandeller.UpdateProduct(vmodel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DetailProduct(int ID)
        {
            var product=productQueryHandeller.Detail(ID);
            ProductDetailQueryHandellerModel model = new ProductDetailQueryHandellerModel();
            model.ID = product.ID;
            model.Name = product.Name;
            model.Model = product.Model;
            model.Description = product.Description;


            return View(model);
        }

        public IActionResult DeleteProduct(int ID)
        {
            productHandeller.DeleteProduct(ID);
            return RedirectToAction("Index");
        }
    }
}
