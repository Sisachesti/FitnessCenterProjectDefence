namespace FitnessCenter.Web.ViewModels.GymClass
{
    public class AvailableSubscribtionsViewModel
    {
        public string GymId { get; set; } = null!;

        public string ClassId { get; set; } = null!;

        public int Quantity { get; set; }

        public int AvailableSubscribtions { get; set; }
    }
}

