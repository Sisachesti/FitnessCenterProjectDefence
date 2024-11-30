namespace FitnessCenter.Data.Models
{
    public class GymClass
    {
        public Guid ClassId { get; set; }

        public virtual Class Class { get; set; } = null!;

        public Guid GymId { get; set; }

        public virtual Gym Gym { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public int AvailableSubscribtions { get; set; }
    }
}
