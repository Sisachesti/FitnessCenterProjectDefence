namespace FitnessCenter.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using System.Collections.Generic;
    using ViewModels.Plans;
    using static Common.ErrorMessages.Plans;

    [Authorize]
    public class PlanController : BaseController
    {
        private readonly IPlanService planService;
        private readonly UserManager<ApplicationUser> userManager;

        public PlanController(IPlanService planService,
            IManagerService managerService, UserManager<ApplicationUser> userManager)
            : base(managerService)
        {
            this.planService = planService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = this.userManager.GetUserId(User)!;
            if (String.IsNullOrWhiteSpace(userId))
            {
                return this.RedirectToPage("/Identity/Account/Login");
            }

            IEnumerable<ApplicationUserPlansViewModel> plans =
                await this.planService
                    .GetUserPlansByUserIdAsync(userId);

            return View(plans);
        }

        [HttpPost]
        public async Task<IActionResult> AddToPlans(string? classId)
        {
            string userId = this.userManager.GetUserId(User)!;
            if (String.IsNullOrWhiteSpace(userId))
            {
                return this.RedirectToPage("/Identity/Account/Login");
            }

            bool result = await this.planService
                .AddClassToUserPlansAsync(classId, userId);

            if (result == false)
            {
                TempData[nameof(AddToPlansNotSuccessfullMessage)] = AddToPlansNotSuccessfullMessage;
                return this.RedirectToAction("Index", "Class");
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromPlans(string? classId)
        {
            string userId = this.userManager.GetUserId(User)!;
            if (String.IsNullOrWhiteSpace(userId))
            {
                return this.RedirectToPage("/Identity/Account/Login");
            }

            bool result = await this.planService
                .RemoveClassFromUserPlansAsync(classId, userId);
            if (result == false)
            {
                // TODO: Implement a way to transfer the Error Message to the View
                return this.RedirectToAction("Index", "Class");
            }

            return this.RedirectToAction(nameof(Index));
        }
    }
}