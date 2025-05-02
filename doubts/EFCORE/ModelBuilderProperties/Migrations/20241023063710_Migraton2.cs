using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelBuilderProperties.Migrations
{
    /// <inheritdoc />
    public partial class Migraton2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpTable1",
                schema: "newone",
                table: "EmpTable1");

            migrationBuilder.RenameTable(
                name: "EmpTable1",
                schema: "newone",
                newName: "EmpTable123",
                newSchema: "newone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpTable123",
                schema: "newone",
                table: "EmpTable123",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpTable123",
                schema: "newone",
                table: "EmpTable123");

            migrationBuilder.RenameTable(
                name: "EmpTable123",
                schema: "newone",
                newName: "EmpTable1",
                newSchema: "newone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpTable1",
                schema: "newone",
                table: "EmpTable1",
                column: "Id");
        }
    }
}
