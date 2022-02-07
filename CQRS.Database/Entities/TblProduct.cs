using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Database.Entities
{
    public class TblProduct : CommonEntity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }

        public int? TblCategoryID { get; set; }
        public virtual TblCategory TblCategory { get; set; }
        public int? TblBrandID { get; set; }
        public virtual TblBrand TblBrand { get; set; }
    }
}
