using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelBuilderProperties.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigraton7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChangedEmpTable",
                schema: "newone",
                table: "ChangedEmpTable");

            migrationBuilder.EnsureSchema(
                name: "newtable");

            migrationBuilder.RenameTable(
                name: "ChangedEmpTable",
                schema: "newone",
                newName: "CurrentTable",
                newSchema: "newtable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentTable",
                schema: "newtable",
                table: "CurrentTable",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentTable",
                schema: "newtable",
                table: "CurrentTable");

            migrationBuilder.EnsureSchema(
                name: "newone");

            migrationBuilder.RenameTable(
                name: "CurrentTable",
                schema: "newtable",
                newName: "ChangedEmpTable",
                newSchema: "newone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChangedEmpTable",
                schema: "newone",
                table: "ChangedEmpTable",
                column: "Id");
        }
    }
}
