
using CQRS.BLL.Models.Product.CUDHandellerModel;
using CQRS.Database;
using CQRS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.BLL.Interfaces.Product
{
    public interface IProductHandeller
    {
        void SaveProduct(CreateProductHandellerModel model);
        void UpdateProduct(UpdateProductHandellerModel model);
        TblProduct FindProduct(int ID);
        void DeleteProduct(int ID);
    }
}
