using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessCenter.Data.Configuration
{
    using Data.Models;
    public class SubscribtionConfiguration : IEntityTypeConfiguration<Subscribtion>
    {
        public void Configure(EntityTypeBuilder<Subscribtion> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(s => s.GymId)
                .IsRequired();

            builder
                .Property(s => s.ClassId)
                .IsRequired();

            builder
                .Property(s => s.UserId)
                .IsRequired();

            builder
                .HasOne(s => s.Gym)
                .WithMany(g => g.Subscribtions)
                .HasForeignKey(s => s.GymId);

            builder
                .HasOne(s => s.Class)
                .WithMany(c => c.Subscribtions)
                .HasForeignKey(s => s.ClassId);

            builder
                .HasOne(s => s.User)
                .WithMany(u => u.Subscribtions)
                .HasForeignKey(s => s.UserId);
        }
    }
}
