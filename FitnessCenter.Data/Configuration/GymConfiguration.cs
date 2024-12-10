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
                    Location = "Yambol",
                    ImageUrl = "https://static.vecteezy.com/system/resources/previews/026/781/389/non_2x/gym-interior-background-of-dumbbells-on-rack-in-fitness-and-workout-room-photo.jpg"
                },
                new Gym()
                {
                    Name = "Flex",
                    Location = "Yambol",
                    ImageUrl = "https://images.unsplash.com/photo-1534438327276-14e5300c3a48?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Z3ltfGVufDB8fDB8fHww"
                },
                new Gym()
                {
                    Name = "Olimpia",
                    Location = "Yambol",
                    ImageUrl = "https://media.istockphoto.com/id/1322158059/photo/dumbbell-water-bottle-towel-on-the-bench-in-the-gym.jpg?s=612x612&w=0&k=20&c=CIdh6LPGwU6U6lbvKCdd7LcppidaYwcDawXJI-b0yGE="
                },
                new Gym()
                {
                    Name = "Pulse Fitness",
                    Location = "Plovdiv",
                    ImageUrl = "https://snworksceo.imgix.net/cav/8d443aec-2090-4e9e-8793-6b95d830d89f.sized-1000x1000.JPG?w=1000"
                }
            };

            return gyms;
        }
    }
}

