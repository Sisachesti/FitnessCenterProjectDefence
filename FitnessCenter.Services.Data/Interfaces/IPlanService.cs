using FitnessCenter.Web.ViewModels.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Services.Data.Interfaces
{
    public interface IPlanService
    {
        Task<IEnumerable<ApplicationUserPlansViewModel>> GetUserPlansByUserIdAsync(string userId);

        Task<bool> AddClassToUserPlansAsync(string? classId, string userId);

        Task<bool> RemoveClassFromUserPlansAsync(string? classId, string userId);
    }
}
