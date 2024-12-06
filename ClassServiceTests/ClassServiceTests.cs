using System.Globalization;
using FitnessCenter.Web.ViewModels.Gym;

namespace FitnessCenter.Services.Tests
{
    using FitnessCenter.Data.Models;
    using FitnessCenter.Data.Repository.Interfaces;
    using FitnessCenter.Models;
    using FitnessCenter.Services.Data;
    using FitnessCenter.Services.Data.Interfaces;
    using FitnessCenter.Services.Mapping;
    using FitnessCenter.Web.ViewModels.Class;
    using MockQueryable;
    using Moq;
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

        private IList<Gym> gymsData = new List<Gym>()
        {
            new Gym()
            {
                Name = "Gladiator",
                Location = "Yambol"
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
        public async Task AddClassToGymsSelectedNoGymClassPositive()
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
                        IsSelected = true
                    }
                }
            };

            ICollection<GymClass> mockList = new List<GymClass>(){mockGymClass};

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);
            gymRepository.Setup(r => r.GetByIdAsync(gymId)).ReturnsAsync(mockGym);
            gymClassRepository.Setup(r => r.FirstOrDefaultAsync(gc => gc.ClassId == classId && gc.GymId == gymId))
                .ReturnsAsync(mockGymClass);

            bool result = await classService.AddClassToGymsAsync(classId, mockInputModel);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task AddClassToGymsNotSelectedNoGymClassPositive()
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
            gymClassRepository.Setup(r => r.FirstOrDefaultAsync(gc => gc.ClassId == classId &&
                                                                      gc.GymId == gymId)).ReturnsAsync(mockGymClass);


            bool result = await classService.AddClassToGymsAsync(classId, mockInputModel);
        }

        [Test]
        public async Task AddClassToGymsNullClassNegative()
        {
            IClassService classService = new ClassService(classRepository.Object, gymRepository.Object, gymClassRepository.Object);

            bool result = await classService.AddClassToGymsAsync(Guid.Empty, new AddClassToGymInputModel());

            Assert.False(result);
        }

        [Test]
        public async Task AddClassToGymsGymGuidNotValidNegative()
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

            bool result = await classService.AddClassToGymsAsync(classId, mockInputModel);

            Assert.False(result);
        }

        [Test]
        public async Task AddClassToGymsGymNotFoundNegative()
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
        }

        [Test]
        public async Task AddClassToGymsGymDeletedNegative()
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
        }
    }
}