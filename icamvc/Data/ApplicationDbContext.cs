using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ICAMVC.Models;

namespace ICAMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ICAMVC.Models.Route> Route { get; set; }
        public DbSet<ICAMVC.Models.Driver> Driver { get; set; }
    }
}
