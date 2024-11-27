using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessCenter.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialNumTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "AvailableSubscribtions",
                table: "GymsClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GymId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserId",
                table: "Managers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ClassId",
                table: "Subscriptions",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_GymId",
                table: "Subscriptions",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Subscriptions");

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

            migrationBuilder.DropColumn(
                name: "AvailableSubscribtions",
                table: "GymsClasses");

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
    }
}
