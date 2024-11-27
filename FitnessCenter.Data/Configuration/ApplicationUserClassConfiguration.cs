using FitnessCenter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Data.Configuration
{
    public class ApplicationUserClassConfiguration : IEntityTypeConfiguration<ApplicationUserClass>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserClass> builder)
        {
            builder
                .HasKey(um => new { um.ApplicationUserId, um.ClassId });

            builder
                .HasOne(um => um.Class)
                .WithMany(m => m.ClassApplicationUsers)
                .HasForeignKey(um => um.ClassId);

            builder
                .HasOne(um => um.ApplicationUser)
                .WithMany(u => u.ApplicationUserClasses)
                .HasForeignKey(um => um.ApplicationUserId);
        }
    }
}
