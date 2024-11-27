using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessCenter.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingNewClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("34d20390-29c9-4a3a-b1d1-66f0f847efde"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("e471daf4-5925-4452-a1bc-67056626c036"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("195373b8-96ee-400b-a4f5-b643ea9172f1"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("6f96f033-5191-4e31-8197-b00dc0fea54f"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("b81b0281-aeec-44e8-a363-88fb2a28e0d5"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("e0d28690-8f4d-42b3-a818-4ccefe01134e"));

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Description", "Duration", "StartingDate", "Title" },
                values: new object[,]
                {
                    { new Guid("7f810645-2f59-4237-8cef-acdc08e7cc50"), "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.", 90, new DateTime(2024, 12, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), "Yoga Class" },
                    { new Guid("92aee3e0-58cd-4fbb-83f3-9774da5422d3"), "A well-rounded workout targeting all major muscle groups. Incorporates free weights, resistance machines, and bodyweight exercises to improve overall strength, endurance, and stability. Suitable for all levels, with modifications available.", 120, new DateTime(2024, 12, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), "Full-Body Strength Training" },
                    { new Guid("b47a707b-23f9-4c2d-9233-21e67de43973"), "A basketball training program is a specialized practice designed to improve an individual's skillset. It typically involves drills and exercises focused on developing specific areas, such as ball handling, shooting, passing, and agility.", 120, new DateTime(2024, 12, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), "Basketball Training" }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("6e3983f7-f9f4-4564-8b62-b4f12d6344f3"), false, "Yambol", "Gladiator" },
                    { new Guid("8d7c80eb-501f-42ba-a79e-ed13873f5bbc"), false, "Yambol", "Flex" },
                    { new Guid("c39aaeab-3260-4434-b2eb-016e0fa56f1b"), false, "Yambol", "Olimpia" },
                    { new Guid("d22c2932-7277-4a25-a9c3-ef496b44e0a0"), false, "Plovdiv", "Pulse Fitness" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("7f810645-2f59-4237-8cef-acdc08e7cc50"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("92aee3e0-58cd-4fbb-83f3-9774da5422d3"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("b47a707b-23f9-4c2d-9233-21e67de43973"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("6e3983f7-f9f4-4564-8b62-b4f12d6344f3"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("8d7c80eb-501f-42ba-a79e-ed13873f5bbc"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("c39aaeab-3260-4434-b2eb-016e0fa56f1b"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("d22c2932-7277-4a25-a9c3-ef496b44e0a0"));

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Description", "Duration", "StartingDate", "Title" },
                values: new object[,]
                {
                    { new Guid("34d20390-29c9-4a3a-b1d1-66f0f847efde"), "A well-rounded workout targeting all major muscle groups. Incorporates free weights, resistance machines, and bodyweight exercises to improve overall strength, endurance, and stability. Suitable for all levels, with modifications available.", 120, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full-Body Strength Training" },
                    { new Guid("e471daf4-5925-4452-a1bc-67056626c036"), "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.", 90, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yoga Class" }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("195373b8-96ee-400b-a4f5-b643ea9172f1"), false, "Yambol", "Olimpia" },
                    { new Guid("6f96f033-5191-4e31-8197-b00dc0fea54f"), false, "Yambol", "Flex" },
                    { new Guid("b81b0281-aeec-44e8-a363-88fb2a28e0d5"), false, "Yambol", "Gladiator" },
                    { new Guid("e0d28690-8f4d-42b3-a818-4ccefe01134e"), false, "Plovdiv", "Pulse Fitness" }
                });
        }
    }
}
