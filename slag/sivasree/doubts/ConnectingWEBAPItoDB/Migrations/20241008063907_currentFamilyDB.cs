using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectingWEBAPItoDB.Migrations
{
    /// <inheritdoc />
    public partial class currentFamilyDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "currentFamilyDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoofPpl = table.Column<int>(type: "int", nullable: false),
                    HeadOfFamily = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currentFamilyDB", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "currentFamilyDB");
        }
    }
}
