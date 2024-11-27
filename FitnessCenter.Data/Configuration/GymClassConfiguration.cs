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
            builder.HasKey(cm => new { cm.GymId, cm.ClassId });

            builder
                .Property(cm => cm.IsDeleted)
                .HasDefaultValue(false);

            builder
                .HasOne(cm => cm.Class)
                .WithMany(m => m.ClassGyms)
                .HasForeignKey(cm => cm.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(cm => cm.Gym)
                .WithMany(c => c.GymClasses)
                .HasForeignKey(cm => cm.ClassId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
