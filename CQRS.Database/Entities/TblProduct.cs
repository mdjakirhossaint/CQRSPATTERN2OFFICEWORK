using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Database.Entities
{
    [Index(nameof(Model),IsUnique=true)]
    public class TblProduct : CommonEntity
    {
        [Required(ErrorMessage ="Required This Field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required This Field")]
        public string Model { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Required This Field")]
        public decimal ProductPrice { get; set; }

        public int? TblCategoryID { get; set; }
        public virtual TblCategory TblCategory { get; set; }
        public int? TblBrandID { get; set; }
        public virtual TblBrand TblBrand { get; set; }
    }
}
