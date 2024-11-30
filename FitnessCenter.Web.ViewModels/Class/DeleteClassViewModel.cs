using FitnessCenter.Services.Mapping;

namespace FitnessCenter.Web.ViewModels.Class
{
    using AutoMapper;
    using Data.Models;
    using static Common.EntityValidationConstants.Class;

    public class DeleteClassViewModel : IMapFrom<Class>, IHaveCustomMappings
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public DateTime StartingDate { get; set; }

        public int Duration { get; set; }

        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Class, EditClassFormModel>()
                .ForMember(d => d.StartingDate,
                    opt => opt.MapFrom(s => s.StartingDate.ToString(StartingDateFormat)));
        }
    }
}
