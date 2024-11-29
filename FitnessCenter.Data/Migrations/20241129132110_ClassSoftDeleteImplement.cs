using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessCenter.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClassSoftDeleteImplement : Migration
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Classes",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Classes");

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
