using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Model
{
    public partial class OutletRegistration : DbContext
    {
        public OutletRegistration()
            : base("name=OutletRegistration1")
        {
        }

        public virtual DbSet<MedicalOutlet> MedicalOutlets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalOutlet>()
                .Property(e => e.Outlet_Name)
                .IsUnicode(false);

            modelBuilder.Entity<MedicalOutlet>()
                .Property(e => e.Outlet_LicensiName)
                .IsUnicode(false);

            modelBuilder.Entity<MedicalOutlet>()
                .Property(e => e.Outlet_LicenseNum)
                .IsUnicode(false);

            modelBuilder.Entity<MedicalOutlet>()
                .Property(e => e.Outlet_Address)
                .IsUnicode(false);

            modelBuilder.Entity<MedicalOutlet>()
                .Property(e => e.Outlet_Place)
                .IsUnicode(false);

            modelBuilder.Entity<MedicalOutlet>()
                .Property(e => e.Outlet_District)
                .IsUnicode(false);

            modelBuilder.Entity<MedicalOutlet>()
                .Property(e => e.Outlet_State)
                .IsUnicode(false);

            modelBuilder.Entity<MedicalOutlet>()
                .Property(e => e.Outlet_Contact)
                .IsUnicode(false);

            modelBuilder.Entity<MedicalOutlet>()
                .Property(e => e.Outlet_Email)
                .IsUnicode(false);

            modelBuilder.Entity<MedicalOutlet>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<MedicalOutlet>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<MedicalOutlet>()
                .Property(e => e.Status)
                .IsUnicode(false);
        }
    }
}
