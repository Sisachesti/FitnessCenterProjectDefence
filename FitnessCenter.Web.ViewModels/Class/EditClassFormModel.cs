using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Web.ViewModels.Class
{
    using static Common.EntityValidationConstants.Class;
    using static Common.EntityValidationMessages.Class;
    using Data.Models;
    using FitnessCenter.Services.Mapping;
    using System.Globalization;

    public class EditClassFormModel : IMapFrom<Class>, IMapTo<Class>, IHaveCustomMappings
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = ClassTitleRequiredMessage)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = StartingDateRequiredMessage)]
        public string StartingDate { get; set; } = null!;

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
            configuration.CreateMap<Class, EditClassFormModel>()
                .ForMember(d => d.StartingDate,
                    opt => opt.MapFrom(s => s.StartingDate.ToString(StartingDateFormat, CultureInfo.InvariantCulture)));

            configuration.CreateMap<EditClassFormModel, Class>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.StartingDate, opt => opt.Ignore());
        }
    }
}
