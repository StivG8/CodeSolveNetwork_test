using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeSolveNetwork.Context.Migrations.PgSql.Migrations
{
    /// <inheritdoc />
    public partial class newServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_solutions_tasks_TaskId",
                table: "solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_programming_languages_LanguageId",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_task_categories_CategoryId",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_LanguageId",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "tasks");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "tasks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ProgrammingLanguageId",
                table: "tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "solutions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_ProgrammingLanguageId",
                table: "tasks",
                column: "ProgrammingLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_solutions_tasks_TaskId",
                table: "solutions",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_programming_languages_ProgrammingLanguageId",
                table: "tasks",
                column: "ProgrammingLanguageId",
                principalTable: "programming_languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_task_categories_CategoryId",
                table: "tasks",
                column: "CategoryId",
                principalTable: "task_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_solutions_tasks_TaskId",
                table: "solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_programming_languages_ProgrammingLanguageId",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_task_categories_CategoryId",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_ProgrammingLanguageId",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "ProgrammingLanguageId",
                table: "tasks");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "solutions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tasks_LanguageId",
                table: "tasks",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_solutions_tasks_TaskId",
                table: "solutions",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_programming_languages_LanguageId",
                table: "tasks",
                column: "LanguageId",
                principalTable: "programming_languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_task_categories_CategoryId",
                table: "tasks",
                column: "CategoryId",
                principalTable: "task_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
