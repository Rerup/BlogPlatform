using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogApi.Migrations
{
    /// <inheritdoc />
    public partial class BlogMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "string", maxLength: 30, nullable: false),
                    Content = table.Column<string>(type: "text", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DateTime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "string", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    BlogId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blog",
                columns: new[] { "Id", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Some text", new DateTime(2024, 12, 16, 11, 6, 48, 37, DateTimeKind.Utc).AddTicks(8560), "Blog 1", new DateTime(2024, 12, 16, 11, 6, 48, 37, DateTimeKind.Utc).AddTicks(8560) },
                    { 2, "Some text", new DateTime(2024, 12, 16, 11, 6, 48, 37, DateTimeKind.Utc).AddTicks(9090), "Blog 2", new DateTime(2024, 12, 16, 11, 6, 48, 37, DateTimeKind.Utc).AddTicks(9100) },
                    { 3, "Some text", new DateTime(2024, 12, 16, 11, 6, 48, 37, DateTimeKind.Utc).AddTicks(9100), "Blog 3", new DateTime(2024, 12, 16, 11, 6, 48, 37, DateTimeKind.Utc).AddTicks(9100) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BlogId", "Content", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, "Comment 1", new DateTime(2024, 12, 16, 11, 6, 48, 38, DateTimeKind.Utc).AddTicks(2040), new DateTime(2024, 12, 16, 11, 6, 48, 38, DateTimeKind.Utc).AddTicks(2040) },
                    { 2, 1, "Comment 2", new DateTime(2024, 12, 16, 11, 6, 48, 38, DateTimeKind.Utc).AddTicks(2430), new DateTime(2024, 12, 16, 11, 6, 48, 38, DateTimeKind.Utc).AddTicks(2430) },
                    { 3, 2, "Comment 3", new DateTime(2024, 12, 16, 11, 6, 48, 38, DateTimeKind.Utc).AddTicks(2430), new DateTime(2024, 12, 16, 11, 6, 48, 38, DateTimeKind.Utc).AddTicks(2430) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Blog");
        }
    }
}
