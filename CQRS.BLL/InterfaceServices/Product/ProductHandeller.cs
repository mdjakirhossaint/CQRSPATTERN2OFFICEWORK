using CQRS.BLL.Interfaces.Product;
using CQRS.BLL.Models.Product.CUDHandellerModel;
using CQRS.Database;
using CQRS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.BLL.InterfaceServices.Product
{
    public class ProductHandeller : IProductHandeller
    {
        private  CQRSContext db;
        public ProductHandeller(CQRSContext _db)
        {
            db = _db;
        }

        public void DeleteProduct(int ID)
        {
            var product = db.Products.Find(ID);
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public TblProduct FindProduct(int ID)
        {
           var product= db.Products.Find(ID);
            return product;
        }

        public void SaveProduct(CreateProductHandellerModel model)
        {
            TblProduct product = new TblProduct()
            {
                Name=model.Name,
                Description=model.Description,
                Model=model.Model,

            };
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void UpdateProduct(UpdateProductHandellerModel model)
        {
            TblProduct product = new TblProduct()
            {
                ID=model.ID,
                Name = model.Name,
                Description = model.Description,
                Model = model.Model,

            };
            db.Products.Update(product);
            db.SaveChanges();
        }
    }
}
