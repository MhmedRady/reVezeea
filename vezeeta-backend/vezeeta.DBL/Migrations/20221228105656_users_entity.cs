using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vezeeta.DBL.Migrations
{
    /// <inheritdoc />
    public partial class usersentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profileimage = table.Column<string>(name: "profile_image", type: "nvarchar(max)", nullable: true),
                    NID = table.Column<string>(name: "N_ID", type: "nvarchar(max)", nullable: true, comment: "Doctor User National ID"),
                    isadmin = table.Column<bool>(name: "is_admin", type: "bit", nullable: false, defaultValue: false),
                    isdoctor = table.Column<bool>(name: "is_doctor", type: "bit", nullable: false, defaultValue: false),
                    isactive = table.Column<bool>(name: "is_active", type: "bit", nullable: false, defaultValue: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true, defaultValue: DateTime.Now, comment: "Created At DateTime"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true, comment: "Last Update DateTime")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                table: "users",
                column: "username",
                unique: true,
                filter: "[username] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
