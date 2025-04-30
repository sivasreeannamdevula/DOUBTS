using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Many_ManyEFCore.DB.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEntityStudentEntity_CourseTable_listOfCoursesId",
                table: "CourseEntityStudentEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEntityStudentEntity_StudentTb_listOfStudentsStdId",
                table: "CourseEntityStudentEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseEntityStudentEntity",
                table: "CourseEntityStudentEntity");

            migrationBuilder.RenameTable(
                name: "CourseEntityStudentEntity",
                newName: "JunctionTableName");

            migrationBuilder.RenameIndex(
                name: "IX_CourseEntityStudentEntity_listOfStudentsStdId",
                table: "JunctionTableName",
                newName: "IX_JunctionTableName_listOfStudentsStdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JunctionTableName",
                table: "JunctionTableName",
                columns: new[] { "listOfCoursesId", "listOfStudentsStdId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JunctionTableName_CourseTable_listOfCoursesId",
                table: "JunctionTableName",
                column: "listOfCoursesId",
                principalTable: "CourseTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JunctionTableName_StudentTb_listOfStudentsStdId",
                table: "JunctionTableName",
                column: "listOfStudentsStdId",
                principalTable: "StudentTb",
                principalColumn: "StdId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JunctionTableName_CourseTable_listOfCoursesId",
                table: "JunctionTableName");

            migrationBuilder.DropForeignKey(
                name: "FK_JunctionTableName_StudentTb_listOfStudentsStdId",
                table: "JunctionTableName");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JunctionTableName",
                table: "JunctionTableName");

            migrationBuilder.RenameTable(
                name: "JunctionTableName",
                newName: "CourseEntityStudentEntity");

            migrationBuilder.RenameIndex(
                name: "IX_JunctionTableName_listOfStudentsStdId",
                table: "CourseEntityStudentEntity",
                newName: "IX_CourseEntityStudentEntity_listOfStudentsStdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseEntityStudentEntity",
                table: "CourseEntityStudentEntity",
                columns: new[] { "listOfCoursesId", "listOfStudentsStdId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEntityStudentEntity_CourseTable_listOfCoursesId",
                table: "CourseEntityStudentEntity",
                column: "listOfCoursesId",
                principalTable: "CourseTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEntityStudentEntity_StudentTb_listOfStudentsStdId",
                table: "CourseEntityStudentEntity",
                column: "listOfStudentsStdId",
                principalTable: "StudentTb",
                principalColumn: "StdId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
