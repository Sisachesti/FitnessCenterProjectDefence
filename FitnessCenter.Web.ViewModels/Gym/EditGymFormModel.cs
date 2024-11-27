using AutoMapper;
using FitnessCenter.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.ViewModels.Gym
{
    using static Common.EntityValidationConstants.Gym;
    using Data.Models;

    public class EditGymFormModel : IHaveCustomMappings
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(LocationMinLength)]
        [MaxLength(LocationMaxLength)]
        public string Location { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Gym, EditGymFormModel>();

            configuration
                .CreateMap<EditGymFormModel, Gym>()
                .ForMember(d => d.Id, x => x.MapFrom(s => Guid.Parse(s.Id)));
        }
    }
}
