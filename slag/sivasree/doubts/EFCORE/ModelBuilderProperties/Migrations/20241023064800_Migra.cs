using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelBuilderProperties.Migrations
{
    /// <inheritdoc />
    public partial class Migra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentTableNameChanged",
                schema: "newtable",
                table: "CurrentTableNameChanged");

            migrationBuilder.RenameTable(
                name: "CurrentTableNameChanged",
                schema: "newtable",
                newName: "EmpTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpTable",
                table: "EmpTable",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpTable",
                table: "EmpTable");

            migrationBuilder.EnsureSchema(
                name: "newtable");

            migrationBuilder.RenameTable(
                name: "EmpTable",
                newName: "CurrentTableNameChanged",
                newSchema: "newtable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentTableNameChanged",
                schema: "newtable",
                table: "CurrentTableNameChanged",
                column: "Id");
        }
    }
}
