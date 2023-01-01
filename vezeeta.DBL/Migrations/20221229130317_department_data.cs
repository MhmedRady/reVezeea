using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vezeeta.DBL.Migrations
{
    /// <inheritdoc />
    public partial class departmentdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "departments",
                    columns: new[]
                    {
                        "Id",
                        "name_ar",
                        "name_en",
                        "is_active",
                    },
                    values: new object[,]
                    {
                        {Guid.NewGuid(),"مستشفي", "Hospital", true },
                        {Guid.NewGuid(),"عيادة خاصة", "Private clinic", true },
                        {Guid.NewGuid(),"عيادات خارجية", "Outpatient clinics", true },
                    }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
