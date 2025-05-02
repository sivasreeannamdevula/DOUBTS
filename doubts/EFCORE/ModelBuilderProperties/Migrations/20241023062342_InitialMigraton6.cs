using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelBuilderProperties.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigraton6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpTablechangs",
                schema: "newone",
                table: "EmpTablechangs");

            migrationBuilder.RenameTable(
                name: "EmpTablechangs",
                schema: "newone",
                newName: "ChangedEmpTable",
                newSchema: "newone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChangedEmpTable",
                schema: "newone",
                table: "ChangedEmpTable",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChangedEmpTable",
                schema: "newone",
                table: "ChangedEmpTable");

            migrationBuilder.RenameTable(
                name: "ChangedEmpTable",
                schema: "newone",
                newName: "EmpTablechangs",
                newSchema: "newone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpTablechangs",
                schema: "newone",
                table: "EmpTablechangs",
                column: "Id");
        }
    }
}
