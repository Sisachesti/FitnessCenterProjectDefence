namespace FitnessCenter.Web.Controllers
{
    using FitnessCenter.Web.ViewModels.Gym;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.Class;
    using static Common.EntityValidationConstants.Class;

    public class ClassController : BaseController
    {
        private readonly IClassService classService;

        public ClassController(IClassService classService, IManagerService managerService)
            : base(managerService)
        {
            this.classService = classService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllClassesIndexViewModel> allClasses =
                await this.classService.GetAllClassesAsync();

            return this.View(allClasses);
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
        public async Task<IActionResult> Create(AddClassInputModel inputModel)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (!this.ModelState.IsValid)
            {
                // Render the same form with user entered values + model errors 
                return this.View(inputModel);
            }

            bool result = await this.classService.AddClassAsync(inputModel);
            if (result == false)
            {
                this.ModelState.AddModelError(nameof(inputModel.StartingDate),
                    String.Format("The Starting Date must be in the following format: {0}", StartingDateFormat));
                return this.View(inputModel);
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid classGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref classGuid);
            if (!isGuidValid)
            {
                // Invalid id format
                return this.RedirectToAction(nameof(Index));
            }

            ClassDetailsViewModel? classM = await this.classService
                .GetClassDetailsByIdAsync(classGuid);
            if (classM == null)
            {
                // Non-existing movie guid
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(classM);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddToProgram(string? id)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Guid classGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref classGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            AddClassToGymInputModel? viewModel = await this.classService
                .GetAddClassToGymInputModelByIdAsync(classGuid);
            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToProgram(AddClassToGymInputModel model)
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

            Guid classGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(model.Id, ref classGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool result = await this.classService
                .AddClassToGymsAsync(classGuid, model);
            if (result == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(Index), "Gym");
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

            Guid classGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref classGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            EditClassFormModel? formModel = await this.classService
                .GetEditClassFormModelByIdAsync(classGuid);
            if (formModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(formModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditClassFormModel formModel)
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

            bool isUpdated = await this.classService
                .EditClassAsync(formModel);

            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating the gym! Please contact administrator");
                return this.View(formModel);
            }

            return this.RedirectToAction(nameof(Details), new { id = formModel.Id });
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

            IEnumerable<AllClassesIndexViewModel> classes =
                await this.classService.GetAllClassesAsync();

            return this.View(classes);
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

            Guid classGuid = Guid.Empty;

            if (!this.IsGuidValid(id, ref classGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            DeleteClassViewModel? classToDeleteViewModel =
                await this.classService.GetClassForDeleteByIdAsync(classGuid);

            if (classToDeleteViewModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(classToDeleteViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SoftDeleteConfirmed(DeleteClassViewModel gym)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Guid classGuid = Guid.Empty;
            if (!this.IsGuidValid(gym.Id, ref classGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            bool isDeleted = await this.classService
                .SoftDeleteClassAsync(classGuid);

            if (!isDeleted)
            {
                TempData["ErrorMessage"] =
                    "Unexpected error occurred while trying to delete the class! Please contact system administrator!";
                return this.RedirectToAction(nameof(Delete), new { id = gym.Id });
            }

            return this.RedirectToAction(nameof(Manage));
        }
    }
}