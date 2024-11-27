using FitnessCenter.Services.Mapping;
using System.ComponentModel.DataAnnotations;
using static FitnessCenter.Common.EntityValidationConstants.Gym;

namespace FitnessCenter.Web.ViewModels.Gym
{
    using Data.Models;
    public class AddGymFormModel : IMapTo<Gym>
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(LocationMinLength)]
        [MaxLength(LocationMaxLength)]
        public string Location { get; set; } = null!;
    }
}
