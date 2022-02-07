﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.BLL.Models.Product.CUDHandellerModel
{
    public class UpdateProductHandellerModel
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Required This Field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required This Field")]
        public string Model { get; set; }
        public string Description { get; set; }
    }
}
