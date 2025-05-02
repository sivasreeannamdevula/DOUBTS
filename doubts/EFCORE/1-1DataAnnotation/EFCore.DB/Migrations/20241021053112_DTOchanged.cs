using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.DB.Migrations
{
    /// <inheritdoc />
    public partial class DTOchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LaptopName",
                table: "LaptopTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaptopName",
                table: "LaptopTable");
        }
    }
}
