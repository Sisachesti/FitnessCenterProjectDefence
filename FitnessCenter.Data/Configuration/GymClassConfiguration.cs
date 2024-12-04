using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessCenter.Data.Models;

namespace FitnessCenter.Data.Configuration
{
    public class GymClassConfiguration : IEntityTypeConfiguration<GymClass>
    {
        public void Configure(EntityTypeBuilder<GymClass> builder)
        {
            builder.HasKey(gc => new { gc.GymId, gc.ClassId });

            builder
                .Property(gc => gc.IsDeleted)
                .HasDefaultValue(false);

            builder
                .HasOne(gc => gc.Class)
                .WithMany(c => c.ClassGyms)
                .HasForeignKey(gc => gc.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(gc => gc.Gym)
                .WithMany(g => g.GymClasses)
                .HasForeignKey(gc => gc.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(gc => gc.AvailableSubscribtions)
                .IsRequired(true)
                .HasDefaultValue(0);
        }
    }
}
