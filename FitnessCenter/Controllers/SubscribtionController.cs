using FitnessCenter.Services.Data.Interfaces;
using FitnessCenter.Web.ViewModels.GymClass;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class SubscribtionController : BaseController
    {
        public SubscribtionController(IManagerService managerService)
            : base(managerService)
        {

        }

        [HttpPost]
        [Authorize]
        public IActionResult BuySubscribtions(AvailableSubscribtionsViewModel viewModel)
        {
            return View();
        }
    }
}
