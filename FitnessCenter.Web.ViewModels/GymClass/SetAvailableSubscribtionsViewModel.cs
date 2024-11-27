using System.ComponentModel.DataAnnotations;
using static FitnessCenter.Common.EntityValidationMessages.GymClass;
using static FitnessCenter.Common.EntityValidationConstants.GymClass;
using FitnessCenter.Services.Mapping;

namespace FitnessCenter.Web.ViewModels.GymClass
{
    using Data.Models;
    public class SetAvailableSubscribtionsViewModel : IMapTo<GymClass>
    {
        [Required]
        public string CinemaId { get; set; } = null!;

        [Required]
        public string MovieId { get; set; } = null!;

        [Required(ErrorMessage = AvailableSubscribtionsRequiredMessage)]
        [Range(AvailableSubscribtionsMinValue, AvailableSubscribtionsMaxValue, ErrorMessage = AvailableSubscribtionsRangeMessage)]
        public int AvailableTickets { get; set; }
    }
}
