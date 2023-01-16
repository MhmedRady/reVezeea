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
                        "created_at"
                    },
                    values: new object[,]
                    {
                        {Guid.NewGuid(),"مستشفي", "Hospital", true, DateTime.Now },
                        {Guid.NewGuid(),"عيادة خاصة", "Private clinic", true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },

                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                        {Guid.NewGuid(),Faker.Name.First(), Faker.Name.First(), true, DateTime.Now },
                    }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
