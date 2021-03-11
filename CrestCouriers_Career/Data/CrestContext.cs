using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrestCouriers_Career.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CrestCouriers_Career.Data
{
    public class CrestContext : IdentityDbContext

    {
        public CrestContext()
        {
        }

        public CrestContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Account> Account { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<RegCareer> RegCareer { get; set; }
        public DbSet<Bill> Bill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.; Database = CrestDB; Trusted_Connection = True; MultipleActiveResultSets = true");
            //optionsBuilder.UseSqlServer("Server=sql11.hostinguk.net; Database=crestcou_database; User Id=crestdbuser; Password=CRESTcouriers.db;MultipleActiveResultSets=true");
            //Server =.; Database = CrestDB; Trusted_Connection = True; MultipleActiveResultSets = true
            //Server=sql11.hostinguk.net; Database=crestcou_database; User Id=crestdbuser; Password=CRESTcouriers.db;MultipleActiveResultSets=true
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>()
            .HasMany<Location>(O => O.Locations)
            .WithOne(P => P.Order);

            builder.Entity<Location>()
            .HasMany<Address>(O => O.Addresses)
            .WithOne(P => P.Location);
        }
    }
}
