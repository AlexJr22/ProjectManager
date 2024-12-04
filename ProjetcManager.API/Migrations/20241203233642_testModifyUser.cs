using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetcManager.API.Migrations
{
    /// <inheritdoc />
    public partial class testModifyUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TaskSTable",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskSTable_UserId",
                table: "TaskSTable",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSTable_AspNetUsers_UserId",
                table: "TaskSTable",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSTable_AspNetUsers_UserId",
                table: "TaskSTable");

            migrationBuilder.DropIndex(
                name: "IX_TaskSTable_UserId",
                table: "TaskSTable");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskSTable");
        }
    }
}
