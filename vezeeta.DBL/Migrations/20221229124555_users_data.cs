using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vezeeta.DBL.Migrations
{
    /// <inheritdoc />
    public partial class usersdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[]
                {
                    "Id", "username", "email", "password", "mobile" , "is_admin", "is_doctor", "is_active"
                }, 
                values: new object[,]
                {
                    { Guid.NewGuid(), "admin", "admin@asp.net", "123456789", "01234567890", true, false, true},
                    { Guid.NewGuid(), "doctor", "doctor@asp.net", "123456789", "01234567891", false, true, true},
                    { Guid.NewGuid(), "user", "user@asp.net", "123456789", "01234567892", true, false, true}
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
