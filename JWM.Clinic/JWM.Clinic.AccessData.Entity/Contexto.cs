using JWM.Clinic.AccessData.Entity.TypeConfiguration;
using JWM.Clinic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Clinic.AccessData.Entity.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public Contexto() { }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Veterinary> Veterinaries { get; set; }
        public DbSet<Handbook> Handbooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VeterinaryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HandbookTypeConfiguration());
            
        }

    }
}
