using FitnessCenter.Services.Mapping;

namespace FitnessCenter.Web.ViewModels.Class
{
    using AutoMapper;
    using Data.Models;

    public class GymClassViewModel : IMapFrom<Class>, IHaveCustomMappings
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int Duration { get; set; }

        public string Description { get; set; } = null!;

        public int AvailableSubscriptions { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Class, GymClassViewModel>()
                .ForMember(d => d.Description,
                    opt => opt.MapFrom(s => s.Description));
        }
    }
}
