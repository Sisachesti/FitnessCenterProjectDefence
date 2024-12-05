using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessCenter.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAllClassesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("20e4e776-ec0f-4e00-9862-43c2f157de16"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("389d516a-8913-4e76-ad53-4c4b5e99788a"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("a9d77ddf-a864-4ade-b770-e250283b9829"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("5d641350-82d5-46cc-ab61-4884af9d02bc"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("65bdc283-4215-404c-94c7-76c8093e04d1"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("68d5ea2e-1076-4b94-83f2-32e76bd44260"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("938ff034-3f60-4754-8f8d-9578a4ee0b31"));

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Description", "Duration", "ImageUrl", "IsDeleted", "StartingDate", "Title" },
                values: new object[,]
                {
                    { new Guid("07a8335b-49fd-4c8b-a802-f8a783f1e7ce"), "A well-rounded workout targeting all major muscle groups. Incorporates free weights, resistance machines, and bodyweight exercises to improve overall strength, endurance, and stability. Suitable for all levels, with modifications available.", 70, "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528", false, new DateTime(2024, 12, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), "Full-Body Strength Training" },
                    { new Guid("2625b98d-3957-49a3-8485-a710b2038835"), "Adapt your training program for preseason, in-season, and postseason phases.", 145, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7-YSIIzBt1z1xVT3h7ZJbTPKeuVRyZd8pGQ&s", false, new DateTime(2025, 1, 4, 15, 30, 0, 0, DateTimeKind.Unspecified), "Seasonal Conditioning" },
                    { new Guid("3512eeef-e4f0-40cd-83b3-0968371b49ea"), "Work on core strength and stability using planks, medicine balls, and dynamic core challenges.", 100, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxYRbpNFB3qYcfkDlVtSXUzvYUHPYqxHzdbg&s", false, new DateTime(2024, 12, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), "Core Stability" },
                    { new Guid("4128a1f5-e121-4816-a46e-a5baa1c20850"), "Perform drills that simulate game pressure and build mental toughness.", 155, "https://images.stockcake.com/public/7/3/c/73c16313-7985-4838-81b2-10474e7ab8cb_large/intense-basketball-moment-stockcake.jpg", false, new DateTime(2024, 12, 31, 13, 0, 0, 0, DateTimeKind.Unspecified), "High-Intensity Drills" },
                    { new Guid("61e3542f-4fb8-4891-936e-f20822c2c51f"), "Develop reflexes, dives, and aerial dominance tailored for goalkeepers.", 120, "https://lh4.googleusercontent.com/proxy/QuLrI7AQ3rl10zR9e4R3bbQSc0WWfuTkMcUU4vQ4PxBKGjjNTwDbzg4hVlI3n3C5J3ySvRWUF4bPmW-GvSFO4UfZwjsXlxzpP65vtMTyUx4cfBVMekc_VM1yjx78zSWMqfQupzSR", false, new DateTime(2024, 12, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), "Goalkeeping Techniques" },
                    { new Guid("6ee6ebf8-2338-49f5-afa0-2158d382030d"), "Learn defensive tactics, including marking, tackling, and spatial awareness.", 105, "https://www.online-basketball-drills.com/wp-content/uploads/2019/12/pngdef9.jpg", false, new DateTime(2024, 12, 28, 17, 30, 0, 0, DateTimeKind.Unspecified), "Basketball Defensive Skills" },
                    { new Guid("7206e644-4a54-4a55-b1d9-3a9c6f814d5c"), "A basketball training program is a specialized practice designed to improve an individual's skillset. It typically involves drills and exercises focused on developing specific areas, such as ball handling, shooting, passing, and agility.", 120, "https://revolutionbasketballtraining.com/wp-content/uploads/2024/06/Personal-Basketball-Training-Can-Elevate-Your-Game-1.png", false, new DateTime(2024, 12, 13, 16, 0, 0, 0, DateTimeKind.Unspecified), "Basketball Training" },
                    { new Guid("865400f9-b351-42b6-a1d3-810abf0ac6c3"), "Short sprints, ladder drills, and plyometrics designed to boost acceleration and top-end speed.", 110, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTpHNObL-mJdlpAaOemfj8bPdB-QHxfSaQkHA&s", false, new DateTime(2024, 12, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), "Speed Training" },
                    { new Guid("95766741-de9a-4380-9d0a-3e2b22099004"), "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.", 90, "https://www.everydayyoga.com/cdn/shop/articles/yoga_1024x1024.jpg?v=1703853908", false, new DateTime(2024, 12, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), "Yoga Class" },
                    { new Guid("991f0bda-3903-4a6e-86ee-3ea157ed96b2"), "Cardio will involve running, cycling, HIIT and the work you put in on the training ground. Resistance training involves weightlifting (compound and isolation movements) and bodyweight exercises. Beyond the training itself, you'll need to focus on recovery, flexibility and mobility.", 148, "https://cdn.shopify.com/s/files/1/1278/0725/files/training-04_2048x2048.jpg?v=1615983259", false, new DateTime(2024, 12, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), "Football Training" },
                    { new Guid("aa62a6f1-9e97-467c-aca3-1310081fc694"), "Long-distance running and cycling programs to build stamina essential for football and other high-energy sports.", 120, "https://res.cloudinary.com/peloton-cycle/image/fetch/f_auto,c_limit,w_3840,q_90/https://images.ctfassets.net/6ilvqec50fal/An9AxlhKHKfeQB9lto7jC/1fad4cff5a4decf350ef888627d4d355/endurance-training.jpg", false, new DateTime(2024, 12, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), "Endurance Drills" },
                    { new Guid("b6dbf0a7-e90d-4602-a486-e7e99998d875"), "Focus on developing raw strength through compound lifts like squats, deadlifts, and bench presses. Accessory exercises support overall stability and power.", 135, "https://connect.healthkart.com/wp-content/uploads/2015/11/banner-63.jpg", false, new DateTime(2024, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Strength Training" },
                    { new Guid("b93f3b68-0ae2-462a-9052-cc36224a16d2"), "Develop practical strength and coordination using kettlebells, sandbags, and functional training tools.", 145, "https://www.trxtraining.com/cdn/shop/articles/Functional_Fitness.jpg?v=1645067939", false, new DateTime(2024, 12, 22, 7, 30, 0, 0, DateTimeKind.Unspecified), "Functional Fitness" },
                    { new Guid("c42cb210-fbaf-438f-9a2f-510f5bd5aad2"), "Master foam rolling, stretching, and sleep optimization to accelerate recovery.", 85, "https://www.totalsportsblog.co.za/wp-content/uploads/2023/12/GettyImages-506979575-scaled.jpg", false, new DateTime(2024, 12, 24, 12, 30, 0, 0, DateTimeKind.Unspecified), "Recovery Essentials" },
                    { new Guid("c77c9e28-fd79-4ae2-b392-a78d18ae7851"), "Practice cohesive teamwork strategies with passing, shooting, and situational drills.", 125, "https://basketballhq.com/wp-content/uploads/2019/04/Basketball-Team-Drills-2.jpg", false, new DateTime(2024, 12, 27, 11, 0, 0, 0, DateTimeKind.Unspecified), "Basketball Team Drills" },
                    { new Guid("dcd272db-57cf-459d-a98f-4a372b8ae73d"), "Hone quick directional changes and improve reaction times through cone drills and reactive agility tests.", 130, "https://vertimax.com/hubfs/Agility/agility%20training%20-vertimax%20raptor%20on%20field-1200x600.png", false, new DateTime(2024, 12, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), "Agility Workouts" },
                    { new Guid("dd8883dc-a5e7-49eb-b0f4-502391910f4e"), "Master attacking strategies including positioning, finishing, and playmaking.", 115, "https://www.sportsessionplanner.com/uploads/images/session_transitions/354010.jpg", false, new DateTime(2024, 12, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), "Football Offensive Tactics" },
                    { new Guid("e62d4953-94e1-49be-9d95-848759045797"), "Integrate yoga and dynamic stretching to enhance range of motion and prevent injuries.", 95, "https://www.otgonline.in/cdn/shop/articles/Mobility-Exercises_1200x.jpg?v=1629806297", false, new DateTime(2024, 12, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), "Flexibility and Mobility" },
                    { new Guid("ebe72a27-3d55-4c7a-ba27-6c9a0a273590"), "Improve your understanding of game strategies, positioning, and opponent analysis.", 140, "https://www.sportsessionplanner.com/uploads/images/session_transitions/290026.jpg", false, new DateTime(2024, 12, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), "Football Tactical Awareness" }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("7a277193-e9c8-4c84-a72c-21e6c1d5bd8d"), false, "Plovdiv", "Pulse Fitness" },
                    { new Guid("a6b718ff-f3e6-446b-ad2e-898a4cbeb923"), false, "Yambol", "Flex" },
                    { new Guid("cdf712b3-67a3-4427-8f76-64912750eba7"), false, "Yambol", "Olimpia" },
                    { new Guid("da07cd2d-59b2-4572-a1ef-19bbbfdf4984"), false, "Yambol", "Gladiator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("07a8335b-49fd-4c8b-a802-f8a783f1e7ce"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("2625b98d-3957-49a3-8485-a710b2038835"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("3512eeef-e4f0-40cd-83b3-0968371b49ea"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("4128a1f5-e121-4816-a46e-a5baa1c20850"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("61e3542f-4fb8-4891-936e-f20822c2c51f"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("6ee6ebf8-2338-49f5-afa0-2158d382030d"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("7206e644-4a54-4a55-b1d9-3a9c6f814d5c"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("865400f9-b351-42b6-a1d3-810abf0ac6c3"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("95766741-de9a-4380-9d0a-3e2b22099004"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("991f0bda-3903-4a6e-86ee-3ea157ed96b2"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("aa62a6f1-9e97-467c-aca3-1310081fc694"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("b6dbf0a7-e90d-4602-a486-e7e99998d875"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("b93f3b68-0ae2-462a-9052-cc36224a16d2"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("c42cb210-fbaf-438f-9a2f-510f5bd5aad2"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("c77c9e28-fd79-4ae2-b392-a78d18ae7851"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("dcd272db-57cf-459d-a98f-4a372b8ae73d"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("dd8883dc-a5e7-49eb-b0f4-502391910f4e"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("e62d4953-94e1-49be-9d95-848759045797"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("ebe72a27-3d55-4c7a-ba27-6c9a0a273590"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("7a277193-e9c8-4c84-a72c-21e6c1d5bd8d"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("a6b718ff-f3e6-446b-ad2e-898a4cbeb923"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("cdf712b3-67a3-4427-8f76-64912750eba7"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("da07cd2d-59b2-4572-a1ef-19bbbfdf4984"));

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Description", "Duration", "IsDeleted", "StartingDate", "Title" },
                values: new object[,]
                {
                    { new Guid("20e4e776-ec0f-4e00-9862-43c2f157de16"), "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.", 90, false, new DateTime(2024, 12, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), "Yoga Class" },
                    { new Guid("389d516a-8913-4e76-ad53-4c4b5e99788a"), "A basketball training program is a specialized practice designed to improve an individual's skillset. It typically involves drills and exercises focused on developing specific areas, such as ball handling, shooting, passing, and agility.", 120, false, new DateTime(2024, 12, 13, 16, 0, 0, 0, DateTimeKind.Unspecified), "Basketball Training" },
                    { new Guid("a9d77ddf-a864-4ade-b770-e250283b9829"), "A well-rounded workout targeting all major muscle groups. Incorporates free weights, resistance machines, and bodyweight exercises to improve overall strength, endurance, and stability. Suitable for all levels, with modifications available.", 70, false, new DateTime(2024, 12, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), "Full-Body Strength Training" }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("5d641350-82d5-46cc-ab61-4884af9d02bc"), false, "Yambol", "Olimpia" },
                    { new Guid("65bdc283-4215-404c-94c7-76c8093e04d1"), false, "Yambol", "Gladiator" },
                    { new Guid("68d5ea2e-1076-4b94-83f2-32e76bd44260"), false, "Plovdiv", "Pulse Fitness" },
                    { new Guid("938ff034-3f60-4754-8f8d-9578a4ee0b31"), false, "Yambol", "Flex" }
                });
        }
    }
}
