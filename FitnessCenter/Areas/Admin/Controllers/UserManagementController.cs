using Microsoft.AspNetCore.Mvc;
using FitnessCenter.Web.Controllers;
using FitnessCenter.Services.Data.Interfaces;
using FitnessCenter.Web.ViewModels.Admin.UserManagement;
using Microsoft.AspNetCore.Authorization;
using static FitnessCenter.Common.ApplicationConstants;

namespace FitnessCenter.Web.Areas.Admin.Controllers
{
    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
    public class UserManagementController : BaseController
    {
        private readonly IUserService userService;

        public UserManagementController(IUserService userService, IManagerService managerService)
            : base(managerService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllUsersViewModel> allUsers = await this.userService
                .GetAllUsersAsync();

            return this.View(allUsers);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            Guid userGuid = Guid.Empty;
            if (!this.IsGuidValid(userId, ref userGuid))
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool userExists = await this.userService
                .UserExistsByIdAsync(userGuid);
            if (!userExists)
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool assignResult = await this.userService
                .AssignUserToRoleAsync(userGuid, role);
            if (!assignResult)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string userId, string role)
        {
            Guid userGuid = Guid.Empty;
            if (!this.IsGuidValid(userId, ref userGuid))
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool userExists = await this.userService
                .UserExistsByIdAsync(userGuid);
            if (!userExists)
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool removeResult = await this.userService
                .RemoveUserRoleAsync(userGuid, role);
            if (!removeResult)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            Guid userGuid = Guid.Empty;
            if (!this.IsGuidValid(userId, ref userGuid))
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool userExists = await this.userService
                .UserExistsByIdAsync(userGuid);
            if (!userExists)
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool removeResult = await this.userService
                .DeleteUserAsync(userGuid);
            if (!removeResult)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(Index));
        }
    }
}
