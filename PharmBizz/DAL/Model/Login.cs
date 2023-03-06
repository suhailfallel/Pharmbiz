using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Model
{
    public partial class Login : DbContext
    {
        public Login()
            : base("name=Login1")
        {
        }

        public virtual DbSet<LoginCredential> LoginCredentials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginCredential>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<LoginCredential>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<LoginCredential>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<LoginCredential>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<LoginCredential>()
                .Property(e => e.Status)
                .IsUnicode(false);
        }
    }
}
