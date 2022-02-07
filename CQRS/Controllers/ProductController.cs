
using CQRS.BLL.Interfaces.Product;
using CQRS.BLL.Models.Product.CUDHandellerModel;
using CQRS.BLL.Models.Product.QueryHandellerModel;
using CQRS.Database;
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
        private CQRSContext db;
        public ProductController(IProductHandeller _productHandeller, IProductQueryHandeller _productQueryHandeller, CQRSContext _db)
        {
            productHandeller = _productHandeller;
            productQueryHandeller = _productQueryHandeller;
            db = _db;
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
            if (ModelState.IsValid)
            {
                var checkUniqueModel = db.Products.Where(x=>x.Model==vmodel.Model);
                if (checkUniqueModel.Count() > 0)
                {
                    TempData["message"] = "This Model Number Already Exists!";
                }
                else {
                    productHandeller.SaveProduct(vmodel);
                    return RedirectToAction("Index");
                }
                
            }
            return View();
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
            if (ModelState.IsValid)
            {
                var checkUniqueModel = db.Products.Where(x=>x.Model==vmodel.Model);

                if (checkUniqueModel.Count() > 0)
                {
                    TempData["EditMessage"] = "The Model Is Already Exists in Database";
                }

                else
                {
                    productHandeller.UpdateProduct(vmodel);
                    return RedirectToAction("Index");
                }
            }
            var ID = vmodel.ID;
            return RedirectToAction("EditProduct",ID);
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
