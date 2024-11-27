namespace FitnessCenter.Data.Models
{
    public class Subscribtion
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public Guid GymId { get; set; }

        public virtual Gym Gym { get; set; } = null!;

        public Guid ClassId { get; set; }

        public virtual Class Class { get; set; } = null!;

        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;
    }
}