using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DataAccess.Migrations
{
    public partial class SeedImageUrls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 16, 1, 16, 997, DateTimeKind.Local).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ImageUrl", "Title" },
                values: new object[] { new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(7640), "https://libraryimagestore.blob.core.windows.net/images/harrypottersorcerersstone.jpg", "Harry Potter and the Pholisopher's Stone" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(9310));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 16, 12, 19, 20, 335, DateTimeKind.Local).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 16, 12, 19, 20, 346, DateTimeKind.Local).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ImageUrl", "Title" },
                values: new object[] { new DateTime(2021, 1, 16, 12, 19, 20, 346, DateTimeKind.Local).AddTicks(3050), null, "Harry Potter and the Pholisoper's Stone" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 16, 12, 19, 20, 346, DateTimeKind.Local).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 16, 12, 19, 20, 346, DateTimeKind.Local).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 16, 12, 19, 20, 346, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 16, 12, 19, 20, 346, DateTimeKind.Local).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 16, 12, 19, 20, 346, DateTimeKind.Local).AddTicks(3320));
        }
    }
}
