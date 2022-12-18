using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vezeeta.DBL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
