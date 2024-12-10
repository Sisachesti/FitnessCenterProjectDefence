﻿// <auto-generated />
using System;
using FitnessCenter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessCenter.Data.Migrations
{
    [DbContext(typeof(FitnessCenterDbContext))]
    partial class FitnessCenterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitnessCenter.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("FitnessCenter.Data.Models.ApplicationUserClass", b =>
                {
                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ApplicationUserId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("UsersClasses");
                });

            modelBuilder.Entity("FitnessCenter.Data.Models.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2083)
                        .HasColumnType("nvarchar(2083)")
                        .HasDefaultValue("/images/no-image.jpg");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7c86c935-371f-4450-b451-3ced6285caa6"),
                            Description = "Perfect for beginners or those seeking a calming, slower-paced practice. This class focuses on foundational poses, gentle stretches, and breathwork to enhance flexibility and relaxation. No prior experience needed.",
                            Duration = 90,
                            ImageUrl = "https://www.everydayyoga.com/cdn/shop/articles/yoga_1024x1024.jpg?v=1703853908",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 16, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Yoga Class"
                        },
                        new
                        {
                            Id = new Guid("ee1529ff-9f27-41a3-84b5-938780ab73e6"),
                            Description = "A well-rounded workout targeting all major muscle groups. Incorporates free weights, resistance machines, and bodyweight exercises to improve overall strength, endurance, and stability. Suitable for all levels, with modifications available.",
                            Duration = 70,
                            ImageUrl = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2022/04/male-lifting-weight-1296x728-header.jpg?w=1155&h=1528",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 13, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Full-Body Strength Training"
                        },
                        new
                        {
                            Id = new Guid("cc8df106-d2b7-4112-8b05-bb9fa73919a8"),
                            Description = "A basketball training program is a specialized practice designed to improve an individual's skillset. It typically involves drills and exercises focused on developing specific areas, such as ball handling, shooting, passing, and agility.",
                            Duration = 120,
                            ImageUrl = "https://revolutionbasketballtraining.com/wp-content/uploads/2024/06/Personal-Basketball-Training-Can-Elevate-Your-Game-1.png",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 13, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Basketball Training"
                        },
                        new
                        {
                            Id = new Guid("77c84ea1-4e25-44b6-8fc9-03af14d2a812"),
                            Description = "Cardio will involve running, cycling, HIIT and the work you put in on the training ground. Resistance training involves weightlifting (compound and isolation movements) and bodyweight exercises. Beyond the training itself, you'll need to focus on recovery, flexibility and mobility.",
                            Duration = 148,
                            ImageUrl = "https://cdn.shopify.com/s/files/1/1278/0725/files/training-04_2048x2048.jpg?v=1615983259",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 16, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Football Training"
                        },
                        new
                        {
                            Id = new Guid("e594264f-7497-47c7-965c-cb0028641b77"),
                            Description = "Focus on developing raw strength through compound lifts like squats, deadlifts, and bench presses. Accessory exercises support overall stability and power.",
                            Duration = 135,
                            ImageUrl = "https://connect.healthkart.com/wp-content/uploads/2015/11/banner-63.jpg",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Strength Training"
                        },
                        new
                        {
                            Id = new Guid("4171c3eb-a031-4447-9930-1994c9948210"),
                            Description = "Long-distance running and cycling programs to build stamina essential for football and other high-energy sports.",
                            Duration = 120,
                            ImageUrl = "https://res.cloudinary.com/peloton-cycle/image/fetch/f_auto,c_limit,w_3840,q_90/https://images.ctfassets.net/6ilvqec50fal/An9AxlhKHKfeQB9lto7jC/1fad4cff5a4decf350ef888627d4d355/endurance-training.jpg",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 18, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Endurance Drills"
                        },
                        new
                        {
                            Id = new Guid("9af6ec64-4e60-4af9-bc3f-79e7f215f011"),
                            Description = "Integrate yoga and dynamic stretching to enhance range of motion and prevent injuries.",
                            Duration = 95,
                            ImageUrl = "https://www.otgonline.in/cdn/shop/articles/Mobility-Exercises_1200x.jpg?v=1629806297",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 19, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Flexibility and Mobility"
                        },
                        new
                        {
                            Id = new Guid("b5a0ccac-1206-4174-a0b1-1552a5410fcb"),
                            Description = "Short sprints, ladder drills, and plyometrics designed to boost acceleration and top-end speed.",
                            Duration = 110,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTpHNObL-mJdlpAaOemfj8bPdB-QHxfSaQkHA&s",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 20, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Speed Training"
                        },
                        new
                        {
                            Id = new Guid("cd2be4b6-592c-47b2-b919-dc5bf504609b"),
                            Description = "Hone quick directional changes and improve reaction times through cone drills and reactive agility tests.",
                            Duration = 130,
                            ImageUrl = "https://vertimax.com/hubfs/Agility/agility%20training%20-vertimax%20raptor%20on%20field-1200x600.png",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 21, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Agility Workouts"
                        },
                        new
                        {
                            Id = new Guid("fd645388-d2a3-4fac-9f91-5777731100f9"),
                            Description = "Develop practical strength and coordination using kettlebells, sandbags, and functional training tools.",
                            Duration = 145,
                            ImageUrl = "https://www.trxtraining.com/cdn/shop/articles/Functional_Fitness.jpg?v=1645067939",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 22, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            Title = "Functional Fitness"
                        },
                        new
                        {
                            Id = new Guid("977c1e1c-c2d3-4b04-99f7-3bca63c1a81a"),
                            Description = "Work on core strength and stability using planks, medicine balls, and dynamic core challenges.",
                            Duration = 100,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxYRbpNFB3qYcfkDlVtSXUzvYUHPYqxHzdbg&s",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 23, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Core Stability"
                        },
                        new
                        {
                            Id = new Guid("f09592d4-9658-456f-8ae9-b17b71a73a92"),
                            Description = "Master foam rolling, stretching, and sleep optimization to accelerate recovery.",
                            Duration = 85,
                            ImageUrl = "https://www.totalsportsblog.co.za/wp-content/uploads/2023/12/GettyImages-506979575-scaled.jpg",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 24, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            Title = "Recovery Essentials"
                        },
                        new
                        {
                            Id = new Guid("26a5ae69-9e81-4054-ae52-ddeeb9617b07"),
                            Description = "Improve your understanding of game strategies, positioning, and opponent analysis.",
                            Duration = 140,
                            ImageUrl = "https://www.sportsessionplanner.com/uploads/images/session_transitions/290026.jpg",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 26, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Football Tactical Awareness"
                        },
                        new
                        {
                            Id = new Guid("ca9a8cca-258f-4db7-a267-42cd47a49d55"),
                            Description = "Practice cohesive teamwork strategies with passing, shooting, and situational drills.",
                            Duration = 125,
                            ImageUrl = "https://basketballhq.com/wp-content/uploads/2019/04/Basketball-Team-Drills-2.jpg",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 27, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Basketball Team Drills"
                        },
                        new
                        {
                            Id = new Guid("5eebc931-6b9e-4235-8b46-417f820a37aa"),
                            Description = "Learn defensive tactics, including marking, tackling, and spatial awareness.",
                            Duration = 105,
                            ImageUrl = "https://www.online-basketball-drills.com/wp-content/uploads/2019/12/pngdef9.jpg",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 28, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            Title = "Basketball Defensive Skills"
                        },
                        new
                        {
                            Id = new Guid("97be401d-793c-4536-8375-2856d7a18ecd"),
                            Description = "Develop reflexes, dives, and aerial dominance tailored for goalkeepers.",
                            Duration = 120,
                            ImageUrl = "https://lh4.googleusercontent.com/proxy/QuLrI7AQ3rl10zR9e4R3bbQSc0WWfuTkMcUU4vQ4PxBKGjjNTwDbzg4hVlI3n3C5J3ySvRWUF4bPmW-GvSFO4UfZwjsXlxzpP65vtMTyUx4cfBVMekc_VM1yjx78zSWMqfQupzSR",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 29, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Goalkeeping Techniques"
                        },
                        new
                        {
                            Id = new Guid("89e7076d-4381-4410-8d4d-ecc8f8f3fb61"),
                            Description = "Master attacking strategies including positioning, finishing, and playmaking.",
                            Duration = 115,
                            ImageUrl = "https://www.sportsessionplanner.com/uploads/images/session_transitions/354010.jpg",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 30, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            Title = "Football Offensive Tactics"
                        },
                        new
                        {
                            Id = new Guid("0f531810-56dc-4274-a050-0c2dc16f2221"),
                            Description = "Perform drills that simulate game pressure and build mental toughness.",
                            Duration = 155,
                            ImageUrl = "https://images.stockcake.com/public/7/3/c/73c16313-7985-4838-81b2-10474e7ab8cb_large/intense-basketball-moment-stockcake.jpg",
                            IsDeleted = false,
                            StartingDate = new DateTime(2024, 12, 31, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "High-Intensity Drills"
                        },
                        new
                        {
                            Id = new Guid("0b755994-ff32-4115-bae9-27176c81c517"),
                            Description = "Adapt your training program for preseason, in-season, and postseason phases.",
                            Duration = 145,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7-YSIIzBt1z1xVT3h7ZJbTPKeuVRyZd8pGQ&s",
                            IsDeleted = false,
                            StartingDate = new DateTime(2025, 1, 4, 15, 30, 0, 0, DateTimeKind.Unspecified),
                            Title = "Seasonal Conditioning"
                        });
                });

            modelBuilder.Entity("FitnessCenter.Data.Models.Gym", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Gyms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ef58bd13-0739-4206-b063-23c63e2b6b10"),
                            ImageUrl = "https://static.vecteezy.com/system/resources/previews/026/781/389/non_2x/gym-interior-background-of-dumbbells-on-rack-in-fitness-and-workout-room-photo.jpg",
                            IsDeleted = false,
                            Location = "Yambol",
                            Name = "Gladiator"
                        },
                        new
                        {
                            Id = new Guid("e8aef870-6819-4a92-b18f-9207f351facc"),
                            ImageUrl = "https://images.unsplash.com/photo-1534438327276-14e5300c3a48?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Z3ltfGVufDB8fDB8fHww",
                            IsDeleted = false,
                            Location = "Yambol",
                            Name = "Flex"
                        },
                        new
                        {
                            Id = new Guid("f17bbc9a-7b1a-4500-8d9d-7651cfdd7e96"),
                            ImageUrl = "https://media.istockphoto.com/id/1322158059/photo/dumbbell-water-bottle-towel-on-the-bench-in-the-gym.jpg?s=612x612&w=0&k=20&c=CIdh6LPGwU6U6lbvKCdd7LcppidaYwcDawXJI-b0yGE=",
                            IsDeleted = false,
                            Location = "Yambol",
                            Name = "Olimpia"
                        },
                        new
                        {
                            Id = new Guid("83d7a98e-82da-48d5-8a9c-59f5a4d7ddb9"),
                            ImageUrl = "https://snworksceo.imgix.net/cav/8d443aec-2090-4e9e-8793-6b95d830d89f.sized-1000x1000.JPG?w=1000",
                            IsDeleted = false,
                            Location = "Plovdiv",
                            Name = "Pulse Fitness"
                        });
                });

            modelBuilder.Entity("FitnessCenter.Data.Models.GymClass", b =>
                {
                    b.Property<Guid>("GymId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableSubscribtions")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("GymId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("GymsClasses");
                });

            modelBuilder.Entity("FitnessCenter.Data.Models.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WorkPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("FitnessCenter.Data.Models.Subscribtion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GymId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("GymId");

                    b.HasIndex("UserId");

                    b.ToTable("Subscribtions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FitnessCenter.Data.Models.ApplicationUserClass", b =>
                {
                    b.HasOne("FitnessCenter.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserClasses")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Models.Class", "Class")
                        .WithMany("ClassApplicationUsers")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("FitnessCenter.Data.Models.GymClass", b =>
                {
                    b.HasOne("FitnessCenter.Data.Models.Class", "Class")
                        .WithMany("ClassGyms")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Models.Gym", "Gym")
                        .WithMany("GymClasses")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("FitnessCenter.Data.Models.Manager", b =>
                {
                    b.HasOne("FitnessCenter.Data.Models.ApplicationUser", "User")
                        .WithOne()
                        .HasForeignKey("FitnessCenter.Data.Models.Manager", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessCenter.Data.Models.Subscribtion", b =>
                {
                    b.HasOne("FitnessCenter.Data.Models.Class", "Class")
                        .WithMany("Subscribtions")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Models.Gym", "Gym")
                        .WithMany("Subscribtions")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Models.ApplicationUser", "User")
                        .WithMany("Subscribtions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Gym");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("FitnessCenter.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("FitnessCenter.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("FitnessCenter.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessCenter.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserClasses");

                    b.Navigation("Subscribtions");
                });

            modelBuilder.Entity("FitnessCenter.Data.Models.Class", b =>
                {
                    b.Navigation("ClassApplicationUsers");

                    b.Navigation("ClassGyms");

                    b.Navigation("Subscribtions");
                });

            modelBuilder.Entity("FitnessCenter.Data.Models.Gym", b =>
                {
                    b.Navigation("GymClasses");

                    b.Navigation("Subscribtions");
                });
#pragma warning restore 612, 618
        }
    }
}
