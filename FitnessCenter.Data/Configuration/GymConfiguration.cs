using FitnessCenter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FitnessCenter.Common.EntityValidationConstants.Gym;

namespace FitnessCenter.Data.Configuration
{
    public class GymConfiguration : IEntityTypeConfiguration<Gym>
    {
        public void Configure(EntityTypeBuilder<Gym> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder
                .Property(c => c.Location)
                .IsRequired()
                .HasMaxLength(LocationMaxLength);

            builder.HasData(this.GenerateGyms());
        }

        private IEnumerable<Gym> GenerateGyms()
        {
            IEnumerable<Gym> gyms = new List<Gym>()
            {
                new Gym()
                {
                    Name = "Gladiator",
                    Location = "Yambol"
                },
                new Gym()
                {
                    Name = "Flex",
                    Location = "Yambol"
                },
                new Gym()
                {
                    Name = "Olimpia",
                    Location = "Yambol"
                },
                new Gym()
                {
                    Name = "Pulse Fitness",
                    Location = "Plovdiv"
                }
            };

            return gyms;
        }
    }
}

