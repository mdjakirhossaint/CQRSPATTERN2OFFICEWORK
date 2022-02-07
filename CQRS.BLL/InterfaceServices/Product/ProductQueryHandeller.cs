using CQRS.BLL.Interfaces.Product;
using CQRS.BLL.Models.Product.QueryHandellerModel;
using CQRS.Database;
using CQRS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.BLL.InterfaceServices.Product
{
    public class ProductQueryHandeller : IProductQueryHandeller
    {
        private CQRSContext db;
        public ProductQueryHandeller(CQRSContext _db)
        {
            db = _db;
        }

        public TblProduct Detail(int ID)
        {
            var product = db.Products.Where(x => x.ID == ID).FirstOrDefault();
            return product;
           //var product= db.Products.Find(ID);
           // ProductDetailQueryHandellerModel model = new ProductDetailQueryHandellerModel()
           // {
           //     ID=product.ID,
           //     Name=product.Name,
           //     Model=product.Model,
           //     Description=product.Description
           // };
           // return model;
        }

        public List<TblProduct> GetAllProducts()
        {
            var listOfProduct = db.Products.ToList();
            return listOfProduct;
        }
    }
}
