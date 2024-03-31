using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EM.Core.Migrations
{
    /// <inheritdoc />
    public partial class fff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRoles_EmployeeCharcteristics_EmployeeCharacteristicsId",
                table: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "EmployeeCharcteristics");

            migrationBuilder.RenameColumn(
                name: "EmployeeCharacteristicsId",
                table: "EmployeeRoles",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeRoles_EmployeeCharacteristicsId",
                table: "EmployeeRoles",
                newName: "IX_EmployeeRoles_EmployeeId");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Male",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRoles_Employees_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRoles_Employees_EmployeeId",
                table: "EmployeeRoles");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Male",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmployeeRoles",
                newName: "EmployeeCharacteristicsId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeRoles_EmployeeId",
                table: "EmployeeRoles",
                newName: "IX_EmployeeRoles_EmployeeCharacteristicsId");

            migrationBuilder.CreateTable(
                name: "EmployeeCharcteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Male = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCharcteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCharcteristics_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCharcteristics_EmployeeId",
                table: "EmployeeCharcteristics",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRoles_EmployeeCharcteristics_EmployeeCharacteristicsId",
                table: "EmployeeRoles",
                column: "EmployeeCharacteristicsId",
                principalTable: "EmployeeCharcteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
