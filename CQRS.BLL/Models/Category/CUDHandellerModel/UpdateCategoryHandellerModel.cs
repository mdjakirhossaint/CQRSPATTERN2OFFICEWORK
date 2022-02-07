using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.BLL.Models.Category.CUDHandellerModel
{
    public class UpdateCategoryHandellerModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Required this Field")]
        public string CategoryName { get; set; }
    }
}
