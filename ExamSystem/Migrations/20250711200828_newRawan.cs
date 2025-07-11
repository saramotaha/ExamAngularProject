using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamSystem.Migrations
{
    /// <inheritdoc />
    public partial class newRawan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_StudentExams_StudentId",
                table: "StudentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_StudentId",
                table: "StudentAnswers");

            migrationBuilder.AddColumn<int>(
                name: "StudentExamId",
                table: "StudentAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_StudentExamId",
                table: "StudentAnswers",
                column: "StudentExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_StudentExams_StudentExamId",
                table: "StudentAnswers",
                column: "StudentExamId",
                principalTable: "StudentExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_StudentExams_StudentExamId",
                table: "StudentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_StudentExamId",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "StudentExamId",
                table: "StudentAnswers");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_StudentId",
                table: "StudentAnswers",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_StudentExams_StudentId",
                table: "StudentAnswers",
                column: "StudentId",
                principalTable: "StudentExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
