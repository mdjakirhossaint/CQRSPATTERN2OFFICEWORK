using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.BLL.Models.Category.CUDHandellerModel
{
    public class CreateCategoryHandellerModel
    {
        [Required(ErrorMessage ="This Field are Required")]
        public string CategoryName { get; set; }
    }
}
