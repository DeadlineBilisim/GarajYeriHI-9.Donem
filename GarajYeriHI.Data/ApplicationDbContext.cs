using GarajYeriHI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<PolicyType> PolicyTypes { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleInspection> VehicleInspections { get; set;}
        public virtual DbSet<VehiclePhoto> VehiclePhotos { get; set;}
        public virtual DbSet<VehicleProcess> VehicleProcesses { get; set; }
        public virtual DbSet<VehicleProcessType> VehicleProcessTypes { get; set;}
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }

        //FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.Entity<Vehicle>().Property(p => p.Name).HasMaxLength(50);
        }

    }
}
