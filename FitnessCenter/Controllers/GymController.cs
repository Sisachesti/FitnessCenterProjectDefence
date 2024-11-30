namespace FitnessCenter.Web.Controllers
{
    using FitnessCenter.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Gym;

    public class GymController : BaseController
    {
        private readonly IGymService gymService;

        public GymController(IGymService gymService, IManagerService managerService)
            : base(managerService)
        {
            this.gymService = gymService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<GymIndexViewModel> gyms =
                await this.gymService.IndexGetAllOrderedByLocationAsync();

            return this.View(gyms);
        }

        [HttpGet]
        [Authorize]
#pragma warning disable CS1998
        public async Task<IActionResult> Create()
#pragma warning restore CS1998
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AddGymFormModel model)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.gymService.AddGymAsync(model);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid gymGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref gymGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            GymDetailsViewModel? viewModel = await this.gymService
                .GetGymDetailsByIdAsync(gymGuid);

            // Invalid(non-existing) GUID in the URL
            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            await this.AppendUserCookieAsync();

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Manage()
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            IEnumerable<GymIndexViewModel> gyms =
                await this.gymService.IndexGetAllOrderedByLocationAsync();

            return this.View(gyms);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string? id)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                // TODO: Implement notifications for error and warning messages!
                return this.RedirectToAction(nameof(Index));
            }

            Guid gymGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref gymGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            EditGymFormModel? formModel = await this.gymService
                .GetGymForEditByIdAsync(gymGuid);
            if (formModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(formModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditGymFormModel formModel)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool isUpdated = await this.gymService
                .EditGymAsync(formModel);
            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating the gym! Please contact administrator");
                return this.View(formModel);
            }

            return this.RedirectToAction(nameof(Details), "Gym", new { id = formModel.Id });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(string? id)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Guid gymGuid = Guid.Empty;
            if (!this.IsGuidValid(id, ref gymGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            DeleteGymViewModel? gymToDeleteViewModel =
                await this.gymService.GetGymForDeleteByIdAsync(gymGuid);

            if (gymToDeleteViewModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(gymToDeleteViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SoftDeleteConfirmed(DeleteGymViewModel gym)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Guid gymGuid = Guid.Empty;
            if (!this.IsGuidValid(gym.Id, ref gymGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            bool isDeleted = await this.gymService
                .SoftDeleteGymAsync(gymGuid);

            if (!isDeleted)
            {
                TempData["ErrorMessage"] =
                    "Unexpected error occurred while trying to delete the gym! Please contact system administrator!";
                return this.RedirectToAction(nameof(Delete), new { id = gym.Id });
            }

            return this.RedirectToAction(nameof(Manage));
        }
    }
}