using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Many_ManyEFCore.DB.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTb",
                columns: table => new
                {
                    StdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTb", x => x.StdId);
                });

            migrationBuilder.CreateTable(
                name: "CourseEntityStudentEntity",
                columns: table => new
                {
                    listOfCoursesId = table.Column<int>(type: "int", nullable: false),
                    listOfStudentsStdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEntityStudentEntity", x => new { x.listOfCoursesId, x.listOfStudentsStdId });
                    table.ForeignKey(
                        name: "FK_CourseEntityStudentEntity_CourseTable_listOfCoursesId",
                        column: x => x.listOfCoursesId,
                        principalTable: "CourseTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEntityStudentEntity_StudentTb_listOfStudentsStdId",
                        column: x => x.listOfStudentsStdId,
                        principalTable: "StudentTb",
                        principalColumn: "StdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEntityStudentEntity_listOfStudentsStdId",
                table: "CourseEntityStudentEntity",
                column: "listOfStudentsStdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseEntityStudentEntity");

            migrationBuilder.DropTable(
                name: "CourseTable");

            migrationBuilder.DropTable(
                name: "StudentTb");
        }
    }
}
