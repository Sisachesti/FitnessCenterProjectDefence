using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessCenter.Data.Migrations
{
    /// <inheritdoc />
    public partial class AvailableSubscribtions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<int>(
                name: "AvailableSubscribtions",
                table: "GymsClasses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "AvailableSubscribtions",
                table: "GymsClasses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

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
        }
    }
}
