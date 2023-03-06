using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Model
{
    public partial class UsersOrder : DbContext
    {
        public UsersOrder()
            : base("name=UsersOrder")
        {
        }

        public virtual DbSet<UserOrder> UserOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOrder>()
                .Property(e => e.Outlet_Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserOrder>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserOrder>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<UserOrder>()
                .Property(e => e.District)
                .IsUnicode(false);

            modelBuilder.Entity<UserOrder>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<UserOrder>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<UserOrder>()
                .Property(e => e.Medicine_Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserOrder>()
                .Property(e => e.Medicine_Dosage)
                .IsUnicode(false);

            modelBuilder.Entity<UserOrder>()
                .Property(e => e.Company_Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserOrder>()
                .Property(e => e.OrderStatus)
                .IsUnicode(false);
        }
    }
}
