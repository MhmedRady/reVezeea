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
                    MainSpecialityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_specialities_specialities_MainSpecialityId",
                        column: x => x.MainSpecialityId,
                        principalTable: "specialities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CenterSpeciality",
                columns: table => new
                {
                    CentersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterSpeciality", x => new { x.CentersId, x.SpecialitiesId });
                    table.ForeignKey(
                        name: "FK_CenterSpeciality_centers_CentersId",
                        column: x => x.CentersId,
                        principalTable: "centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CenterSpeciality_specialities_SpecialitiesId",
                        column: x => x.SpecialitiesId,
                        principalTable: "specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "centersSpecialities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpecialityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centersSpecialities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_centersSpecialities_centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "centers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_centersSpecialities_specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "specialities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CenterSpeciality_SpecialitiesId",
                table: "CenterSpeciality",
                column: "SpecialitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_centersSpecialities_CenterId",
                table: "centersSpecialities",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_centersSpecialities_SpecialityId",
                table: "centersSpecialities",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_specialities_MainSpecialityId",
                table: "specialities",
                column: "MainSpecialityId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CenterSpeciality");

            migrationBuilder.DropTable(
                name: "centersSpecialities");

            migrationBuilder.DropTable(
                name: "specialities");
        }
    }
}
