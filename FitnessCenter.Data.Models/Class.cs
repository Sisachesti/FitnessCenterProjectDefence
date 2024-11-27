namespace FitnessCenter.Data.Models
{
    public class Class
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; } = null!;

        public DateTime StartingDate { get; set; }

        public int Duration { get; set; }

        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public virtual ICollection<GymClass> ClassGyms { get; set; }
            = new HashSet<GymClass>();

        public virtual ICollection<ApplicationUserClass> ClassApplicationUsers { get; set; }
            = new HashSet<ApplicationUserClass>();

        public virtual ICollection<Subscribtion> Subscribtions { get; set; }
            = new HashSet<Subscribtion>();
    }
}
