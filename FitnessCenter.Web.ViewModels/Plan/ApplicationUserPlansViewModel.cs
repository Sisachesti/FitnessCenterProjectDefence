using AutoMapper;

namespace FitnessCenter.Web.ViewModels.Plans
{
    using Data.Models;
    using FitnessCenter.Services.Mapping;
    using static Common.EntityValidationConstants.Class;
    public class ApplicationUserPlansViewModel : IHaveCustomMappings
    {
        public string ClassId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string StartingDate { get; set; } = null!;

        public string? ImageUrl { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ApplicationUserClass, ApplicationUserPlansViewModel>()
                .ForMember(d => d.ClassId, x => x.MapFrom(s => s.ClassId.ToString()))
                .ForMember(d => d.Title, x => x.MapFrom(s => s.Class.Title))
                .ForMember(d => d.StartingDate, x => x.MapFrom(s => s.Class.StartingDate.ToString(StartingDateFormat)))
                .ForMember(d => d.ImageUrl, x => x.MapFrom(s => s.Class.ImageUrl));
        }
    }
}
