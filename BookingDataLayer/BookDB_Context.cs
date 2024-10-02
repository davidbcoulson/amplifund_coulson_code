using BookingDataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDataLayer
{
    public class BookDB_Context : IdentityDbContext<IdentityUser>
    {
        public readonly IConfiguration _configuration;
        public BookDB_Context(IConfiguration configuration) {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), optionsBuilder => optionsBuilder.MigrationsAssembly("Application.Web"));
            }
        }
        public DbSet<GuestBooking> GuestBookings { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GuestBooking>()
                .HasOne(b => b.Venue);
        }
    }
}
