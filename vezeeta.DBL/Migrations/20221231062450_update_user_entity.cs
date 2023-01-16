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
                name: "gender",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql(
                "ALTER TABLE users ADD CONSTRAINT CheckGenderConstraint CHECK (gender in ('female','male'))"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dob",
                table: "users");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "users");
        }
    }
}
