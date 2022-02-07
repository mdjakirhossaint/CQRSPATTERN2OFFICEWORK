using CQRS.BLL.Interfaces.Category.CommandHandeller;
using CQRS.BLL.Interfaces.Category.QueryHandeller;
using CQRS.BLL.Models.Category.CUDHandellerModel;
using CQRS.BLL.Models.Category.QueryHandellerModel;
using CQRS.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Controllers
{
    public class CategoryController : Controller
    {
        private ICreateCategoryCommandHandeller categoryHandeller;
        private ICategoryListingQueryHandeller listingHandeller;
        private CQRSContext db;
        public CategoryController(ICreateCategoryCommandHandeller _categoryHandeller, ICategoryListingQueryHandeller _listingHandeller, CQRSContext _db)
        {
            categoryHandeller = _categoryHandeller;
            listingHandeller = _listingHandeller;
            db = _db;
        }
        public IActionResult Index()
        {
            var category = listingHandeller.GetAllCategory();
            return View(category);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(CreateCategoryHandellerModel vmodel)
        {
            if(ModelState.IsValid)
            {
                var checkCategory = db.Categories.Where(x => x.CategoryName == vmodel.CategoryName);


                if (checkCategory.Count() > 0)
                {
                    ViewBag.message = "This Category name is Already Exists";
                    return View();
                }
                else {
                    categoryHandeller.SaveCategory(vmodel);
                    return RedirectToAction("Index");
                }
                
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditCategory(int ID)
        {

            var category = categoryHandeller.FindCategory(ID);
            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategory(UpdateCategoryHandellerModel vmodel)
        {
            var checkCategoryIsExists = db.Categories.Where(x=>x.CategoryName==vmodel.CategoryName);
            var mess = ViewBag.Message;
            if (checkCategoryIsExists.Count() > 0)
            {
                TempData["Message"] = "This Category Name is Already Exists";
            }
            else {
                categoryHandeller.UpdateCategory(vmodel);
                return RedirectToAction("Index");
            }
            var ID = vmodel.ID;
            return RedirectToAction("EditCategory",ID);
        }
        [HttpPost]
        public IActionResult DeleteCategory(int ID)
        {
            categoryHandeller.DeleteCategory(ID);
            return RedirectToAction("Index");
        }

        public IActionResult DetailCategory(int ID)
        {
            var category = listingHandeller.DetailProduct(ID);
            return View(category);
        }
    }
}
