using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessCenter.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedGymClassMappingTableIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymsClasses_Classes_GymId",
                table: "GymsClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_GymsClasses_Gyms_ClassId",
                table: "GymsClasses");

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("08aea599-7472-466c-9b49-f8a1b794c746"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("38f57682-0342-416b-9803-db827e8a9a31"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("d9a0f9d7-2441-4cc5-bc68-34a469eae5ad"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("5367aa70-6e54-4a89-8c17-e2de0cd1c1cf"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("6af6725b-4938-4347-8159-6a8339b0976a"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("ddafc20a-eb68-47bc-8266-725d132c6b3c"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("e4ea2222-d713-4cc1-b4fa-142845eb053b"));

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Description", "Duration", "IsDeleted", "StartingDate", "Title" },
                values: new object[,]
                {
                    { new Guid("24d76137-7b6c-49d1-a573-43f1c1692c48"), "A basketball training program is a specialized practice designed to improve an individual's skillset. It typically involves drills and exercises focused on developing specific areas, such as ball handling, shooting, passing, and agility.", 120, false, new DateTime(2024, 12, 13, 16, 0, 0, 0, DateTimeKind.Unspecified), "Basketball Training" },
                    { new Guid("657ca1bd-4512-4e18-8b5a-c6c34ce4aa0e"), "A well-rounded workout targeting all major muscle groups. Incorporates free weights, resistance machines, and bodyweight exercises to improve overall strength, endurance, and stability. Suitable for all levels, with modifications available.", 70, false, new DateTime(2024, 12, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), "Full-Body Strength Training" },
                    { new Guid("93d45f4f-4c80-4ac2-9b26-4ec28efbb8a1"), "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.", 90, false, new DateTime(2024, 12, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), "Yoga Class" }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("5b1cd1e8-5c6e-4dfa-b6b8-4f1c6afdadf5"), false, "Yambol", "Flex" },
                    { new Guid("f0535e06-c7c9-438b-8425-50d1cebb7b28"), false, "Yambol", "Gladiator" },
                    { new Guid("f30c8fe8-d60c-4807-a225-1db9e0e8f9f0"), false, "Yambol", "Olimpia" },
                    { new Guid("fd59b75d-7bbd-4cb8-94ff-ba80a9dc0fff"), false, "Plovdiv", "Pulse Fitness" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GymsClasses_Classes_ClassId",
                table: "GymsClasses",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GymsClasses_Gyms_GymId",
                table: "GymsClasses",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymsClasses_Classes_ClassId",
                table: "GymsClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_GymsClasses_Gyms_GymId",
                table: "GymsClasses");

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("24d76137-7b6c-49d1-a573-43f1c1692c48"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("657ca1bd-4512-4e18-8b5a-c6c34ce4aa0e"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("93d45f4f-4c80-4ac2-9b26-4ec28efbb8a1"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("5b1cd1e8-5c6e-4dfa-b6b8-4f1c6afdadf5"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("f0535e06-c7c9-438b-8425-50d1cebb7b28"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("f30c8fe8-d60c-4807-a225-1db9e0e8f9f0"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: new Guid("fd59b75d-7bbd-4cb8-94ff-ba80a9dc0fff"));

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Description", "Duration", "IsDeleted", "StartingDate", "Title" },
                values: new object[,]
                {
                    { new Guid("08aea599-7472-466c-9b49-f8a1b794c746"), "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.", 90, false, new DateTime(2024, 12, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), "Yoga Class" },
                    { new Guid("38f57682-0342-416b-9803-db827e8a9a31"), "A basketball training program is a specialized practice designed to improve an individual's skillset. It typically involves drills and exercises focused on developing specific areas, such as ball handling, shooting, passing, and agility.", 120, false, new DateTime(2024, 12, 13, 16, 0, 0, 0, DateTimeKind.Unspecified), "Basketball Training" },
                    { new Guid("d9a0f9d7-2441-4cc5-bc68-34a469eae5ad"), "A well-rounded workout targeting all major muscle groups. Incorporates free weights, resistance machines, and bodyweight exercises to improve overall strength, endurance, and stability. Suitable for all levels, with modifications available.", 70, false, new DateTime(2024, 12, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), "Full-Body Strength Training" }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("5367aa70-6e54-4a89-8c17-e2de0cd1c1cf"), false, "Yambol", "Gladiator" },
                    { new Guid("6af6725b-4938-4347-8159-6a8339b0976a"), false, "Yambol", "Flex" },
                    { new Guid("ddafc20a-eb68-47bc-8266-725d132c6b3c"), false, "Yambol", "Olimpia" },
                    { new Guid("e4ea2222-d713-4cc1-b4fa-142845eb053b"), false, "Plovdiv", "Pulse Fitness" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GymsClasses_Classes_GymId",
                table: "GymsClasses",
                column: "GymId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GymsClasses_Gyms_ClassId",
                table: "GymsClasses",
                column: "ClassId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
