using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Common
{
    public static class EntityValidationConstants
    {
        public static class Class
        {
            public const int TitleMaxLength = 50;
            public const int DurationMinValue = 1;
            public const int DurationMaxValue = 999;
            public const string StartingDateFormat = "MM/dd HH:mm";
            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;
        }

        public static class Gym
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int LocationMinLength = 3;
            public const int LocationMaxLength = 85;
        }

        public static class GymClass
        {
            public const int AvailableSubscribtionsMinValue = 0;
            public const int AvailableSubscribtionsMaxValue = 100;
        }

        public static class Manager
        {
            public const int PhoneNumberMinLength = 6;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class Subscribtion
        {
            public const int CountMinValue = 1;
            public const int CountMaxValue = int.MaxValue;
            public const string PriceMinValue = "0.01m";
            public const string PriceMaxValue = "79228162514264337593543950335m";
        }
    }
}
