using CQRS.BLL.Models.Category.CUDHandellerModel;
using CQRS.BLL.Models.Category.QueryHandellerModel;
using CQRS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.BLL.Interfaces.Category.CommandHandeller
{
    public interface ICreateCategoryCommandHandeller
    {
        void SaveCategory(CreateCategoryHandellerModel model);
        void UpdateCategory(UpdateCategoryHandellerModel model);
        //TblCategory FindCategory(int ID);
        public UpdateCategoryHandellerModel FindCategory(int ID);
        public bool DeleteCategory(int ID);

    }
}
