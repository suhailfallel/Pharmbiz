using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Model
{
    public partial class OutletOrders : DbContext
    {
        public OutletOrders()
            : base("name=OutletOrders")
        {
        }

        public virtual DbSet<OutletOrder> OutletOrder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OutletOrder>()
                .Property(e => e.Outlet_Name)
                .IsUnicode(false);

            modelBuilder.Entity<OutletOrder>()
                .Property(e => e.Outlet_Address)
                .IsUnicode(false);

            modelBuilder.Entity<OutletOrder>()
                .Property(e => e.Medicine_Name)
                .IsUnicode(false);

            modelBuilder.Entity<OutletOrder>()
                .Property(e => e.Medicine_Dosage)
                .IsUnicode(false);

            modelBuilder.Entity<OutletOrder>()
                .Property(e => e.Batch_No)
                .IsUnicode(false);

            modelBuilder.Entity<OutletOrder>()
                .Property(e => e.Company_Name)
                .IsUnicode(false);

            modelBuilder.Entity<OutletOrder>()
                .Property(e => e.Order_Status)
                .IsUnicode(false);
        }
    }
}
