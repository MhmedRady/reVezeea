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
            migrationBuilder.DropIndex(
                name: "IX_departments_name_ar",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_departments_name_en",
                table: "departments");

            migrationBuilder.AlterColumn<string>(
                name: "name_en",
                table: "departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "name_ar",
                table: "departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profileimage = table.Column<string>(name: "profile_image", type: "nvarchar(max)", nullable: true),
                    NID = table.Column<string>(name: "N_ID", type: "nvarchar(max)", nullable: true, comment: "Doctor User National ID"),
                    isadmin = table.Column<bool>(name: "is_admin", type: "bit", nullable: false),
                    isdoctor = table.Column<bool>(name: "is_doctor", type: "bit", nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "bit", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "centers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    views = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    visitors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    namear = table.Column<string>(name: "name_ar", type: "nvarchar(450)", nullable: false),
                    nameen = table.Column<string>(name: "name_en", type: "nvarchar(450)", nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "bit", nullable: false, comment: "Entity Row activate status [True, False]"),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true)
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

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.AlterColumn<string>(
                name: "name_en",
                table: "departments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name_ar",
                table: "departments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_departments_name_ar",
                table: "departments",
                column: "name_ar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_name_en",
                table: "departments",
                column: "name_en",
                unique: true);
        }
    }
}
