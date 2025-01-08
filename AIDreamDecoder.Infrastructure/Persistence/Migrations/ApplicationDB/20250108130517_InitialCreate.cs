using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIDreamDecoder.Infrastructure.Persistence.Migrations.ApplicationDB
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dreams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dreams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dreams_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DreamAnalyses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DreamId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnalysisResult = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DreamAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DreamAnalyses_Dreams_DreamId",
                        column: x => x.DreamId,
                        principalTable: "Dreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "PasswordHash" },
                values: new object[] { new Guid("4d7b6b79-8fb3-4e1d-9211-d917f498d197"), new DateTime(2025, 1, 8, 16, 5, 17, 435, DateTimeKind.Local).AddTicks(9996), "AIDreamDecoder@gmail.com", "AIDreamDecoder", "AQAAAAIAAYagAAAAEMybI9L9ez2TkO6VbwQUFhiV/jLF4U75LX7N33rgZfpa1LdEOi9KwiGpvIzZKtswFw==" });

            migrationBuilder.CreateIndex(
                name: "IX_DreamAnalyses_DreamId",
                table: "DreamAnalyses",
                column: "DreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dreams_UserId",
                table: "Dreams",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DreamAnalyses");

            migrationBuilder.DropTable(
                name: "Dreams");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
