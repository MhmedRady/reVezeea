using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vezeeta.DBL.Migrations
{
    /// <inheritdoc />
    public partial class centerentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "centers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Owner Doctor UserId Where User Is Doctor"),
                    namear = table.Column<string>(name: "name_ar", type: "nvarchar(450)", nullable: false),
                    slugar = table.Column<string>(name: "slug_ar", type: "nvarchar(max)", nullable: true),
                    nameen = table.Column<string>(name: "name_en", type: "nvarchar(450)", nullable: false),
                    slugen = table.Column<string>(name: "slug_en", type: "nvarchar(max)", nullable: true),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    views = table.Column<int>(type: "int", nullable: false),
                    visitors = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: true),
                    isactive = table.Column<bool>(name: "is_active", type: "bit", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true, comment: "Created At DateTime"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true, comment: "Last Update DateTime")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_centers_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_centers_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_centers_DepartmentId",
                table: "centers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_centers_name_ar",
                table: "centers",
                column: "name_ar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_centers_name_en",
                table: "centers",
                column: "name_en",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_centers_UserId",
                table: "centers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "centers");
        }
    }
}
