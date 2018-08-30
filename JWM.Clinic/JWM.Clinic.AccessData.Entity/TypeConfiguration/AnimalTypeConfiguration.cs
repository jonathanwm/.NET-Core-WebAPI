using JWM.Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Clinic.AccessData.Entity.TypeConfiguration
{
    public class AnimalTypeConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("ANI_ANIMAL");

            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("ANI_ID");
                

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("ANI_NAME")
                .HasMaxLength(100);

            builder.Property(p => p.Age)
                .IsRequired()
                .HasColumnName("ANI_AGE");

            builder.Property(p => p.NameOwner)
                .IsRequired()
                .HasColumnName("ANI_NAMEOWNER")
                .HasMaxLength(100);

            builder.Property(p => p.Breed)
                .IsRequired()
                .HasColumnName("ANI_BREED")
                .HasMaxLength(100);

            builder.HasKey(pk => pk.Id);
        }
    }
}
