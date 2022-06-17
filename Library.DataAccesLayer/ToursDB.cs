using Library.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;

namespace Library.DataAccesLayer
{
    public class ToursDB : DbContext
    {
        public ToursDB(DbContextOptions<ToursDB> options) : base(options)
        {

        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasKey(b => b.Id);
            modelBuilder.Entity<Tour>().HasKey(t => t.Id);
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            
            modelBuilder.Entity<Booking>().HasOne(b => b.Tour).WithMany(t => t.Bookings).HasForeignKey(t => t.TourId);
            modelBuilder.Entity<Booking>().HasOne(b => b.Customer).WithMany(c => c.Bookings).HasForeignKey(t => t.CustomerId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
