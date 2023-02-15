using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace vezeeta.DBL.Migrations
{
    /// <inheritdoc />
    public partial class centerseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "centers",
                columns: new[] { "Id", "DepartmentId", "UserId", "amount", "email", "is_active", "logo", "mobile", "name_ar", "name_en", "phone", "slug_ar", "slug_en", "updated_at", "views", "visitors" },
                values: new object[,]
                {
                    { new Guid("06fceef3-b632-466c-b354-f803cb17a107"), null, null, null, "center3@asp.net", false, null, null, "Center 3", "Center 3", "01234567892", "center_3", "center_3", null, 0, 0 },
                    { new Guid("4d2dad2d-911a-4a95-a9c1-879626486c51"), null, null, null, "center2@asp.net", false, null, null, "Center 2", "Center 2", "01234567891", "center_2", "center_2", null, 0, 0 },
                    { new Guid("5c120ce7-6777-42ce-be61-d31c6a77bb6b"), null, null, null, "center1@asp.net", false, null, null, "Center 1", "Center 1", "01234567890", "center_1", "center_1", null, 0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "centers",
                keyColumn: "Id",
                keyValue: new Guid("06fceef3-b632-466c-b354-f803cb17a107"));

            migrationBuilder.DeleteData(
                table: "centers",
                keyColumn: "Id",
                keyValue: new Guid("4d2dad2d-911a-4a95-a9c1-879626486c51"));

            migrationBuilder.DeleteData(
                table: "centers",
                keyColumn: "Id",
                keyValue: new Guid("5c120ce7-6777-42ce-be61-d31c6a77bb6b"));
        }
    }
}
