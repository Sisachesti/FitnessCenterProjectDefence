using FitnessCenter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FitnessCenter.Common.EntityValidationConstants.Class;
using static FitnessCenter.Common.ApplicationConstants;

namespace FitnessCenter.Data.Configuration
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            // Fluent API
            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder
                .Property(m => m.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength)
                .HasDefaultValue(NoImageUrl);

            builder.HasData(this.SeedClasses());
        }

        private List<Class> SeedClasses()
        {
            List<Class> movies = new List<Class>()
            {
                new Class()
                {
                    Title = "Yoga Class",
                    StartingDate = new DateTime(2024, 12, 16, 12, 00, 00),
                    Duration = 90,
                    Description = "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.",
                    ImageUrl = "https://www.everydayyoga.com/cdn/shop/articles/yoga_1024x1024.jpg?v=1703853908"
                },
                new Class()
                {
                    Title = "Full-Body Strength Training",
                    StartingDate = new DateTime(2024, 12, 13, 11, 00, 00),
                    Duration = 70,
                    Description = "A well-rounded workout targeting all major muscle groups. Incorporates free weights, resistance machines, and bodyweight exercises to improve overall strength, endurance, and stability. Suitable for all levels, with modifications available.",
                    ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528"
                },
                new Class()
                {
                    Title = "Basketball Training",
                    StartingDate = new DateTime(2024, 12, 13, 16, 00, 00),
                    Duration = 120,
                    Description = "A basketball training program is a specialized practice designed to improve an individual's skillset. It typically involves drills and exercises focused on developing specific areas, such as ball handling, shooting, passing, and agility.",
                    ImageUrl = "https://revolutionbasketballtraining.com/wp-content/uploads/2024/06/Personal-Basketball-Training-Can-Elevate-Your-Game-1.png"
                },
                new Class()
                {
                    Title = "Football Training",
                    StartingDate = new DateTime(2024, 12, 16, 12, 00, 00),
                    Duration = 148,
                    Description = "Cardio will involve running, cycling, HIIT and the work you put in on the training ground. Resistance training involves weightlifting (compound and isolation movements) and bodyweight exercises. Beyond the training itself, you'll need to focus on recovery, flexibility and mobility.",
                    ImageUrl = "https://cdn.shopify.com/s/files/1/1278/0725/files/training-04_2048x2048.jpg?v=1615983259"
                },
                new Class()
                {
                    Title = "Strength Training",
                    StartingDate = new DateTime(2024, 12, 17, 10, 00, 00),
                    Duration = 135,
                    Description = "Focus on developing raw strength through compound lifts like squats, deadlifts, and bench presses. Accessory exercises support overall stability and power.",
                    ImageUrl = "https://connect.healthkart.com/wp-content/uploads/2015/11/banner-63.jpg"
                },
                new Class()
                {
                    Title = "Endurance Drills",
                    StartingDate = new DateTime(2024, 12, 18, 14, 00, 00),
                    Duration = 120,
                    Description = "Long-distance running and cycling programs to build stamina essential for football and other high-energy sports.",
                    ImageUrl = "https://res.cloudinary.com/peloton-cycle/image/fetch/f_auto,c_limit,w_3840,q_90/https://images.ctfassets.net/6ilvqec50fal/An9AxlhKHKfeQB9lto7jC/1fad4cff5a4decf350ef888627d4d355/endurance-training.jpg"
                },
                new Class()
                {
                    Title = "Flexibility and Mobility",
                    StartingDate = new DateTime(2024, 12, 19, 08, 00, 00),
                    Duration = 95,
                    Description = "Integrate yoga and dynamic stretching to enhance range of motion and prevent injuries.",
                    ImageUrl = "https://www.otgonline.in/cdn/shop/articles/Mobility-Exercises_1200x.jpg?v=1629806297"
                },
                new Class()
                {
                    Title = "Speed Training",
                    StartingDate = new DateTime(2024, 12, 20, 16, 00, 00),
                    Duration = 110,
                    Description = "Short sprints, ladder drills, and plyometrics designed to boost acceleration and top-end speed.",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTpHNObL-mJdlpAaOemfj8bPdB-QHxfSaQkHA&s"
                },
                new Class()
                {
                    Title = "Agility Workouts",
                    StartingDate = new DateTime(2024, 12, 21, 18, 00, 00),
                    Duration = 130,
                    Description = "Hone quick directional changes and improve reaction times through cone drills and reactive agility tests.",
                    ImageUrl = "https://vertimax.com/hubfs/Agility/agility%20training%20-vertimax%20raptor%20on%20field-1200x600.png"
                },
                new Class()
                {
                    Title = "Functional Fitness",
                    StartingDate = new DateTime(2024, 12, 22, 07, 30, 00),
                    Duration = 145,
                    Description = "Develop practical strength and coordination using kettlebells, sandbags, and functional training tools.",
                    ImageUrl = "https://www.trxtraining.com/cdn/shop/articles/Functional_Fitness.jpg?v=1645067939"
                },
                new Class()
                {
                    Title = "Core Stability",
                    StartingDate = new DateTime(2024, 12, 23, 13, 00, 00),
                    Duration = 100,
                    Description = "Work on core strength and stability using planks, medicine balls, and dynamic core challenges.",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxYRbpNFB3qYcfkDlVtSXUzvYUHPYqxHzdbg&s"
                },
                new Class()
                {
                    Title = "Recovery Essentials",
                    StartingDate = new DateTime(2024, 12, 24, 12, 30, 00),
                    Duration = 85,
                    Description = "Master foam rolling, stretching, and sleep optimization to accelerate recovery.",
                    ImageUrl = "https://www.totalsportsblog.co.za/wp-content/uploads/2023/12/GettyImages-506979575-scaled.jpg"
                },
                new Class()
                {
                    Title = "Football Tactical Awareness",
                    StartingDate = new DateTime(2024, 12, 26, 15, 00, 00),
                    Duration = 140,
                    Description = "Improve your understanding of game strategies, positioning, and opponent analysis.",
                    ImageUrl = "https://www.sportsessionplanner.com/uploads/images/session_transitions/290026.jpg"
                },
                new Class()
                {
                    Title = "Basketball Team Drills",
                    StartingDate = new DateTime(2024, 12, 27, 11, 00, 00),
                    Duration = 125,
                    Description = "Practice cohesive teamwork strategies with passing, shooting, and situational drills.",
                    ImageUrl = "https://basketballhq.com/wp-content/uploads/2019/04/Basketball-Team-Drills-2.jpg"
                },
                new Class()
                {
                    Title = "Basketball Defensive Skills",
                    StartingDate = new DateTime(2024, 12, 28, 17, 30, 00),
                    Duration = 105,
                    Description = "Learn defensive tactics, including marking, tackling, and spatial awareness.",
                    ImageUrl = "https://www.online-basketball-drills.com/wp-content/uploads/2019/12/pngdef9.jpg"
                },
                new Class()
                {
                    Title = "Goalkeeping Techniques",
                    StartingDate = new DateTime(2024, 12, 29, 08, 00, 00),
                    Duration = 120,
                    Description = "Develop reflexes, dives, and aerial dominance tailored for goalkeepers.",
                    ImageUrl = "https://lh4.googleusercontent.com/proxy/QuLrI7AQ3rl10zR9e4R3bbQSc0WWfuTkMcUU4vQ4PxBKGjjNTwDbzg4hVlI3n3C5J3ySvRWUF4bPmW-GvSFO4UfZwjsXlxzpP65vtMTyUx4cfBVMekc_VM1yjx78zSWMqfQupzSR"
                },
                new Class()
                {
                    Title = "Football Offensive Tactics",
                    StartingDate = new DateTime(2024, 12, 30, 10, 30, 00),
                    Duration = 115,
                    Description = "Master attacking strategies including positioning, finishing, and playmaking.",
                    ImageUrl = "https://www.sportsessionplanner.com/uploads/images/session_transitions/354010.jpg"
                },
                new Class()
                {
                    Title = "High-Intensity Drills",
                    StartingDate = new DateTime(2024, 12, 31, 13, 00, 00),
                    Duration = 155,
                    Description = "Perform drills that simulate game pressure and build mental toughness.",
                    ImageUrl = "https://images.stockcake.com/public/7/3/c/73c16313-7985-4838-81b2-10474e7ab8cb_large/intense-basketball-moment-stockcake.jpg"
                },
                new Class()
                {
                    Title = "Seasonal Conditioning",
                    StartingDate = new DateTime(2025, 01, 04, 15, 30, 00),
                    Duration = 145,
                    Description = "Adapt your training program for preseason, in-season, and postseason phases.",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7-YSIIzBt1z1xVT3h7ZJbTPKeuVRyZd8pGQ&s"
                }
            };

            return movies;
        }
    }
}
