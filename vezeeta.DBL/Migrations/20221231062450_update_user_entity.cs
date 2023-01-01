using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vezeeta.DBL.Migrations
{
    /// <inheritdoc />
    public partial class updateuserentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dob",
                table: "users",
                type: "datetime2",
                nullable: true,
                comment: "User Date Of Barth");

            migrationBuilder.AddColumn<string>(
                name: "gander",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql(
                "ALTER TABLE users Add gender varchar(10) NULL CONSTRAINT CHK_Column_Type CHECK (gender IN('male', 'female'))"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dob",
                table: "users");

            migrationBuilder.DropColumn(
                name: "gander",
                table: "users");
        }
    }
}
