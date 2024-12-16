﻿// <auto-generated />
using System;
using BlogApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241216124526_BlogMigration")]
    partial class BlogMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Domain.BlogDomain.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DateTime2")
                        .HasAnnotation("Relational:JsonPropertyName", "created_at");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("string");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("DateTime2")
                        .HasAnnotation("Relational:JsonPropertyName", "updated_at");

                    b.HasKey("Id");

                    b.ToTable("Blog");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Some text",
                            CreatedAt = new DateTime(2024, 12, 16, 12, 45, 26, 177, DateTimeKind.Utc).AddTicks(4220),
                            Title = "Blog 1",
                            UpdatedAt = new DateTime(2024, 12, 16, 12, 45, 26, 177, DateTimeKind.Utc).AddTicks(4220)
                        },
                        new
                        {
                            Id = 2,
                            Content = "Some text",
                            CreatedAt = new DateTime(2024, 12, 16, 12, 45, 26, 177, DateTimeKind.Utc).AddTicks(4700),
                            Title = "Blog 2",
                            UpdatedAt = new DateTime(2024, 12, 16, 12, 45, 26, 177, DateTimeKind.Utc).AddTicks(4700)
                        },
                        new
                        {
                            Id = 3,
                            Content = "Some text",
                            CreatedAt = new DateTime(2024, 12, 16, 12, 45, 26, 177, DateTimeKind.Utc).AddTicks(4700),
                            Title = "Blog 3",
                            UpdatedAt = new DateTime(2024, 12, 16, 12, 45, 26, 177, DateTimeKind.Utc).AddTicks(4700)
                        });
                });

            modelBuilder.Entity("Domain.BlogDomain.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BlogId")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "blog_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("string");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DateTime2")
                        .HasAnnotation("Relational:JsonPropertyName", "created_at");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("DateTime2")
                        .HasAnnotation("Relational:JsonPropertyName", "updated_at");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlogId = 1,
                            Content = "Comment 1",
                            CreatedAt = new DateTime(2024, 12, 16, 12, 45, 26, 177, DateTimeKind.Utc).AddTicks(7830),
                            UpdatedAt = new DateTime(2024, 12, 16, 12, 45, 26, 177, DateTimeKind.Utc).AddTicks(7830)
                        },
                        new
                        {
                            Id = 2,
                            BlogId = 1,
                            Content = "Comment 2",
                            CreatedAt = new DateTime(2024, 12, 16, 12, 45, 26, 177, DateTimeKind.Utc).AddTicks(8290),
                            UpdatedAt = new DateTime(2024, 12, 16, 12, 45, 26, 177, DateTimeKind.Utc).AddTicks(8290)
                        },
                        new
                        {
                            Id = 3,
                            BlogId = 2,
                            Content = "Comment 3",
                            CreatedAt = new DateTime(2024, 12, 16, 12, 45, 26, 177, DateTimeKind.Utc).AddTicks(8290),
                            UpdatedAt = new DateTime(2024, 12, 16, 12, 45, 26, 177, DateTimeKind.Utc).AddTicks(8290)
                        });
                });

            modelBuilder.Entity("Domain.BlogDomain.Comment", b =>
                {
                    b.HasOne("Domain.BlogDomain.Blog", null)
                        .WithMany("Comments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.BlogDomain.Blog", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}