using FitnessCenter.Web.ViewModels.Gym;
using System.Globalization;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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
    using static Common.ApplicationConstants;
    using FitnessCenter.Web.ViewModels.GymClass;
    using System.Collections.Generic;
    using AutoMapper;

    [TestFixture]
    public class GymServiceTests
    {
        private IList<Gym> gymsData = new List<Gym>()
        {
            new Gym()
            {
                Name = "Gladiator",
                Location = "Yambol"
            },
            new Gym()
            {
                Name = "Flex",
                Location = "Yambol"
            },
            new Gym()
            {
                Name = "Olimpia",
                Location = "Yambol"
            }
        };

        private Mock<IRepository<Gym, Guid>> gymRepository;
        private IGymService gymService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);
        }

        [SetUp]
        public void Setup()
        {
            this.gymRepository = new Mock<IRepository<Gym, Guid>>();
            this.gymService = new GymService(gymRepository.Object);
        }

        [Test]
        public async Task IndexGetAllOrderedByLocationPositive()
        {
            IQueryable<Gym> gyms = gymsData.BuildMock();
            this.gymRepository
                .Setup(r => r.GetAllAttached())
                .Returns(gyms);

            var result = await gymService.IndexGetAllOrderedByLocationAsync();

            var gymsList = result
                .OrderBy(g => g.Location)
                .ToList();

            Assert.AreEqual(3, gymsList.Count);
            Assert.AreEqual("Gladiator", gymsList[0].Name);
            Assert.AreEqual("Flex", gymsList[1].Name);
            Assert.AreEqual("Olimpia", gymsList[2].Name);
        }

        [Test]
        public async Task AddGymPositive()
        {
            var _mockMapper = new Mock<IMapper>();

            AddGymFormModel model = new AddGymFormModel()
            {
                Name = "New Gym",
                Location = "Plovdiv"
            };
            Gym gym = new Gym()
            {
                Name = "New Gym",
                Location = "Plovdiv"
            };

            await gymService.AddGymAsync(model);

            gymRepository.Verify(repo => repo.AddAsync(It.Is<Gym>(g => g.Name == gym.Name && g.Location == gym.Location)), Times.Once);
        }

        [Test]
        public async Task GetGymDetailsByIdAsync_GymExistsPositive()
        {
            var gymId = Guid.NewGuid();

            var gym = new Gym
            {
                Id = gymId,
                Name = "New Gym",
                Location = "Plovdiv",
                GymClasses = new[]
                {
                    new GymClass
                    {
                        GymId = gymId,
                        Class = new Class
                        {
                            Id = Guid.NewGuid(),
                            Title = "Yoga",
                            Duration = 60,
                            Description = "Relaxing yoga class",
                            ImageUrl = "yoga.jpg"
                        },
                        AvailableSubscribtions = 10,
                        IsDeleted = false
                    },
                    new GymClass
                    {
                        GymId = gymId,
                        Class = new Class
                        {
                            Id = Guid.NewGuid(),
                            Title = "Pilates",
                            Duration = 45,
                            Description = "Strength and flexibility",
                            ImageUrl = "pilates.jpg"
                        },
                        AvailableSubscribtions = 5,
                        IsDeleted = true
                    }
                }
            };

            var gyms = new[] { gym }.AsQueryable();

            gymRepository.Setup(repo => repo.GetAllAttached()).Returns(gyms);

            gymRepository.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Gym, bool>>>()))
                .ReturnsAsync(gym);

            var result = gymService.GetGymDetailsByIdAsync(gymId);

            Assert.NotNull(result);
        }

        [Test]
        public async Task EditGymAsyncPositive()
        {
            Guid gymId = Guid.NewGuid();

            Gym gym = new Gym()
            {
                Id = gymId,
                Name = "New Gym",
                Location = "Plovdiv"
            };

            EditGymFormModel formModel = new EditGymFormModel()
            {
                Id = gymId.ToString(),
                Name = "New Gym",
                Location = "Plovdiv"
            };

            gymRepository.Setup(r => r.UpdateAsync(It.IsAny<Gym>()))
                .Returns(Task.FromResult(true));

            var result = await gymService.EditGymAsync(formModel);

            Assert.True(result);
        }

        [Test]
        public async Task SoftDeleteGymPositive()
        {
            Guid gymId = Guid.NewGuid();

            Gym gym = new Gym()
            {
                Id = gymId,
                Name = "New Gym",
                Location = "Plovdiv"
            };

            gymRepository.Setup(r => r.FirstOrDefaultAsync(It.IsAny<Expression<Func<Gym, bool>>>()))
                .ReturnsAsync(gym);
            var classModel = await gymRepository.Object.FirstOrDefaultAsync(g => g.Id.ToString().ToLower() == gymId.ToString().ToLower());

            gymRepository.Setup(r => r.UpdateAsync(It.IsAny<Gym>()))
                .Returns(Task.FromResult(true))
                .Callback<Gym>(updatedGym =>
                {
                    Assert.IsTrue(classModel.IsDeleted);
                });

            bool result = await gymService.SoftDeleteGymAsync(gymId);

            Assert.IsTrue(result);
            gymRepository.Verify(r => r.UpdateAsync(It.Is<Gym>(c => c.IsDeleted == true)), Times.Once);
            Assert.IsTrue(classModel.IsDeleted);
        }

        [Test]
        public async Task SoftDeleteGymNullGymNegative()
        {
            Mock<IRepository<Gym, Guid>>? nullGymRepository = null;

            IGymService gymService = new GymService(nullGymRepository?.Object);

            Guid gymId = Guid.NewGuid();

            bool result = await gymService.SoftDeleteGymAsync(gymId);

            Assert.False(result);
        }

        [Test]
        public async Task GetGymForEditByIdPositive()
        {
            var mockGymRepository = new Mock<IRepository<Gym, Guid>>();

            var gymId = Guid.NewGuid();
            var gymData = new List<Gym>
            {
                new Gym
                {
                    Id = gymId,
                    Name = "Test Gym",
                    Location = "Test Location",
                    IsDeleted = false
                },
                new Gym
                {
                    Id = Guid.NewGuid(),
                    Name = "Deleted Gym",
                    Location = "Deleted Location",
                    IsDeleted = true
                }
            }.AsQueryable();

            var asyncGymData = gymData.BuildMock();
            mockGymRepository.Setup(repo => repo.GetAllAttached()).Returns(asyncGymData);

            var mockEditGymFormModel = new EditGymFormModel
            {
                Id = gymId.ToString(),
                Name = "Test Gym",
                Location = "Test Location"
            };

            AutoMapperConfig.MapperInstance = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Gym, EditGymFormModel>();
            }).CreateMapper();

            var gymService = new GymService(mockGymRepository.Object);

            var result = await gymService.GetGymForEditByIdAsync(gymId);

            Assert.NotNull(result);
            Assert.AreEqual(mockEditGymFormModel.Id, result?.Id);
            Assert.AreEqual(mockEditGymFormModel.Name, result?.Name);
            Assert.AreEqual(mockEditGymFormModel.Location, result?.Location);
            mockGymRepository.Verify(repo => repo.GetAllAttached(), Times.Once);
        }

        [Test]
        public async Task GetGymForDeleteByIdPositive()
        {
            var mockGymRepository = new Mock<IRepository<Gym, Guid>>();

            var gymId = Guid.NewGuid();
            var gymData = new List<Gym>
            {
                new Gym
                {
                    Id = gymId,
                    Name = "Test Gym",
                    Location = "Test Location",
                    IsDeleted = false
                },
                new Gym
                {
                    Id = Guid.NewGuid(),
                    Name = "Deleted Gym",
                    Location = "Deleted Location",
                    IsDeleted = true
                }
            }.AsQueryable();

            // Mock DbSet behavior
            var asyncGymData = gymData.BuildMock();
            mockGymRepository.Setup(repo => repo.GetAllAttached()).Returns(asyncGymData);

            // Mock AutoMapper behavior
            var mockEditGymFormModel = new DeleteGymViewModel()
            {
                Id = gymId.ToString(),
                Name = "Test Gym",
                Location = "Test Location"
            };

            AutoMapperConfig.MapperInstance = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Gym, DeleteGymViewModel>();
            }).CreateMapper();

            var gymService = new GymService(mockGymRepository.Object);

            // Act
            var result = await gymService.GetGymForDeleteByIdAsync(gymId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(mockEditGymFormModel.Id, result?.Id);
            Assert.AreEqual(mockEditGymFormModel.Name, result?.Name);
            Assert.AreEqual(mockEditGymFormModel.Location, result?.Location);
            mockGymRepository.Verify(repo => repo.GetAllAttached(), Times.Once);
        }
    }
}
