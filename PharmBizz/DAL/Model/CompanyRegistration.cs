using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Model
{
    public partial class CompanyRegistration : DbContext
    {
        public CompanyRegistration()
            : base("name=CompanyRegistration")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(e => e.Company_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Company_RegNo)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Company_Address)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Company_District)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Company_State)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Company_Contact)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Company_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Status)
                .IsUnicode(false);
        }
    }
}
