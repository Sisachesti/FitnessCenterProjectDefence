using FitnessCenter.Services.Mapping;

namespace FitnessCenter.Web.ViewModels.Class
{
    using AutoMapper;
    using Data.Models;
    using System.Globalization;
    using static Common.EntityValidationConstants.Class;

    public class DeleteClassViewModel : IMapFrom<Class>, IHaveCustomMappings
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string StartingDate { get; set; } = null!;

        public int Duration { get; set; }

        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Class, DeleteClassViewModel>()
                .ForMember(d => d.StartingDate,
                    opt => opt.MapFrom(s => s.StartingDate.ToString(StartingDateFormat, CultureInfo.InvariantCulture)));
        }
    }
}
