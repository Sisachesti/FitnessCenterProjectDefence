using FitnessCenter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FitnessCenter.Common.EntityValidationConstants.Class;
using static FitnessCenter.Common.ApplicationConstants;

namespace FitnessCenter.Data.Configuration
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            // Fluent API
            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder
                .Property(m => m.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength)
                .HasDefaultValue(NoImageUrl);

            builder.HasData(this.SeedClasses());
        }

        private List<Class> SeedClasses()
        {
            List<Class> movies = new List<Class>()
            {
                new Class()
                {
                    Title = "Yoga Class",
                    StartingDate = new DateTime(2024, 12, 03),
                    Duration = 90,
                    Description = "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed."
                },
                new Class()
                {
                    Title = "Full-Body Strength Training",
                    StartingDate = new DateTime(2024, 12, 04),
                    Duration = 120,
                    Description = "A well-rounded workout targeting all major muscle groups. Incorporates free weights, resistance machines, and bodyweight exercises to improve overall strength, endurance, and stability. Suitable for all levels, with modifications available."
                }
            };

            return movies;
        }
    }
}
