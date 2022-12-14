using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vezeeta.DBL.Migrations
{
    /// <inheritdoc />
    public partial class departmententity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    namear = table.Column<string>(name: "name_ar", type: "nvarchar(450)", nullable: false),
                    nameen = table.Column<string>(name: "name_en", type: "nvarchar(450)", nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "bit", nullable: false, comment: "Entity Row activate status [True, False]"),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
