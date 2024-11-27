using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.ViewModels.Class
{
    using Data.Models;
    using FitnessCenter.Services.Mapping;
    using static Common.EntityValidationConstants.Class;
    using static Common.EntityValidationMessages.Class;

    public class AddClassInputModel : IMapTo<Class>, IHaveCustomMappings
    {
        public AddClassInputModel()
        {
            this.StartingDate = DateTime.UtcNow.ToString(StartingDateFormat);
        }

        [Required(ErrorMessage = ClassTitleRequiredMessage)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = StartingDateRequiredMessage)]
        public string StartingDate { get; set; }

        [Required(ErrorMessage = DurationRequiredMessage)]
        [Range(DurationMinValue, DurationMaxValue)]
        public int Duration { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<AddClassInputModel, Class>()
                .ForMember(d => d.StartingDate, x => x.Ignore());
        }
    }
}
