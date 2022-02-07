using CQRS.BLL.Interfaces.Category.CommandHandeller;
using CQRS.BLL.Models.Category.CUDHandellerModel;
using CQRS.BLL.Models.Category.QueryHandellerModel;
using CQRS.Database;
using CQRS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.BLL.InterfaceServices.Category.CommandHandeller
{
    public class CreateCategoryCommandHandeller : ICreateCategoryCommandHandeller

    {
        private CQRSContext db;
        public CreateCategoryCommandHandeller(CQRSContext _db)
        {
            db = _db;
        }

        public bool DeleteCategory(int ID)
        {
            var category = db.Categories.Find(ID);
            db.Remove(category);
            db.SaveChanges();
            return true;
        }

        public UpdateCategoryHandellerModel FindCategory(int ID)
        {
            var category = db.Categories.Find(ID);
            UpdateCategoryHandellerModel model = new UpdateCategoryHandellerModel()
            { 
                ID=category.ID,
                CategoryName=category.CategoryName,
            };
            return model;
        }

        public void SaveCategory(CreateCategoryHandellerModel model)
        {
            TblCategory category = new TblCategory()
            {
                CategoryName = model.CategoryName,
            };
            db.Categories.Add(category);
            db.SaveChanges();
        }


        public void UpdateCategory(UpdateCategoryHandellerModel model)
        {
            TblCategory category = new TblCategory()
            { 
                ID=model.ID,
                CategoryName=model.CategoryName,
            };
            db.Update(category);
            db.SaveChanges();
        }

    }
}
