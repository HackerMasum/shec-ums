using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShEC.UMS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialStudentSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    student_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_students_student_number",
                table: "students",
                column: "student_number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
