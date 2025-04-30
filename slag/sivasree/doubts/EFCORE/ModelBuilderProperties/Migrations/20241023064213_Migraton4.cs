using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelBuilderProperties.Migrations
{
    /// <inheritdoc />
    public partial class Migraton4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpTabl",
                schema: "newone",
                table: "EmpTabl");

            migrationBuilder.EnsureSchema(
                name: "newtable");

            migrationBuilder.RenameTable(
                name: "EmpTabl",
                schema: "newone",
                newName: "CurrentTable",
                newSchema: "newtable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentTable",
                schema: "newtable",
                table: "CurrentTable",
                column: "Id");

            migrationBuilder.InsertData(
                schema: "newtable",
                table: "CurrentTable",
                columns: new[] { "Id", "Designation", "EmpName" },
                values: new object[] { 1, "Trainee", "sivasree" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentTable",
                schema: "newtable",
                table: "CurrentTable");

            migrationBuilder.DeleteData(
                schema: "newtable",
                table: "CurrentTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.EnsureSchema(
                name: "newone");

            migrationBuilder.RenameTable(
                name: "CurrentTable",
                schema: "newtable",
                newName: "EmpTabl",
                newSchema: "newone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpTabl",
                schema: "newone",
                table: "EmpTabl",
                column: "Id");
        }
    }
}
