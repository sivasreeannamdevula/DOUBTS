using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelBuilderProperties.Migrations
{
    /// <inheritdoc />
    public partial class Migraton3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpTable123",
                schema: "newone",
                table: "EmpTable123");

            migrationBuilder.RenameTable(
                name: "EmpTable123",
                schema: "newone",
                newName: "EmpTabl",
                newSchema: "newone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpTabl",
                schema: "newone",
                table: "EmpTabl",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpTabl",
                schema: "newone",
                table: "EmpTabl");

            migrationBuilder.RenameTable(
                name: "EmpTabl",
                schema: "newone",
                newName: "EmpTable123",
                newSchema: "newone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpTable123",
                schema: "newone",
                table: "EmpTable123",
                column: "Id");
        }
    }
}
