using CQRS.BLL.Models.Category.QueryHandellerModel;
using CQRS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.BLL.Interfaces.Category.QueryHandeller
{
    public interface ICategoryListingQueryHandeller
    {
        List<TblCategory> GetAllCategory();
        DetailCategoryQueryHandellerModel DetailProduct(int ID);
    }
}
