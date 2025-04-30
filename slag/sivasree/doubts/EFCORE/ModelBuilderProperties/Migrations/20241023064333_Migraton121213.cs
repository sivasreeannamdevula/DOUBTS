using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelBuilderProperties.Migrations
{
    /// <inheritdoc />
    public partial class Migraton121213 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentTable",
                schema: "newtable",
                table: "CurrentTable");

            migrationBuilder.RenameTable(
                name: "CurrentTable",
                schema: "newtable",
                newName: "CurrentTableNameChanged",
                newSchema: "newtable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentTableNameChanged",
                schema: "newtable",
                table: "CurrentTableNameChanged",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentTableNameChanged",
                schema: "newtable",
                table: "CurrentTableNameChanged");

            migrationBuilder.RenameTable(
                name: "CurrentTableNameChanged",
                schema: "newtable",
                newName: "CurrentTable",
                newSchema: "newtable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentTable",
                schema: "newtable",
                table: "CurrentTable",
                column: "Id");
        }
    }
}
