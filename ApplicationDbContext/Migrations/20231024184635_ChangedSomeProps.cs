using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDbContext.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSomeProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "FacultyName",
                table: "Student",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Student",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacultyName",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
