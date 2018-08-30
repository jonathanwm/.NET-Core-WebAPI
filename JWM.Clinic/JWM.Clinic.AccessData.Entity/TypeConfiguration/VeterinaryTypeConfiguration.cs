using JWM.Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Clinic.AccessData.Entity.TypeConfiguration
{
    public class VeterinaryTypeConfiguration : IEntityTypeConfiguration<Veterinary>
    {
        public void Configure(EntityTypeBuilder<Veterinary> builder)
        {
            builder.ToTable("VET_VETERINARY");

            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("VET_ID");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("MED_NAME")
                .HasMaxLength(100);

            builder.Property(p => p.Specialty)
                .IsRequired()
                .HasColumnName("MED_SPECIALTY")
                .HasMaxLength(100);

            builder.Property(p => p.NumberCRV)
                .IsRequired()
                .HasColumnName("MED_NUMBERCRV");

            builder.HasKey(pk => pk.Id);
        }
    }
}
