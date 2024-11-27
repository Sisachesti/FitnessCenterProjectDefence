using FitnessCenter.Web.ViewModels.Gym;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Web.ViewModels.Class
{
    using static Common.EntityValidationConstants.Class;
    public class AddClassToGymInputModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        public IList<GymCheckBoxItemInputModel> Gyms { get; set; }
            = new List<GymCheckBoxItemInputModel>();
    }
}
