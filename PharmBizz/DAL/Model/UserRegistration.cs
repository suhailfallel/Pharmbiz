using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Model
{
    public partial class UserRegistration : DbContext
    {
        public UserRegistration()
            : base("name=UserRegistration1")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LandMark)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.District)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Status)
                .IsUnicode(false);
        }
    }
}
