using FitnessCenter.Services.Mapping;
using System.ComponentModel.DataAnnotations;
using static FitnessCenter.Common.EntityValidationConstants.GymClass;
using static FitnessCenter.Common.EntityValidationMessages.GymClass;

namespace FitnessCenter.Web.ViewModels.GymClass
{
    using AutoMapper;
    using Data.Models;

    public class SetAvailableSubscribtionsViewModel : IMapTo<GymClass>
    {
        [Required]
        public string GymId { get; set; } = null!;

        [Required]
        public string ClassId { get; set; } = null!;

        [Required(ErrorMessage = AvailableSubscribtionsRequiredMessage)]
        [Range(AvailableSubscribtionsMinValue, AvailableSubscribtionsMaxValue, ErrorMessage = AvailableSubscribtionsRangeMessage)]
        public int AvailableSubscribtions { get; set; }
    }
}
