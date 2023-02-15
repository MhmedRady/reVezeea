using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vezeeta.DBL.Migrations
{
    /// <inheritdoc />
    public partial class specialityentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "specialities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    namear = table.Column<string>(name: "name_ar", type: "nvarchar(450)", nullable: false),
                    slugar = table.Column<string>(name: "slug_ar", type: "nvarchar(max)", nullable: true),
                    nameen = table.Column<string>(name: "name_en", type: "nvarchar(450)", nullable: false),
                    slugen = table.Column<string>(name: "slug_en", type: "nvarchar(max)", nullable: true),
                    isactive = table.Column<bool>(name: "is_active", type: "bit", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true, comment: "Created At DateTime"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true, comment: "Last Update DateTime")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_specialities_specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "specialities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "centersSpecialities",
                columns: table => new
                {
                    CenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centersSpecialities", x => new { x.SpecialityId, x.CenterId });
                    table.ForeignKey(
                        name: "FK_centersSpecialities_centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_centersSpecialities_specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_centersSpecialities_CenterId",
                table: "centersSpecialities",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_specialities_name_ar",
                table: "specialities",
                column: "name_ar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_specialities_name_en",
                table: "specialities",
                column: "name_en",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_specialities_SpecialityId",
                table: "specialities",
                column: "SpecialityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "centersSpecialities");

            migrationBuilder.DropTable(
                name: "specialities");
        }
    }
}
