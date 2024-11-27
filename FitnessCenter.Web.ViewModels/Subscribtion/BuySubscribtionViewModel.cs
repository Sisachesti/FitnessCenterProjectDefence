namespace FitnessCenter.Web.ViewModels.Subscribtion
{
    using FitnessCenter.Services.Mapping;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using static Common.EntityValidationConstants.Subscribtion;
    using static Common.EntityValidationMessages.Subscribtion;

    public class BuySubscribtionViewModel : IMapTo<Subscribtion>
    {
        [Required]
        public string GymId { get; set; } = null!;

        [Required]
        public string ClassId { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [Range(typeof(decimal), PriceMinValue, PriceMaxValue, ErrorMessage = IncorrectPriceMessage)]
        public decimal Price { get; set; }

        [Range(CountMinValue, CountMaxValue, ErrorMessage = IncorrectCountMessage)]
        public int Count { get; set; }
    }
}