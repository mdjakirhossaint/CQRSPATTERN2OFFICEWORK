using CQRS.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Database
{
    public class CQRSContext : DbContext
    {
        public CQRSContext()
        {
            
        }
        public CQRSContext(DbContextOptions<CQRSContext>options) : base(options)
        {

        }
        public DbSet<TblProduct> Products { get; set; }
        public DbSet<TblCategory> Categories { get; set; }
        public DbSet<TblBrand> Brands { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-67HJTDQ2;Database=CQRS;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
