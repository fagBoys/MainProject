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
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<RegCareer>RegCareers { get; set; }
        public DbSet<User>Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-MNCHKTA;Initial Catalog=Crest;Integrated Security=True;");
        }
    }
}
