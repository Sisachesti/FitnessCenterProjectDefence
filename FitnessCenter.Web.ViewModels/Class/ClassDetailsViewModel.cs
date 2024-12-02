using AutoMapper;

namespace FitnessCenter.Web.ViewModels.Class
{
    using Data.Models;
    using FitnessCenter.Services.Mapping;
    using System.Globalization;
    using static Common.EntityValidationConstants.Class;
    public class ClassDetailsViewModel : IMapFrom<Class>, IHaveCustomMappings
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string StartingDate { get; set; } = null!;

        public string Duration { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Class, ClassDetailsViewModel>()
                .ForMember(d => d.StartingDate,
                    x => x.MapFrom(s => s.StartingDate.ToString(StartingDateFormat, CultureInfo.InvariantCulture)));
        }
    }
}
