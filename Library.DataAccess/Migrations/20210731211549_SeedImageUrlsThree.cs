using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DataAccess.Migrations
{
    public partial class SeedImageUrlsThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 15, 48, 718, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 15, 48, 735, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 15, 48, 735, DateTimeKind.Local).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 15, 48, 735, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 15, 48, 735, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 15, 48, 735, DateTimeKind.Local).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 15, 48, 735, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 17, 15, 48, 735, DateTimeKind.Local).AddTicks(6630), "https://libraryimagestore.blob.core.windows.net/images/hamletbookcover.jpeg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 10, 36, 263, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 10, 36, 276, DateTimeKind.Local).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 10, 36, 276, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 10, 36, 276, DateTimeKind.Local).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 10, 36, 276, DateTimeKind.Local).AddTicks(1250));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 10, 36, 276, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 17, 10, 36, 276, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 17, 10, 36, 276, DateTimeKind.Local).AddTicks(1400), "https://libraryimagestore.blob.core.windows.net/images/shiningbookcover.jpg" });
        }
    }
}
