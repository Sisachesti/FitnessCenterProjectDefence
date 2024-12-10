namespace FitnessCenter.Data.Models
{
    public class Gym
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public string? ImageUrl { get; set; }

        public virtual ICollection<GymClass> GymClasses { get; set; }
            = new HashSet<GymClass>();

        public virtual ICollection<Subscribtion> Subscribtions { get; set; }
            = new HashSet<Subscribtion>();
    }
}
