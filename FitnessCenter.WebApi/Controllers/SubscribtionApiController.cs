using FitnessCenter.Services.Data.Interfaces;
using FitnessCenter.Web.ViewModels.Gym;
using FitnessCenter.Web.ViewModels.GymClass;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.WebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    //using Web.Infrastructure.Attributes;

    [ApiController]
    [Route("[controller]/")]
    public class SubscribtionApiController : ControllerBase
    {
        private readonly IGymService gymService;
        private readonly ISubscribtionService subscribtionService;
        private readonly IClassService classService;

        public SubscribtionApiController(IGymService gymService,
            ISubscribtionService subscribtionService, IClassService classService)
        {
            this.gymService = gymService;
            this.classService = classService;
            this.subscribtionService = subscribtionService;
        }

        [HttpGet("[action]/{id?}")]
        //[ManagerOnly]
        [ProducesResponseType(typeof(GymDetailsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClassesByGym(string? id)
        {
            Guid gymGuid = Guid.Empty;
            if (!this.IsGuidValid(id, ref gymGuid))
            {
                return this.BadRequest();
            }

            GymDetailsViewModel? viewModel = await this.gymService
                .GetGymDetailsByIdAsync(gymGuid);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.Ok(viewModel);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAvailableSubscribtions([FromBody] SetAvailableSubscribtionsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            bool isSuccess = await this.subscribtionService.SetAvailableSubscribtionsAsync(model);
            if (!isSuccess)
            {
                return this.BadRequest();
            }

            return this.Ok("Subscribtion availability updated successfully!");
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(AvailableSubscribtionsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSubscribtionsAvailability([FromBody] GetAvailableSubscribtionsViewModel buySubscribtionsModel)
        {
            Guid gymGuid = Guid.Empty;
            if (!this.IsGuidValid(buySubscribtionsModel.GymId, ref gymGuid))
            {
                return this.BadRequest();
            }

            Guid classGuid = Guid.Empty;
            if (!this.IsGuidValid(buySubscribtionsModel.ClassId, ref classGuid))
            {
                return this.BadRequest();
            }

            AvailableSubscribtionsViewModel? availableSubscribtionsViewModel = await this.classService
                .GetAvailableSubscribtionsByIdAsync(gymGuid, classGuid);
            if (availableSubscribtionsViewModel == null)
            {
                return this.BadRequest();
            }

            return this.Ok(availableSubscribtionsViewModel);
        }

        protected bool IsGuidValid(string? id, ref Guid parsedGuid)
        {
            // Non-existing parameter in the URL
            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            // Invalid parameter in the URL
            bool isGuidValid = Guid.TryParse(id, out parsedGuid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }
    }
}