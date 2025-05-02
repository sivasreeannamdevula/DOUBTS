using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelBuilderProperties.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigraton5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpTablechanged",
                schema: "newone",
                table: "EmpTablechanged");

            migrationBuilder.RenameTable(
                name: "EmpTablechanged",
                schema: "newone",
                newName: "EmpTablechangs",
                newSchema: "newone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpTablechangs",
                schema: "newone",
                table: "EmpTablechangs",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpTablechangs",
                schema: "newone",
                table: "EmpTablechangs");

            migrationBuilder.RenameTable(
                name: "EmpTablechangs",
                schema: "newone",
                newName: "EmpTablechanged",
                newSchema: "newone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpTablechanged",
                schema: "newone",
                table: "EmpTablechanged",
                column: "Id");
        }
    }
}
