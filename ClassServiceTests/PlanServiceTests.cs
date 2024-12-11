using FitnessCenter.Web.ViewModels.Gym;
using System.Globalization;
using System.Linq.Expressions;

namespace FitnessCenter.Services.Tests
{
    using AutoMapper;
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
    public class PlanServiceTests
    {
        private Mock<IRepository<ApplicationUserClass, object>> userClassRepository;
        private Mock<IRepository<Class, Guid>> classRepository;
        private IPlanService planService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);
        }

        [SetUp]
        public void Setup()
        {
            this.classRepository = new Mock<IRepository<Class, Guid>>();
            this.userClassRepository = new Mock<IRepository<ApplicationUserClass, object>>();
            this.planService = new PlanService(userClassRepository.Object, classRepository.Object);
        }

        [Test]
        public async Task AddClassToUserPlansAsync_ClassGuidNotValidNegative()
        {
            string userId = Guid.NewGuid().ToString();
            string classId = "0000";

            bool result = await planService.AddClassToUserPlansAsync(classId, userId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task AddClassToUserPlansAsync_ClassIsNullNegative()
        {
            Guid userId = Guid.NewGuid();
            Guid classId = Guid.NewGuid();
            Guid searchedId = Guid.NewGuid();

            Class mockClass = new Class()
            {
                Id = classId
            };

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);

            bool result = await planService.AddClassToUserPlansAsync(searchedId.ToString(), userId.ToString());

            Assert.IsFalse(result);
        }

        [Test]
        public async Task AddClassToUserPlansAsync_AddedToPlansAlreadyPositive()
        {
            string userId = Guid.NewGuid().ToString();
            string classId = Guid.NewGuid().ToString();
            Guid classGuid = Guid.Parse(classId);

            Class mockClass = new Class()
            {
                Id = Guid.Parse(classId)
            };

            var applicationUserClass = new ApplicationUserClass
            {
                ClassId = classGuid,
                ApplicationUserId = Guid.Parse(userId)
            };

            userClassRepository
                .Setup(r => r.FirstOrDefaultAsync(It.IsAny<Expression<Func<ApplicationUserClass, bool>>>()))
                .ReturnsAsync((Expression<Func<ApplicationUserClass, bool>> predicate) =>
                {
                    // Simulate a database evaluation of the predicate
                    if (predicate.Compile().Invoke(applicationUserClass))
                    {
                        return applicationUserClass;
                    }
                    return null;
                });

            classRepository.Setup(r => r.GetByIdAsync(Guid.Parse(classId))).ReturnsAsync(mockClass);

            bool result = await planService.AddClassToUserPlansAsync(classId.ToString(), userId.ToString());

            Assert.IsTrue(result);
            Assert.IsNotNull(applicationUserClass);
        }

        [Test]
        public async Task AddClassToUserPlansAsyncPositive()
        {
            string userId = Guid.NewGuid().ToString();
            string classId = Guid.NewGuid().ToString();

            Class mockClass = new Class()
            {
                Id = Guid.Parse(classId)
            };
            ApplicationUserClass? addedToPlansAlready = null;
            var newUserClass = new ApplicationUserClass
            {
                ApplicationUserId = Guid.Parse(userId),
                ClassId = Guid.Parse(classId)
            };

            classRepository.Setup(r => r.GetByIdAsync(Guid.Parse(classId))).ReturnsAsync(mockClass);
            userClassRepository.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<ApplicationUserClass, bool>>>()))
                .ReturnsAsync(addedToPlansAlready);

            bool result = await planService.AddClassToUserPlansAsync(classId, userId);

            Assert.IsTrue(result);
            userClassRepository.Verify(repo => repo.AddAsync(It.Is<ApplicationUserClass>(uc =>
                uc.ApplicationUserId == Guid.Parse(userId) &&
                uc.ClassId == Guid.Parse(classId))), Times.Once);
        }

        [Test]
        public async Task RemoveClassFromUserPlans_ClassGuidNotValidNegative()
        {
            string userId = Guid.NewGuid().ToString();
            string classId = "0000";

            bool result = await planService.RemoveClassFromUserPlansAsync(classId, userId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task RemoveClassFromUserPlans_ClassIsNullNegative()
        {
            Guid userId = Guid.NewGuid();
            Guid classId = Guid.NewGuid();
            Guid searchedId = Guid.NewGuid();

            Class mockClass = new Class()
            {
                Id = classId
            };

            classRepository.Setup(r => r.GetByIdAsync(classId)).ReturnsAsync(mockClass);

            bool result = await planService.RemoveClassFromUserPlansAsync(searchedId.ToString(), userId.ToString());

            Assert.IsFalse(result);
        }

        [Test]
        public async Task RemoveClassFromUserPlans_FoundApplicationUserClass()
        {
            string userId = Guid.NewGuid().ToString();
            string classId = Guid.NewGuid().ToString();
            Guid classGuid = Guid.Parse(classId);

            Class mockClass = new Class()
            {
                Id = Guid.Parse(classId)
            };

            var applicationUserClass = new ApplicationUserClass
            {
                ClassId = classGuid,
                ApplicationUserId = Guid.Parse(userId)
            };

            userClassRepository
                .Setup(r => r.FirstOrDefaultAsync(It.IsAny<Expression<Func<ApplicationUserClass, bool>>>()))
                .ReturnsAsync((Expression<Func<ApplicationUserClass, bool>> predicate) =>
                {
                    // Simulate a database evaluation of the predicate
                    if (predicate.Compile().Invoke(applicationUserClass))
                    {
                        return applicationUserClass;
                    }
                    return null;
                });

            classRepository.Setup(r => r.GetByIdAsync(Guid.Parse(classId))).ReturnsAsync(mockClass);

            userClassRepository
                .Setup(repo => repo.DeleteAsync(applicationUserClass))
                .Returns(Task.FromResult(true));

            // Act
            await userClassRepository.Object.DeleteAsync(applicationUserClass);

            // Assert
            userClassRepository.Verify(repo => repo.DeleteAsync(applicationUserClass), Times.Once,
                "DeleteAsync should be called exactly once with the specified entity.");

            bool result = await planService.RemoveClassFromUserPlansAsync(classId.ToString(), userId.ToString());

            Assert.IsTrue(result);
            Assert.IsNotNull(applicationUserClass);
        }
    }
}
