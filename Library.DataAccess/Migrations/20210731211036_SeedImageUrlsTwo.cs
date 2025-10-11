using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DataAccess.Migrations
{
    public partial class SeedImageUrlsTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 17, 10, 36, 263, DateTimeKind.Local).AddTicks(6540), "https://libraryimagestore.blob.core.windows.net/images/Charlemagne-cover.jpeg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 17, 10, 36, 276, DateTimeKind.Local).AddTicks(1080), "https://libraryimagestore.blob.core.windows.net/images/1984bookcover.jpeg" });

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
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 17, 10, 36, 276, DateTimeKind.Local).AddTicks(1220), "https://libraryimagestore.blob.core.windows.net/images/harrypotterchambersecrets.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ImageUrl", "Title" },
                values: new object[] { new DateTime(2021, 7, 31, 17, 10, 36, 276, DateTimeKind.Local).AddTicks(1250), "https://libraryimagestore.blob.core.windows.net/images/tolkien-fellowship_of_the_ring1.jpeg", "Lord of the Rings: The Fellowship of the Rings" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 17, 10, 36, 276, DateTimeKind.Local).AddTicks(1340), "https://libraryimagestore.blob.core.windows.net/images/taotechingbookcover.jpeg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 17, 10, 36, 276, DateTimeKind.Local).AddTicks(1370), "https://libraryimagestore.blob.core.windows.net/images/shiningbookcover.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 17, 10, 36, 276, DateTimeKind.Local).AddTicks(1400), "https://libraryimagestore.blob.core.windows.net/images/hamletbookcover.jpeg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 16, 1, 16, 997, DateTimeKind.Local).AddTicks(3190), null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(7540), null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(9170), null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ImageUrl", "Title" },
                values: new object[] { new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(9220), null, "Lord of the Rings: The Fellowshihp of the Rings" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(9260), null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(9280), null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2021, 7, 31, 16, 1, 17, 12, DateTimeKind.Local).AddTicks(9310), null });
        }
    }
}
