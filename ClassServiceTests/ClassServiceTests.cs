using FitnessCenter.Web.ViewModels.Gym;
using System.Globalization;
using System.Linq.Expressions;

namespace FitnessCenter.Services.Tests
{
    using FitnessCenter.Data.Models;
    using FitnessCenter.Data.Repository.Interfaces;
    using FitnessCenter.Models;
    using FitnessCenter.Services.Data;
    using FitnessCenter.Services.Data.Interfaces;
    using FitnessCenter.Services.Mapping;
    using FitnessCenter.Web.ViewModels.Class;
    using FitnessCenter.Web.ViewModels.GymClass;
    using MockQueryable;
    using Moq;
    using System.Collections.Generic;
    using static Common.ApplicationConstants;
    using static Common.EntityValidationConstants.Class;

    [TestFixture]
    public class Tests
    {

        private IList<Class> classesData = new List<Class>()
        {
                new Class()
                {
                    Id = Guid.Parse("95766741-DE9A-4380-9D0A-3E2B22099004"),
                    Title = "Yoga Class",
                    StartingDate = new DateTime(2024, 12, 16, 12, 00, 00),
                    Duration = 90,
                    Description = "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.",
                    ImageUrl = "https://www.everydayyoga.com/cdn/shop/articles/yoga_1024x1024.jpg?v=1703853908"
                },
                new Class()
                {
                    Id = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE"),
                    Title = "Full-Body Strength Training",
                    StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                    Duration = 70,
                    Description = "A well-rounded workout targeting all major muscle groups. Incorporates free weights, resistance machines, and bodyweight exercises to improve overall strength, endurance, and stability. Suitable for all levels, with modifications available.",
                    ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
                },
                new Class()
                {
                    Id = Guid.Parse("7206E644-4A54-4A55-B1D9-3A9C6F814D5C"),
                    Title = "Basketball Training",
                    StartingDate = new DateTime(2024, 12, 13, 16, 00, 00),
                    Duration = 120,
                    Description = "A basketball training program is a specialized practice designed to improve an individual's skillset. It typically involves drills and exercises focused on developing specific areas, such as ball handling, shooting, passing, and agility.",
                    ImageUrl = "https://revolutionbasketballtraining.com/wp-content/uploads/2024/06/Personal-Basketball-Training-Can-Elevate-Your-Game-1.png"
                }
        };

        private Mock<IRepository<Class, Guid>> classRepository;
        private Mock<IRepository<Gym, Guid>> gymRepository;
        private Mock<IRepository<GymClass, object>> gymClassRepository;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);
        }

        [SetUp]
        public void Setup()
        {
            this.classRepository = new Mock<IRepository<Class, Guid>>();
            this.gymRepository = new Mock<IRepository<Gym, Guid>>();
            this.gymClassRepository = new Mock<IRepository<GymClass, object>>();
        }

        [Test]
        public async Task GetAllClassesNoFilterPositive()
        {
            IQueryable<Class> classesMockQueryable = classesData.BuildMock();
            this.classRepository
                .Setup(r => r.GetAllAttached())
                .Returns(classesMockQueryable);

            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            IEnumerable<AllClassesIndexViewModel> allClassesActual = await classService
                .GetAllClassesAsync(new AllClassesSearchFilterViewModel());

            Assert.IsNotNull(allClassesActual);
            Assert.AreEqual(this.classesData.Count(), allClassesActual.Count());

            allClassesActual = allClassesActual
                .OrderBy(m => m.Id)
                .ToList();

            int i = 0;
            foreach (AllClassesIndexViewModel returnedClass in allClassesActual)
            {
                Assert.AreEqual(this.classesData.OrderBy(m => m.Id).ToList()[i++].Id.ToString(), returnedClass.Id);
            }
        }

        [Test]
        [TestCase("Yo")]
        [TestCase("yo")]
        public async Task GetAllClassesSearchQueryPositive(string searchQuery)
        {
            int expectedClassesCount = 1;
            string expectedClassId = "95766741-DE9A-4380-9D0A-3E2B22099004";

            IQueryable<Class> classesMockQueryable = classesData.BuildMock();
            this.classRepository
                .Setup(r => r.GetAllAttached())
                .Returns(classesMockQueryable);

            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            IEnumerable<AllClassesIndexViewModel> allClassesActual = await classService
                .GetAllClassesAsync(new AllClassesSearchFilterViewModel()
                {
                    SearchQuery = "Yo"
                });

            Assert.IsNotNull(allClassesActual);
            Assert.AreEqual(expectedClassesCount, allClassesActual.Count());
            Assert.AreEqual(expectedClassId.ToLower(), allClassesActual.First().Id.ToLower());
        }

        [Test]
        public async Task GetAllClassesNullFilterNegative()
        {
            IQueryable<Class> classesMockQueryable = classesData.BuildMock();
            this.classRepository
                .Setup(r => r.GetAllAttached())
                .Returns(classesMockQueryable);

            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                IEnumerable<AllClassesIndexViewModel> allClassesActual = await classService
                    .GetAllClassesAsync(null);
            });
        }

        [Test]
        public async Task AddNewClassPositive()
        {
            IQueryable<Class> classesMockQueryable = classesData.BuildMock();
            this.classRepository
                .Setup(r => r.GetAllAttached())
                .Returns(classesMockQueryable);

            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            bool isClassAdded = await classService
                .AddClassAsync(new AddClassInputModel()
                {
                    Title = "Title",
                    StartingDate = "12/19 12:00",
                    Duration = 120,
                    Description = "Small Description about the Class",
                    ImageUrl = null
                });

            Assert.IsTrue(isClassAdded);
        }

        [Test]
        public async Task AddNewClassWrongDateFormatNegative()
        {
            IQueryable<Class> classesMockQueryable = classesData.BuildMock();
            this.classRepository
                .Setup(r => r.GetAllAttached())
                .Returns(classesMockQueryable);

            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            bool isClassAdded = await classService
                .AddClassAsync(new AddClassInputModel()
                {
                    Title = "Title",
                    StartingDate = "12.19.2024 12:00",
                    Duration = 120,
                    Description = "Small Description about the Class",
                    ImageUrl = null
                });

            Assert.IsFalse(isClassAdded);
        }

        [Test]
        public async Task AddNewClassNullObjectNegative()
        {
            IQueryable<Class> classesMockQueryable = classesData.BuildMock();
            this.classRepository
                .Setup(r => r.GetAllAttached())
                .Returns(classesMockQueryable);

            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            bool isClassAdded = await classService
                .AddClassAsync(new AddClassInputModel());

            Assert.IsFalse(isClassAdded);
        }

        [Test]
        public async Task GetClassDetailsByIdPositive()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            var classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");

            var mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);

            string inputClassId = classId.ToString();

            ClassDetailsViewModel? result = await classService.GetClassDetailsByIdAsync(Guid.Parse(inputClassId));

            Assert.NotNull(result);
            Assert.AreEqual(inputClassId.ToLower(), result.Id.ToLower());
            Assert.AreEqual("Full-Body Strength Training", result.Title);
            Assert.AreEqual("70", result.Duration);
            Assert.AreEqual("A well-rounded workout targeting all major muscle groups.", result.Description);
        }

        [Test]
        public async Task GetClassDetailsByIdReturnNullNegative()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            ClassDetailsViewModel classDetails = await classService
                    .GetClassDetailsByIdAsync(Guid.Empty);

            Assert.IsNull(classDetails.Id);
            Assert.IsNull(classDetails.Title);
            Assert.IsNull(classDetails.StartingDate);
            Assert.IsNull(classDetails.Description);
            Assert.IsNull(classDetails.Duration);
            Assert.IsNull(classDetails.ImageUrl);
        }

        [Test]
        public async Task GetClassDetailsByIdReturnNullWrongIdNegative()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid searchedGuid = Guid.Parse("991F0BDA-3903-4A6E-86EE-3EA157ED96B2");

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");

            Class mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);

            ClassDetailsViewModel? classDetails = await classService.GetClassDetailsByIdAsync(searchedGuid);

            Assert.IsNull(classDetails.Id);
            Assert.IsNull(classDetails.Title);
            Assert.IsNull(classDetails.StartingDate);
            Assert.IsNull(classDetails.Description);
            Assert.IsNull(classDetails.Duration);
            Assert.IsNull(classDetails.ImageUrl);
        }

        [Test]
        public async Task GetAddClassToGymInputModelByIdPositive()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");
            Guid gymId = Guid.Parse("DA07CD2D-59B2-4572-A1EF-19BBBFDF4984");

            var mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };
            var mockGymClasses = new List<GymClass>
            {
                new GymClass
                {
                    GymId = gymId,
                    ClassId = classId,
                    Class = mockClass,
                    IsDeleted = false
                }
            };
            var mockGym = new Gym()
            {
                Id = gymId,
                Name = "Gladiator",
                Location = "Yambol",
                IsDeleted = false,
                GymClasses = mockGymClasses
            };

            var gyms = new List<Gym>(){ mockGym }.AsQueryable();

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);
            gymRepository.Setup(r => r.GetAllAttached()).Returns(gyms.BuildMock());

            AddClassToGymInputModel? result = await classService
                .GetAddClassToGymInputModelByIdAsync(classId);

            Assert.NotNull(result);
            Assert.AreEqual(classId.ToString(), result.Id);
            Assert.AreEqual("Full-Body Strength Training", result.Title);
            Assert.NotNull(result.Gyms);

            var gymCheckBox = result.Gyms.FirstOrDefault();
            Assert.NotNull(gymCheckBox);
            Assert.AreEqual(gymId.ToString(), gymCheckBox.Id);
            Assert.AreEqual("Gladiator", gymCheckBox.Name);
            Assert.AreEqual("Yambol", gymCheckBox.Location);
            Assert.True(gymCheckBox.IsSelected);
        }

        [Test]
        public async Task GetAddClassToGymInputModelByIdNotSelectedNoGymClassesLinkedPositive()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");
            Guid gymId = Guid.Parse("DA07CD2D-59B2-4572-A1EF-19BBBFDF4984");

            var mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };
            var mockGymClasses = new List<GymClass>
            {
                new GymClass
                {
                    GymId = gymId,
                    ClassId = classId,
                    Class = mockClass,
                    IsDeleted = false
                }
            };
            var mockGym = new Gym()
            {
                Id = gymId,
                Name = "Gladiator",
                Location = "Yambol",
                IsDeleted = false,
                GymClasses = new List<GymClass>()
            };

            var gyms = new List<Gym>() { mockGym }.AsQueryable();

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);
            gymRepository.Setup(r => r.GetAllAttached()).Returns(gyms.BuildMock());

            AddClassToGymInputModel? result = await classService
                .GetAddClassToGymInputModelByIdAsync(classId);

            Assert.NotNull(result);
            Assert.AreEqual(classId.ToString(), result.Id);
            Assert.AreEqual("Full-Body Strength Training", result.Title);
            Assert.NotNull(result.Gyms);

            var gymCheckBox = result.Gyms.FirstOrDefault();
            Assert.NotNull(gymCheckBox);
            Assert.AreEqual(gymId.ToString(), gymCheckBox.Id);
            Assert.AreEqual("Gladiator", gymCheckBox.Name);
            Assert.AreEqual("Yambol", gymCheckBox.Location);
            Assert.False(gymCheckBox.IsSelected);
        }

        [Test]
        public async Task GetAddClassToGymInputModelByIdNotSelectedGymDeletedPositive()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");
            Guid gymId = Guid.Parse("DA07CD2D-59B2-4572-A1EF-19BBBFDF4984");

            var mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };
            var mockGymClasses = new List<GymClass>
            {
                new GymClass
                {
                    GymId = gymId,
                    ClassId = classId,
                    Class = mockClass,
                    IsDeleted = false
                }
            };
            var mockGym = new Gym()
            {
                Id = gymId,
                Name = "Gladiator",
                Location = "Yambol",
                IsDeleted = true
            };

            var gyms = new List<Gym>() { mockGym }.AsQueryable();

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);
            gymRepository.Setup(r => r.GetAllAttached()).Returns(gyms.BuildMock());

            AddClassToGymInputModel? result = await classService
                .GetAddClassToGymInputModelByIdAsync(classId);

            Assert.NotNull(result);
            Assert.AreEqual(classId.ToString(), result.Id);
            Assert.AreEqual("Full-Body Strength Training", result.Title);
            Assert.NotNull(result.Gyms);

            var gymCheckBox = result.Gyms.FirstOrDefault();
            Assert.Null(gymCheckBox);
        }

        [Test]
        public async Task GetAddClassToGymInputModelByIdClassIsNullNegative()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            AddClassToGymInputModel? result = await classService
                .GetAddClassToGymInputModelByIdAsync(Guid.Empty);

            Assert.Null(result);
        }

        [Test]
        public async Task AddClassToGyms_SelectedFoundGymClassPositive()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");
            Guid gymId = Guid.Parse("DA07CD2D-59B2-4572-A1EF-19BBBFDF4984");

            Class mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };
            Gym mockGym = new Gym
            {
                Id = gymId,
                Name = "Gladiator",
                Location = "Yambol",
                IsDeleted = false
            };
            GymClass mockGymClass = new GymClass
            {
                ClassId = classId,
                Class = mockClass,
                GymId = gymId,
                Gym = mockGym,
                IsDeleted = true
            };
            AddClassToGymInputModel mockInputModel = new AddClassToGymInputModel
            {
                Id = classId.ToString(),
                Title = "Full-Body Strength Training",
                Gyms = new[]
                {
                    new GymCheckBoxItemInputModel
                    {
                        Id = gymId.ToString(),
                        Name = "Gladiator",
                        Location = "Yambol",
                        IsSelected = true
                    }
                }
            };

            ICollection<GymClass> mockList = new List<GymClass>(){mockGymClass};

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);
            gymRepository.Setup(r => r.GetByIdAsync(gymId)).ReturnsAsync(mockGym);
            gymClassRepository.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<GymClass, bool>>>()))
                .ReturnsAsync(mockGymClass);
            await gymClassRepository.Object.AddRangeAsync(mockList.ToArray());

            var gymClass = await gymClassRepository.Object.FirstOrDefaultAsync(gc => gc.ClassId == classId && gc.GymId == gymId);

            bool result = await classService.AddClassToGymsAsync(classId, mockInputModel);

            Assert.IsTrue(result);
            Assert.IsNotNull(gymClass);
            Assert.IsFalse(gymClass.IsDeleted);
            gymClassRepository.Verify(repo => repo.AddRangeAsync(It.Is<GymClass[]>(entities => entities.Length == 0)), Times.Once);
        }

        [Test]
        public async Task AddClassToGyms_SelectedNotFoundGymClassPositive()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");
            Guid gymId = Guid.Parse("DA07CD2D-59B2-4572-A1EF-19BBBFDF4984");

            Class mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };
            Gym mockGym = new Gym
            {
                Id = gymId,
                Name = "Gladiator",
                Location = "Yambol",
                IsDeleted = false
            };
            GymClass mockGymClass = null;
            AddClassToGymInputModel mockInputModel = new AddClassToGymInputModel
            {
                Id = classId.ToString(),
                Title = "Full-Body Strength Training",
                Gyms = new[]
                {
                    new GymCheckBoxItemInputModel
                    {
                        Id = gymId.ToString(),
                        Name = "Gladiator",
                        Location = "Yambol",
                        IsSelected = true
                    }
                }
            };

            var mockList = new List<GymClass>();

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);
            gymRepository.Setup(r => r.GetByIdAsync(gymId)).ReturnsAsync(mockGym);
            gymClassRepository.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<GymClass, bool>>>()))
                .ReturnsAsync(mockGymClass);
            await gymClassRepository.Object.AddRangeAsync(mockList.ToArray());

            mockList.Add(new GymClass
            {
                Gym = mockGym,
                Class = mockClass
            });

            bool result = await classService.AddClassToGymsAsync(classId, mockInputModel);


            Assert.True(result);
            gymClassRepository.Verify(r => r.AddRangeAsync(It.Is<GymClass[]>(entities =>
                entities.Length == mockList.ToArray().Count() &&
                entities[0].ClassId == mockList.ToArray()[0].ClassId &&
                entities[0].GymId == mockList.ToArray()[0].GymId)), Times.Once);
            Assert.That(1 ,Is.EqualTo(mockList.Count));

            var addedEntity = mockList[0];
            Assert.NotNull(addedEntity);
            Assert.AreEqual(mockGym, addedEntity.Gym);
            Assert.AreEqual(mockClass, addedEntity.Class);
        }

        [Test]
        public async Task AddClassToGyms_NotSelectedFoundGymClassPositive()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");
            Guid gymId = Guid.Parse("DA07CD2D-59B2-4572-A1EF-19BBBFDF4984");

            Class mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };
            Gym mockGym = new Gym
            {
                Id = gymId,
                Name = "Gladiator",
                Location = "Yambol",
                IsDeleted = false
            };
            GymClass mockGymClass = new GymClass
            {
                ClassId = classId,
                Class = mockClass,
                GymId = gymId,
                Gym = mockGym,
                IsDeleted = true
            };
            AddClassToGymInputModel mockInputModel = new AddClassToGymInputModel
            {
                Id = classId.ToString(),
                Title = "Full-Body Strength Training",
                Gyms = new[]
                {
                    new GymCheckBoxItemInputModel
                    {
                        Id = gymId.ToString(),
                        Name = "Gladiator",
                        Location = "Yambol",
                        IsSelected = false
                    }
                }
            };
            ICollection<GymClass> mockList = new List<GymClass>() { mockGymClass };

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);
            gymRepository.Setup(r => r.GetByIdAsync(gymId)).ReturnsAsync(mockGym);
            gymClassRepository.Setup(r => r.FirstOrDefaultAsync(It.IsAny<Expression<Func<GymClass, bool>>>()))
                .ReturnsAsync(mockGymClass);

            await gymClassRepository.Object.AddRangeAsync(mockList.ToArray());

            var gymClass = await gymClassRepository.Object.FirstOrDefaultAsync(gc => gc.ClassId == classId && gc.GymId == gymId);

            bool result = await classService.AddClassToGymsAsync(classId, mockInputModel);

            Assert.IsTrue(result);
            Assert.IsNotNull(gymClass);
            gymClassRepository.Verify(r => r.AddRangeAsync(It.Is<GymClass[]>(entities => entities.Length == 0)), Times.Once);
        }

        [Test]
        public async Task AddClassToGyms_NotSelectedNoGymClassPositive()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");
            Guid gymId = Guid.Parse("DA07CD2D-59B2-4572-A1EF-19BBBFDF4984");

            Class mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };
            Gym mockGym = new Gym
            {
                Id = gymId,
                Name = "Gladiator",
                Location = "Yambol",
                IsDeleted = false
            };
            GymClass mockGymClass = null;
            AddClassToGymInputModel mockInputModel = new AddClassToGymInputModel
            {
                Id = classId.ToString(),
                Title = "Full-Body Strength Training",
                Gyms = new[]
                {
                    new GymCheckBoxItemInputModel
                    {
                        Id = gymId.ToString(),
                        Name = "Gladiator",
                        Location = "Yambol",
                        IsSelected = false
                    }
                }
            };

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);
            gymRepository.Setup(r => r.GetByIdAsync(gymId)).ReturnsAsync(mockGym);
            gymClassRepository.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<GymClass, bool>>>()))
                .ReturnsAsync(mockGymClass);

            var gymClass = await gymClassRepository.Object.FirstOrDefaultAsync(gc => gc.ClassId == classId && gc.GymId == gymId);

            bool result = await classService.AddClassToGymsAsync(classId, mockInputModel);

            Assert.IsNull(gymClass);
            Assert.True(result);
            gymClassRepository.Verify(r => r.AddRangeAsync(It.Is<GymClass[]>(entities => entities.Length == 0)), Times.Once);
        }

        [Test]
        public async Task AddClassToGyms_NullClassNegative()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");

            AddClassToGymInputModel inputModel = null;
            Class mockClass = null;

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);

            var classResult = await classRepository.Object.GetByIdAsync(classId);

            bool result = await classService.AddClassToGymsAsync(classId, inputModel);

            Assert.False(result);
            Assert.IsNull(classResult);
        }

        [Test]
        public async Task AddClassToGyms_GymGuidNotValidNegative()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");
            string gymId = "0000";

            Class mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };
            AddClassToGymInputModel mockInputModel = new AddClassToGymInputModel
            {
                Id = classId.ToString(),
                Title = "Full-Body Strength Training",
                Gyms = new[]
                {
                    new GymCheckBoxItemInputModel
                    {
                        Id = gymId.ToString(),
                        Name = "Gladiator",
                        Location = "Yambol",
                        IsSelected = false
                    }
                }
            };

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);

            Guid outputGuid = Guid.Empty;

            bool validGuid = Guid.TryParse(gymId, out outputGuid);

            bool result = await classService.AddClassToGymsAsync(classId, mockInputModel);

            Assert.False(result);
            Assert.False(validGuid);
        }

        [Test]
        public async Task AddClassToGyms_GymNotFoundNegative()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");
            Guid gymId = Guid.Parse("DA07CD2D-59B2-4572-A1EF-19BBBFDF4984");

            Class mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };
            Gym mockGym = null;
            GymClass mockGymClass = new GymClass
            {
                ClassId = classId,
                GymId = gymId,
                Class = mockClass,
                Gym = mockGym,
                IsDeleted = false
            };
            AddClassToGymInputModel mockInputModel = new AddClassToGymInputModel
            {
                Id = classId.ToString(),
                Title = "Full-Body Strength Training",
                Gyms = new[]
                {
                    new GymCheckBoxItemInputModel
                    {
                        Id = gymId.ToString(),
                        Name = "Gladiator",
                        Location = "Yambol",
                        IsSelected = false
                    }
                }
            };

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);
            gymRepository.Setup(r => r.GetByIdAsync(gymId)).ReturnsAsync(mockGym);

            bool result = await classService.AddClassToGymsAsync(classId, mockInputModel);

            Assert.False(result);
            Assert.IsNull(mockGym);
        }

        [Test]
        public async Task AddClassToGyms_GymDeletedNegative()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");
            Guid gymId = Guid.Parse("DA07CD2D-59B2-4572-A1EF-19BBBFDF4984");

            Class mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };
            Gym mockGym = new Gym
            {
                Id = gymId,
                Name = "Gladiator",
                Location = "Yambol",
                IsDeleted = true
            };
            GymClass mockGymClass = new GymClass
            {
                ClassId = classId,
                GymId = gymId,
                Class = mockClass,
                Gym = mockGym,
                IsDeleted = false
            };
            AddClassToGymInputModel mockInputModel = new AddClassToGymInputModel
            {
                Id = classId.ToString(),
                Title = "Full-Body Strength Training",
                Gyms = new[]
                {
                    new GymCheckBoxItemInputModel
                    {
                        Id = gymId.ToString(),
                        Name = "Gladiator",
                        Location = "Yambol",
                        IsSelected = false
                    }
                }
            };

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);
            gymRepository.Setup(r => r.GetByIdAsync(gymId)).ReturnsAsync(mockGym);

            bool result = await classService.AddClassToGymsAsync(classId, mockInputModel);

            Assert.False(result);
            Assert.True(mockGym.IsDeleted);
        }

        [Test]
        public async Task EditClassClassGuidNotValidNegative()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            string classGuid = "0000";

            EditClassFormModel formModel = new EditClassFormModel()
            {
                Id = classGuid,
            };

            bool result = await classService.EditClassAsync(formModel);

            Assert.False(result);
        }

        [Test]
        public async Task EditClassClassStartingDateNotValidNegative()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classGuid = Guid.Parse("95766741-DE9A-4380-9D0A-3E2B22099004");

            var formModel = new EditClassFormModel()
            {
                Id = classGuid.ToString(),
                Title = "Yoga Class",
                StartingDate = new DateTime().ToString(),
                Duration = 90,
                Description =
                    "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.",
                ImageUrl = "https://www.everydayyoga.com/cdn/shop/articles/yoga_1024x1024.jpg?v=1703853908"
            };

            bool result = await classService.EditClassAsync(formModel);

            Assert.False(result);
        }

        [Test]
        public async Task EditClassClassNoImagePositive()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classGuid = Guid.Parse("95766741-DE9A-4380-9D0A-3E2B22099004");

            var formModel = new EditClassFormModel
            {
                Id = classGuid.ToString(),
                Title = "Yoga Class",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00).ToString(StartingDateFormat, CultureInfo.InvariantCulture),
                Duration = 90,
                Description = "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.",
                ImageUrl = "No image"
            };
            Class editedClass = new Class()
            {
                Id = classGuid,
                Title = "Yoga Class",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 90,
                Description = "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.",
                ImageUrl = NoImageUrl
            };

            classRepository.Setup(r => r.UpdateAsync(It.IsAny<Class>()))
                .Returns(Task.FromResult(true))
                .Callback<Class>(updatedClass =>
                {
                    // Verify that the updated class has the correct ImageUrl
                    Assert.AreEqual(NoImageUrl, updatedClass.ImageUrl);
                });

            bool result = await classService.EditClassAsync(formModel);

            Assert.True(result);
            classRepository.Verify(r => r.UpdateAsync(It.Is<Class>(c => c.ImageUrl == NoImageUrl)), Times.Once);
        }

        [Test]
        public async Task EditClassClassImageNullPositive()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classGuid = Guid.Parse("95766741-DE9A-4380-9D0A-3E2B22099004");

            var formModel = new EditClassFormModel
            {
                Id = classGuid.ToString(),
                Title = "Yoga Class",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00).ToString(StartingDateFormat, CultureInfo.InvariantCulture),
                Duration = 90,
                Description = "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.",
                ImageUrl = null
            };
            Class editedClass = new Class()
            {
                Id = classGuid,
                Title = "Yoga Class",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 90,
                Description = "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.",
                ImageUrl = NoImageUrl
            };

            classRepository.Setup(r => r.UpdateAsync(It.IsAny<Class>()))
                .Returns(Task.FromResult(true))
                .Callback<Class>(updatedClass =>
                {
                    // Verify that the updated class has the correct ImageUrl
                    Assert.AreEqual(NoImageUrl, updatedClass.ImageUrl);
                });

            bool result = await classService.EditClassAsync(formModel);

            Assert.True(result);
            classRepository.Verify(r => r.UpdateAsync(It.Is<Class>(c => c.ImageUrl == NoImageUrl)), Times.Once);
        }

        [Test]
        public async Task GetAvailableSubscribtionsByIdPositive()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");
            Guid gymId = Guid.Parse("DA07CD2D-59B2-4572-A1EF-19BBBFDF4984");

            Class mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };
            Gym mockGym = new Gym
            {
                Id = gymId,
                Name = "Gladiator",
                Location = "Yambol",
                IsDeleted = false
            };
            GymClass mockGymClass = new GymClass
            {
                ClassId = classId,
                Class = mockClass,
                GymId = gymId,
                Gym = mockGym,
                IsDeleted = true,
                AvailableSubscribtions = 5
            };
            var mockSubscribtions = new AvailableSubscribtionsViewModel()
            {
                GymId = gymId.ToString(),
                ClassId = classId.ToString(),
                Quantity = 0,
                AvailableSubscribtions = mockGymClass.AvailableSubscribtions
            };

            gymClassRepository.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<GymClass, bool>>>()))
                .ReturnsAsync(mockGymClass);
            var gymClass = await gymClassRepository.Object.FirstOrDefaultAsync(gc => gc.ClassId == classId && gc.GymId == gymId);

            AvailableSubscribtionsViewModel result =
                await classService.GetAvailableSubscribtionsByIdAsync(gymId, classId);

            Assert.AreEqual(mockSubscribtions.ClassId, result.ClassId);
            Assert.AreEqual(mockSubscribtions.GymId, result.GymId);
            Assert.AreEqual(mockSubscribtions.Quantity, result.Quantity);
            Assert.AreEqual(mockSubscribtions.AvailableSubscribtions, result.AvailableSubscribtions);
        }

        [Test]
        public async Task GetAvailableSubscribtionsByIdNoGymClassFoundNegative()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");
            Guid gymId = Guid.Parse("DA07CD2D-59B2-4572-A1EF-19BBBFDF4984");

            Class mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };
            Gym mockGym = new Gym
            {
                Id = gymId,
                Name = "Gladiator",
                Location = "Yambol",
                IsDeleted = false
            };
            GymClass mockGymClass = null;

            gymClassRepository.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<GymClass, bool>>>()))
                .ReturnsAsync(mockGymClass);
            var gymClass = await gymClassRepository.Object.FirstOrDefaultAsync(gc => gc.ClassId == classId && gc.GymId == gymId);

            AvailableSubscribtionsViewModel result =
                await classService.GetAvailableSubscribtionsByIdAsync(gymId, classId);

            Assert.IsNull(result);
            Assert.IsNull(gymClass);
        }

        [Test]
        public async Task SoftDeleteClassPositive()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.Parse("07A8335B-49FD-4C8B-A802-F8A783F1E7CE");

            Class mockClass = new Class
            {
                Id = classId,
                Title = "Full-Body Strength Training",
                StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                Duration = 70,
                Description = "A well-rounded workout targeting all major muscle groups.",
                ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
            };

            classRepository.Setup(r => r.FirstOrDefaultAsync(It.IsAny<Expression<Func<Class, bool>>>()))
                .ReturnsAsync(mockClass);
            var classModel = await classRepository.Object.FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == classId.ToString().ToLower());

            classRepository.Setup(r => r.UpdateAsync(It.IsAny<Class>()))
                .Returns(Task.FromResult(true))
                .Callback<Class>(updatedClass =>
                {
                    Assert.IsTrue(classModel.IsDeleted);
                });

            bool result = await classService.SoftDeleteClassAsync(classId);

            Assert.IsTrue(result);
            classRepository.Verify(r => r.UpdateAsync(It.Is<Class>(c => c.IsDeleted == true)), Times.Once);
            Assert.IsTrue(classModel.IsDeleted);
        }

        [Test]
        public async Task SoftDeleteClass_ClassRepoIsNullNegative()
        {
            Mock<IRepository<Class, Guid>>? nullClassRepository = null; // Simulate a null repository
            var gymRepository = new Mock<IRepository<Gym, Guid>>();
            var gymClassRepository = new Mock<IRepository<GymClass, object>>();

            // Pass null repository into the service
            IClassService classService = new ClassService(nullClassRepository?.Object, gymRepository.Object, gymClassRepository.Object);

            Guid classId = Guid.NewGuid(); // Test Guid

            // Act
            bool result = await classService.SoftDeleteClassAsync(classId);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task GetClassesCountByFilter_ShouldReturnCorrectCountWhenValidInputModelPositive()
        {
            IQueryable<Class> classesMockQueryable = classesData.BuildMock();
            this.classRepository
                .Setup(r => r.GetAllAttached())
                .Returns(classesMockQueryable);

            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            AllClassesSearchFilterViewModel viewModel = new AllClassesSearchFilterViewModel()
            {
                SearchQuery = null
            };

            IEnumerable<AllClassesIndexViewModel> allClassesActual = await classService
                .GetAllClassesAsync(new AllClassesSearchFilterViewModel());

            int count = await classService.GetClassesCountByFilterAsync(viewModel);

            Assert.AreEqual(allClassesActual.Count(), count);
        }
    }
}