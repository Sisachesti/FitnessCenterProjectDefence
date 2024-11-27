using FitnessCenter.Data.Models;
using FitnessCenter.Web.ViewModels.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Web.ViewModels.Gym
{
    public class GymDetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public IEnumerable<GymClassViewModel> Classes { get; set; }
            = new HashSet<GymClassViewModel>();
    }
}
