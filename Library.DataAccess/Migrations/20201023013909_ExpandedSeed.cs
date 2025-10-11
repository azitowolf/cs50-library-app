using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DataAccess.Migrations
{
    public partial class ExpandedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Steven King" },
                    { 5, "JRR Tolkein" },
                    { 6, "Lao Tzu" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 10, 22, 21, 39, 8, 502, DateTimeKind.Local).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 10, 22, 21, 39, 8, 513, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 10, 22, 21, 39, 8, 513, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 10, 22, 21, 39, 8, 513, DateTimeKind.Local).AddTicks(4930));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CreatedOn", "IsAvailable", "Title" },
                values: new object[,]
                {
                    { 5, 1, new DateTime(2020, 10, 22, 21, 39, 8, 513, DateTimeKind.Local).AddTicks(4950), false, "Lord of the Rings: The Fellowshihp of the Rings" },
                    { 6, 2, new DateTime(2020, 10, 22, 21, 39, 8, 513, DateTimeKind.Local).AddTicks(4970), false, "Tao Te Ching" },
                    { 7, 3, new DateTime(2020, 10, 22, 21, 39, 8, 513, DateTimeKind.Local).AddTicks(4990), false, "The Shining" },
                    { 8, 3, new DateTime(2020, 10, 22, 21, 39, 8, 513, DateTimeKind.Local).AddTicks(5010), false, "Hamlet" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 10, 22, 19, 25, 24, 661, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 10, 22, 19, 25, 24, 675, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 10, 22, 19, 25, 24, 675, DateTimeKind.Local).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 10, 22, 19, 25, 24, 675, DateTimeKind.Local).AddTicks(1260));
        }
    }
}
