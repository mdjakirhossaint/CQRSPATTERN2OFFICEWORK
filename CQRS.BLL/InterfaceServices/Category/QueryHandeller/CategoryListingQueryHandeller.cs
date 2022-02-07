using CQRS.BLL.Interfaces.Category.QueryHandeller;
using CQRS.BLL.Models.Category.QueryHandellerModel;
using CQRS.Database;
using CQRS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.BLL.InterfaceServices.Category.QueryHandeller
{
    public class CategoryListingQueryHandeller : ICategoryListingQueryHandeller
    {
        private CQRSContext db;
        public CategoryListingQueryHandeller( CQRSContext _db)
        {
            db = _db;
        }

        public DetailCategoryQueryHandellerModel DetailProduct(int ID)
        {
            var category = db.Categories.Find(ID);
            DetailCategoryQueryHandellerModel model = new DetailCategoryQueryHandellerModel()
            {
                ID = category.ID,
                CategoryName = category.CategoryName,
            };
            return model;
        }

        public List<TblCategory> GetAllCategory()
        {
            var category = db.Categories.ToList();

            return category;
        }
    }
}
