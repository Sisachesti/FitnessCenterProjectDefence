using Microsoft.AspNetCore.Identity;

namespace FitnessCenter.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            this.Id = Guid.NewGuid();
        }

        // TODO: Add more properties to our user
        public virtual ICollection<ApplicationUserClass> ApplicationUserClasses { get; set; }
            = new HashSet<ApplicationUserClass>();

        public virtual ICollection<Subscribtion> Subscribtions { get; set; }
           = new HashSet<Subscribtion>();
    }
}
