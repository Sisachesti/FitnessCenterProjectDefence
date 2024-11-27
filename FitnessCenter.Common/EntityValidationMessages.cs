using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Common
{
    public static class EntityValidationMessages
    {
        public static class Class
        {
            public const string ClassTitleRequiredMessage = "Class title is required.";
            public const string StartingDateRequiredMessage = "Starting date is required in format MM/dd HH:mm";
            public const string DurationRequiredMessage = "Please specify class duration.";
        }

        public static class Gym
        {
            public const string GymNameRequiredMessage = "Gym name is required.";
            public const string LocationRequiredMessage = "Location name is required.";
        }

        public static class GymClass
        {
            public const string AvailableSubscribtionsRequiredMessage = "Please enter the number of available subscribtions.";
            public const string AvailableSubscribtionsRangeMessage = "Available subscribtions must be a positive number.";
        }

        public static class Subscribtion
        {
            public const string IncorrectPriceMessage = "Subscribtion price should be positive!";
            public const string IncorrectCountMessage = "Subscribtions count should be positive number!";
        }
    }
}
