using JWM.Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Clinic.AccessData.Entity.TypeConfiguration
{
    public class HandbookTypeConfiguration : IEntityTypeConfiguration<Handbook>
    {
        public void Configure(EntityTypeBuilder<Handbook> builder)
        {
            builder.ToTable("HAND_HANDBOOK");

            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("HAND_ID");

            builder.Property(p => p.Date)
                .IsRequired()
                .HasColumnName("HAND_DATE");

            builder.Property(p => p.Observation)
                .IsRequired()
                .HasColumnName("HAND_OBSERVATION")
                .HasMaxLength(100);


            builder.Property(p => p.IdAnimal)
                .HasColumnName("ANI_ID")
                .IsRequired();

            builder.Property(p => p.IdVeterinary)
                .HasColumnName("VET_ID")
                .IsRequired();

            builder.HasKey(pk => pk.Id);

            builder.HasOne(a => a.Animal)
                .WithMany()
                .IsRequired()
                .HasForeignKey(a => a.IdAnimal);

            builder.HasOne(v => v.Veterinary)
                .WithMany()
                .IsRequired()
                .HasForeignKey(v => v.IdVeterinary);


        }
    }
}
