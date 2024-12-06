namespace FitnessCenter.Services.Data
{
    using FitnessCenter.Data.Models;
    using FitnessCenter.Data.Repository.Interfaces;
    using FitnessCenter.Services.Data.Interfaces;
    using FitnessCenter.Services.Mapping;
    using FitnessCenter.Web.ViewModels.Class;
    using FitnessCenter.Web.ViewModels.Gym;
    using FitnessCenter.Web.ViewModels.GymClass;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using static Common.ApplicationConstants;
    using static Common.EntityValidationConstants.Class;

    public class ClassService : BaseService, IClassService
    {
        private readonly IRepository<Class, Guid> classRepository;
        private readonly IRepository<Gym, Guid> gymRepository;
        private readonly IRepository<GymClass, object> gymClassRepository;

        public ClassService(IRepository<Class, Guid> classRepository,
            IRepository<Gym, Guid> gymRepository,
            IRepository<GymClass, object> gymClassRepository)
        {
            this.classRepository = classRepository;
            this.gymRepository = gymRepository;
            this.gymClassRepository = gymClassRepository;
        }

        public async Task<IEnumerable<AllClassesIndexViewModel>> GetAllClassesAsync(AllClassesSearchFilterViewModel inputModel)
        {
            IQueryable<Class> allClassesQuery = this.classRepository
                .GetAllAttached();

            if (!String.IsNullOrWhiteSpace(inputModel.SearchQuery))
            {
                allClassesQuery = allClassesQuery
                    .Where(m => m.Title.ToLower().Contains(inputModel.SearchQuery.ToLower()));
            }

            if (inputModel.CurrentPage.HasValue &&
                inputModel.EntitiesPerPage.HasValue)
            {
                allClassesQuery = allClassesQuery
                    .Skip(inputModel.EntitiesPerPage.Value * (inputModel.CurrentPage.Value - 1))
                    .Take(inputModel.EntitiesPerPage.Value);
            }

            return await allClassesQuery
                .To<AllClassesIndexViewModel>()
                .ToArrayAsync();
        }

        public async Task<bool> AddClassAsync(AddClassInputModel inputModel)
        {
            bool isStartingDateValid = DateTime
                .TryParseExact(inputModel.StartingDate, StartingDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime startingDate);

            if (!isStartingDateValid)
            {
                return false;
            }

            Class classM = new Class();

            AutoMapperConfig.MapperInstance.Map(inputModel, classM);

            classM.StartingDate = startingDate;

            await this.classRepository.AddAsync(classM);

            return true;
        }

        public async Task<ClassDetailsViewModel?> GetClassDetailsByIdAsync(Guid id)
        {
            Class? classM = await this.classRepository
                .GetByIdAsync(id);

            ClassDetailsViewModel? viewModel = new ClassDetailsViewModel();

            if (classM != null)
            {
                AutoMapperConfig.MapperInstance.Map(classM, viewModel);
            }

            return viewModel;
        }

        public async Task<AddClassToGymInputModel?> GetAddClassToGymInputModelByIdAsync(Guid id)
        {
            Class? classM = await this.classRepository
                .GetByIdAsync(id);

            AddClassToGymInputModel? viewModel = null;

            if (classM != null)
            {
                viewModel = new AddClassToGymInputModel()
                {
                    Id = id.ToString(),
                    Title = classM.Title,
                    Gyms = await this.gymRepository
                        .GetAllAttached()
                        .Include(g => g.GymClasses)
                        .ThenInclude(gc => gc.Class)
                        .Where(g => g.IsDeleted == false)
                        .Select(g => new GymCheckBoxItemInputModel()
                        {
                            Id = g.Id.ToString(),
                            Name = g.Name,
                            Location = g.Location,
                            IsSelected = g.GymClasses
                                .Any(gc => gc.Class.Id == id &&
                                           gc.IsDeleted == false)
                        })
                        .ToArrayAsync()
                };
            }

            return viewModel;
        }

        public async Task<bool> AddClassToGymsAsync(Guid classId, AddClassToGymInputModel model)
        {
            Class? classM = await this.classRepository
                .GetByIdAsync(classId);

            if (classM == null)
            {
                return false;
            }

            ICollection<GymClass> entitiesToAdd = new List<GymClass>();
            foreach (GymCheckBoxItemInputModel gymInputModel in model.Gyms)
            {
                Guid gymGuid = Guid.Empty;

                bool isGymGuidValid = this.IsGuidValid(gymInputModel.Id, ref gymGuid);
                if (!isGymGuidValid)
                {
                    return false;
                }

                Gym? gym = await this.gymRepository
                    .GetByIdAsync(gymGuid);

                if (gym == null || gym.IsDeleted)
                {
                    return false;
                }

                GymClass? gymClass = await this.gymClassRepository
                    .FirstOrDefaultAsync(cm => cm.ClassId == classId &&
                                                     cm.GymId == gymGuid);

                if (gymInputModel.IsSelected)
                {
                    if (gymClass == null)
                    {
                        entitiesToAdd.Add(new GymClass()
                        {
                            Gym = gym,
                            Class = classM
                        });
                    }
                    else
                    {
                        gymClass.IsDeleted = false;
                    }
                }
                else
                {
                    if (gymClass != null)
                    {
                        gymClass.IsDeleted = true;
                    }
                }
            }

            await this.gymClassRepository.AddRangeAsync(entitiesToAdd.ToArray());

            return true;
        }

        public async Task<EditClassFormModel?> GetEditClassFormModelByIdAsync(Guid id)
        {
            // TODO: Check soft delete
            EditClassFormModel? editClassFormModel = await this.classRepository
                .GetAllAttached()
                .Where(c => c.IsDeleted == false)
                .To<EditClassFormModel>()
                .FirstOrDefaultAsync(c => c.Id.ToLower() == id.ToString().ToLower());

            if (editClassFormModel != null &&
                editClassFormModel.ImageUrl.Equals(NoImageUrl))
            {
                editClassFormModel.ImageUrl = "No image";
            }

            return editClassFormModel;
        }

        public async Task<bool> EditClassAsync(EditClassFormModel formModel)
        {
            Guid classGuid = Guid.Empty;
            if (!this.IsGuidValid(formModel.Id, ref classGuid))
            {
                return false;
            }

            Class edittedClass = AutoMapperConfig.MapperInstance.Map<Class>(formModel);
            edittedClass.Id = classGuid;

            bool isStartingDateValid = DateTime.TryParseExact(formModel.StartingDate, StartingDateFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startingDate);

            if (!isStartingDateValid)
            {
                return false;
            }

            edittedClass.StartingDate = startingDate;

            if (formModel.ImageUrl == null ||
                formModel.ImageUrl.Equals("No image"))
            {
                edittedClass.ImageUrl = NoImageUrl;
            }

            return await this.classRepository.UpdateAsync(edittedClass);
        }

        public async Task<AvailableSubscribtionsViewModel?> GetAvailableSubscribtionsByIdAsync(Guid gymId, Guid classId)
        {
            GymClass? gymClass = await this.gymClassRepository
                .FirstOrDefaultAsync(cm => cm.ClassId == classId &&
                                                     cm.GymId == gymId);

            AvailableSubscribtionsViewModel availableSubscribtionsViewModel = null;
            if (gymClass != null)
            {
                availableSubscribtionsViewModel = new AvailableSubscribtionsViewModel()
                {
                    GymId = gymId.ToString(),
                    ClassId = classId.ToString(),
                    Quantity = 0,
                    AvailableSubscribtions = gymClass.AvailableSubscribtions
                };
            }

            return availableSubscribtionsViewModel;
        }

        public async Task<DeleteClassViewModel?> GetClassForDeleteByIdAsync(Guid id)
        {
            DeleteClassViewModel? classToDelete = await this.classRepository
                .GetAllAttached()
                .Where(c => c.IsDeleted == false)
                .To<DeleteClassViewModel>()
                .FirstOrDefaultAsync(c => c.Id.ToLower() == id.ToString().ToLower());

            return classToDelete;
        }

        public async Task<bool> SoftDeleteClassAsync(Guid id)
        {
            Class? classToDelete = await this.classRepository
                .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToString().ToLower());

            if (classRepository == null)
            {
                return false;
            }

            classToDelete.IsDeleted = true;
            return await this.classRepository.UpdateAsync(classToDelete);
        }

        public async Task<int> GetClassesCountByFilterAsync(AllClassesSearchFilterViewModel inputModel)
        {
            AllClassesSearchFilterViewModel inputModelCopy = new AllClassesSearchFilterViewModel()
            {
                CurrentPage = null,
                EntitiesPerPage = null,
                SearchQuery = inputModel.SearchQuery
            };

            int classesCount = (await this.GetAllClassesAsync(inputModelCopy))
                .Count();
            return classesCount;
        }
    }
}
