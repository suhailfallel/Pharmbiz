using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Model
{
    public partial class MedicineList : DbContext
    {
        public MedicineList()
            : base("name=MedicineList")
        {
        }

        public virtual DbSet<Medicine> Medicines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>()
                .Property(e => e.Medicine_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Dosage)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Medicine_Image)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Company_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Stock_Status)
                .IsUnicode(false);
        }
    }
}
