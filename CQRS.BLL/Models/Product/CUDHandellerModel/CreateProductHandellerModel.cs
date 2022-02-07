using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.BLL.Models.Product.CUDHandellerModel
{
    public class CreateProductHandellerModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
    }
}
