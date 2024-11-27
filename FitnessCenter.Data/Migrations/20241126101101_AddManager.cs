using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessCenter.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("6461dbbc-1624-4ea7-964e-63886390eb7d"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("c726d176-5613-49d1-a2cb-9d44fcd7c9aa"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("03461336-8e1e-4bc9-84a7-fcf54e9da04c"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("436c05b9-d69d-4a83-a568-5c3095782e80"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("4b864a58-66f2-4675-aef3-836e67418e4e"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("bcfb2fdf-0fe9-4cea-b78b-a6a170a81566"));

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Description", "Duration", "StartingDate", "Title" },
                values: new object[,]
                {
                    { new Guid("87e54060-9138-45df-a292-5ee65b66df01"), "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.", 90, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yoga Class" },
                    { new Guid("94bc2eff-c2fe-45b6-8f95-17b3f68bbd1d"), "A well-rounded workout targeting all major muscle groups. Incorporates free weights, resistance machines, and bodyweight exercises to improve overall strength, endurance, and stability. Suitable for all levels, with modifications available.", 120, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full-Body Strength Training" }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("058d6d43-8e43-4a7a-8482-38bace4ad9df"), false, "Yambol", "Gladiator" },
                    { new Guid("c2f073b3-5c2b-4058-9895-de210c1d1173"), false, "Yambol", "Flex" },
                    { new Guid("d93ecab2-bf2c-4b7a-b6b4-69c16b61f012"), false, "Plovdiv", "Pulse Fitness" },
                    { new Guid("dd40b8b3-c966-4771-a9c3-79053bdd5c6e"), false, "Yambol", "Olimpia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("87e54060-9138-45df-a292-5ee65b66df01"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("94bc2eff-c2fe-45b6-8f95-17b3f68bbd1d"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("058d6d43-8e43-4a7a-8482-38bace4ad9df"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("c2f073b3-5c2b-4058-9895-de210c1d1173"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("d93ecab2-bf2c-4b7a-b6b4-69c16b61f012"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("dd40b8b3-c966-4771-a9c3-79053bdd5c6e"));

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Description", "Duration", "StartingDate", "Title" },
                values: new object[,]
                {
                    { new Guid("6461dbbc-1624-4ea7-964e-63886390eb7d"), "A well-rounded workout targeting all major muscle groups. Incorporates free weights, resistance machines, and bodyweight exercises to improve overall strength, endurance, and stability. Suitable for all levels, with modifications available.", 120, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full-Body Strength Training" },
                    { new Guid("c726d176-5613-49d1-a2cb-9d44fcd7c9aa"), "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.", 90, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yoga Class" }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("03461336-8e1e-4bc9-84a7-fcf54e9da04c"), false, "Yambol", "Olimpia" },
                    { new Guid("436c05b9-d69d-4a83-a568-5c3095782e80"), false, "Yambol", "Flex" },
                    { new Guid("4b864a58-66f2-4675-aef3-836e67418e4e"), false, "Yambol", "Gladiator" },
                    { new Guid("bcfb2fdf-0fe9-4cea-b78b-a6a170a81566"), false, "Plovdiv", "Pulse Fitness" }
                });
        }
    }
}
