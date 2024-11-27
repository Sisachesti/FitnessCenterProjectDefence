using AutoMapper;
using FitnessCenter.Services.Mapping;

namespace FitnessCenter.Web.ViewModels.Subscribtion
{
    using Data.Models;
    public class UserSubscribtionViewModel : IMapFrom<Subscribtion>, IHaveCustomMappings
    {
        public string Id { get; set; } = null!;

        public string ClassTitle { get; set; } = null!;

        public string GymName { get; set; } = null!;

        public string GymLocation { get; set; } = null!;

        public string Price { get; set; } = null!;


        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Subscribtion, UserSubscribtionViewModel>()
                .ForMember(d => d.ClassTitle,
                    opt => opt.MapFrom(s => s.Class.Title))
                .ForMember(d => d.GymName, opt => opt.MapFrom(s => s.Gym.Name))
                .ForMember(d => d.GymLocation, opt => opt.MapFrom(s => s.Gym.Location))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price.ToString("F2")));
        }
    }
}
