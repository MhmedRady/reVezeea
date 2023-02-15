using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vezeeta.DBL.Migrations
{
    /// <inheritdoc />
    public partial class SetCreatedAtDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "specialities",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                comment: "Created At DateTime",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Created At DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "departments",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                comment: "Created At DateTime",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Created At DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "centers",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                comment: "Created At DateTime",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Created At DateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "specialities",
                type: "datetime2",
                nullable: true,
                comment: "Created At DateTime",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Created At DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "departments",
                type: "datetime2",
                nullable: true,
                comment: "Created At DateTime",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Created At DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "centers",
                type: "datetime2",
                nullable: true,
                comment: "Created At DateTime",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Created At DateTime");
        }
    }
}
