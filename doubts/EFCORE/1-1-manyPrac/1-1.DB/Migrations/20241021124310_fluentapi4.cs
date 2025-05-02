using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_1.DB.Migrations
{
    /// <inheritdoc />
    public partial class fluentapi4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "CustomerTable",
                newName: "NameOfCustomer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameOfCustomer",
                table: "CustomerTable",
                newName: "CustomerName");
        }
    }
}
