using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrestCouriers_Career.Models;
using Microsoft.EntityFrameworkCore;

namespace CrestCouriers_Career.Data
{
    public class CrestContext : DbContext

    {
        public CrestContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<RegCareer> RegCareer { get; set; }
        public DbSet<User> User { get; set; }
    }
}
