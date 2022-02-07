
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Database.Entities
{
    [Index(nameof(CategoryName), IsUnique = true)]
    public class TblCategory : CommonEntity
    {
        [Required(ErrorMessage ="Required is Field")]
        public string CategoryName { get; set; }
    }
}
