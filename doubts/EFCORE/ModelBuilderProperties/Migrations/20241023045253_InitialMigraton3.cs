using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelBuilderProperties.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigraton3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "newone");

            migrationBuilder.CreateTable(
                name: "EmpTablechanged",
                schema: "newone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpTablechanged", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpTablechanged",
                schema: "newone");
        }
    }
}
