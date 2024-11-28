using FitnessCenter.Services.Data.Interfaces;
using FitnessCenter.Web.ViewModels.Admin.UserManagement;

namespace FitnessCenter.Services.Data
{
    public class UserService : BaseService, IUserService
    {
        public Task<bool> AssignUserToRoleAsync(Guid userId, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUserRoleAsync(Guid userId, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExistsByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
