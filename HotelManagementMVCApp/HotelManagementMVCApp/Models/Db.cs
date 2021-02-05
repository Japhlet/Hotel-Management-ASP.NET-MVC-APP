using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HotelManagementMVCApp.Models
{
    public partial class Db : DbContext
    {
        public Db()
            : base("name=Db")
        {
        }

        public virtual DbSet<BookingStatus> BookingStatus { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomBooking> RoomBooking { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentType>()
                .HasOptional(e => e.Payment)
                .WithRequired(e => e.PaymentType);

            modelBuilder.Entity<RoomBooking>()
                .HasMany(e => e.Payment)
                .WithRequired(e => e.RoomBooking)
                .WillCascadeOnDelete(false);
        }
    }
}
