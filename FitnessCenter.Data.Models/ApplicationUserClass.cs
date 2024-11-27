namespace FitnessCenter.Data.Models
{
    public class ApplicationUserClass
    {
        public Guid ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid ClassId { get; set; }

        public virtual Class Class { get; set; } = null!;
    }
}
