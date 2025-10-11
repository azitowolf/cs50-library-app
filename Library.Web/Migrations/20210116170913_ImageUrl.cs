using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Web.Migrations
{
    public partial class ImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Operation = table.Column<string>(nullable: true),
                    BookId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 150, nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "William Shakespeare" },
                    { 2, "George Orwell" },
                    { 3, "J. K. Rowling" },
                    { 4, "Steven King" },
                    { 5, "JRR Tolkein" },
                    { 6, "Lao Tzu" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CreatedOn", "ImageUrl", "IsAvailable", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 1, 16, 12, 9, 13, 43, DateTimeKind.Local).AddTicks(6660), null, false, "Charlemagne" },
                    { 5, 1, new DateTime(2021, 1, 16, 12, 9, 13, 54, DateTimeKind.Local).AddTicks(9530), null, false, "Lord of the Rings: The Fellowshihp of the Rings" },
                    { 2, 2, new DateTime(2021, 1, 16, 12, 9, 13, 54, DateTimeKind.Local).AddTicks(9350), null, false, "1984" },
                    { 6, 2, new DateTime(2021, 1, 16, 12, 9, 13, 54, DateTimeKind.Local).AddTicks(9560), null, false, "Tao Te Ching" },
                    { 3, 3, new DateTime(2021, 1, 16, 12, 9, 13, 54, DateTimeKind.Local).AddTicks(9410), null, false, "Harry Potter and the Pholisoper's Stone" },
                    { 4, 3, new DateTime(2021, 1, 16, 12, 9, 13, 54, DateTimeKind.Local).AddTicks(9510), null, false, "Harry Potter and the Chamber of Secrets" },
                    { 7, 3, new DateTime(2021, 1, 16, 12, 9, 13, 54, DateTimeKind.Local).AddTicks(9580), null, false, "The Shining" },
                    { 8, 3, new DateTime(2021, 1, 16, 12, 9, 13, 54, DateTimeKind.Local).AddTicks(9590), null, false, "Hamlet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "LibraryLogs");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
