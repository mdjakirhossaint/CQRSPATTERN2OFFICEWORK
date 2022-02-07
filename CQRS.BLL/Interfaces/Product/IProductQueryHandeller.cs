using CQRS.Database;
using CQRS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.BLL.Interfaces.Product
{
    public interface IProductQueryHandeller
    {
        List<TblProduct> GetAllProducts();
        TblProduct Detail(int ID);
    }
}
