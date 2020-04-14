﻿// <auto-generated />
using System;
using APIBackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIBackEnd.Migrations
{
    [DbContext(typeof(BoPeepDbContext))]
    [Migration("20200414001235_changedDatabase")]
    partial class changedDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIBackEnd.Models.Activities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExternalLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "A nice stroll outside to enjoy nature and fresh air",
                            ExternalLink = "N/A",
                            Location = 0,
                            Rate = 1,
                            Rating = 4.5,
                            Title = "Hike/trails"
                        },
                        new
                        {
                            ID = 2,
                            Description = "A chance to enjoy nature without movement, also good to enjoy with your cat",
                            ExternalLink = "N/A",
                            Location = 0,
                            Rate = 1,
                            Rating = 4.5,
                            Title = "Bird watching"
                        },
                        new
                        {
                            ID = 3,
                            Description = "Better than a hike! You've got companion to help you stop and smell the roses",
                            ExternalLink = "N/A",
                            Location = 0,
                            Rate = 1,
                            Rating = 4.5,
                            Title = "Dog/cat walking"
                        },
                        new
                        {
                            ID = 4,
                            Description = "grow veggies, flowers and fruit",
                            ExternalLink = "N/A",
                            Location = 0,
                            Rate = 1,
                            Rating = 4.5,
                            Title = "Gardening"
                        },
                        new
                        {
                            ID = 5,
                            Description = "Get a nice bite to eat, for free!",
                            ExternalLink = "N/A",
                            Location = 0,
                            Rate = 1,
                            Rating = 4.5,
                            Title = "Dumpster Diving"
                        },
                        new
                        {
                            ID = 6,
                            Description = "Time to slay dragons and drink mead",
                            ExternalLink = "N/A",
                            Location = 0,
                            Rate = 1,
                            Rating = 4.5,
                            Title = "Games"
                        },
                        new
                        {
                            ID = 7,
                            Description = "Blood pumping and brain working",
                            ExternalLink = "N/A",
                            Location = 0,
                            Rate = 1,
                            Rating = 4.5,
                            Title = "Exercise"
                        },
                        new
                        {
                            ID = 8,
                            Description = "Art, cooking or C#, the options are endless",
                            ExternalLink = "N/A",
                            Location = 0,
                            Rate = 1,
                            Rating = 4.5,
                            Title = "Learning"
                        },
                        new
                        {
                            ID = 9,
                            Description = "Aloe, succulents and anything else your cat won't eat",
                            ExternalLink = "N/A",
                            Location = 0,
                            Rate = 1,
                            Rating = 4.5,
                            Title = "Terrariums"
                        },
                        new
                        {
                            ID = 10,
                            Description = "be social while social distancing",
                            ExternalLink = "N/A",
                            Location = 0,
                            Rate = 1,
                            Rating = 4.5,
                            Title = "Facetime/video calls"
                        });
                });

            modelBuilder.Entity("APIBackEnd.Models.Reviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivitiesID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActivitiesID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("APIBackEnd.Models.Tag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Names")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("APIBackEnd.Models.TagActivity", b =>
                {
                    b.Property<int>("ActivitiesId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("ActivitiesId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("TagActivity");
                });

            modelBuilder.Entity("APIBackEnd.Models.Reviews", b =>
                {
                    b.HasOne("APIBackEnd.Models.Activities", "Activities")
                        .WithMany()
                        .HasForeignKey("ActivitiesID");
                });

            modelBuilder.Entity("APIBackEnd.Models.TagActivity", b =>
                {
                    b.HasOne("APIBackEnd.Models.Activities", "Activities")
                        .WithMany()
                        .HasForeignKey("ActivitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIBackEnd.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
