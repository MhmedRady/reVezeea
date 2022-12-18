using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vezeeta.DBL.Migrations
{
    /// <inheritdoc />
    public partial class centerentityupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "amount",
                table: "centers",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "centers");
        }
    }
}
