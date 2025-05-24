using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TM.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInvalidData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "BaseEntity",
                type: "DateTime",
                nullable: false,
                defaultValueSql: "datetime('now')",
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2025, 5, 24, 20, 33, 44, 384, DateTimeKind.Local).AddTicks(2191));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "BaseEntity",
                type: "DateTime",
                nullable: false,
                defaultValueSql: "datetime('now')",
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2025, 5, 24, 20, 33, 44, 380, DateTimeKind.Local).AddTicks(5819));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "BaseEntity",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 24, 20, 33, 44, 384, DateTimeKind.Local).AddTicks(2191),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValueSql: "datetime('now')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "BaseEntity",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 24, 20, 33, 44, 380, DateTimeKind.Local).AddTicks(5819),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValueSql: "datetime('now')");
        }
    }
}
