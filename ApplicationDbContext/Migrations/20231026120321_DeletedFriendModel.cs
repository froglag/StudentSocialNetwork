using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDbContext.Migrations
{
    /// <inheritdoc />
    public partial class DeletedFriendModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.AddColumn<int>(
                name: "StudentModelStudentId",
                table: "Student",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentModelStudentId",
                table: "Student",
                column: "StudentModelStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Student_StudentModelStudentId",
                table: "Student",
                column: "StudentModelStudentId",
                principalTable: "Student",
                principalColumn: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Student_StudentModelStudentId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_StudentModelStudentId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentModelStudentId",
                table: "Student");

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    FriendId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentModelStudentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.FriendId);
                    table.ForeignKey(
                        name: "FK_Friend_Student_StudentModelStudentId",
                        column: x => x.StudentModelStudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friend_StudentModelStudentId",
                table: "Friend",
                column: "StudentModelStudentId");
        }
    }
}
