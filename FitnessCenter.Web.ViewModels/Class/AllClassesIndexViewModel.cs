using AutoMapper;

namespace FitnessCenter.Web.ViewModels.Class
{
    using static Common.EntityValidationConstants.Class;
    using Data.Models;
    using FitnessCenter.Services.Mapping;
    using System.Globalization;

    public class AllClassesIndexViewModel : IMapFrom<Class>, IHaveCustomMappings
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string StartingDate { get; set; } = null!;

        public string Duration { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Class, AllClassesIndexViewModel>()
                .ForMember(d => d.StartingDate,
                    x => x.MapFrom(s => s.StartingDate.ToString(StartingDateFormat, CultureInfo.InvariantCulture)));
        }
    }
}
