using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Model
{
    public partial class OutletStocks : DbContext
    {
        public OutletStocks()
            : base("name=OutletStocks")
        {
        }

        public virtual DbSet<OutletStock> OutletStock { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OutletStock>()
                .Property(e => e.Outlet_Name)
                .IsUnicode(false);

            modelBuilder.Entity<OutletStock>()
                .Property(e => e.Batch_No)
                .IsUnicode(false);

            modelBuilder.Entity<OutletStock>()
                .Property(e => e.Medicine_Name)
                .IsUnicode(false);

            modelBuilder.Entity<OutletStock>()
                .Property(e => e.Medicine_Dosage)
                .IsUnicode(false);

            modelBuilder.Entity<OutletStock>()
                .Property(e => e.Company_Name)
                .IsUnicode(false);

            modelBuilder.Entity<OutletStock>()
                .Property(e => e.Stock_Status)
                .IsUnicode(false);
        }
    }
}
