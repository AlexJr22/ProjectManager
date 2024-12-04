using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetcManager.API.Migrations
{
    /// <inheritdoc />
    public partial class ModifyUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ProjectModelUserModel",
                columns: table => new
                {
                    TasksId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModelUserModel", x => new { x.TasksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ProjectModelUserModel_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectModelUserModel_Projects_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModelUserModel_UsersId",
                table: "ProjectModelUserModel",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectModelUserModel");

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
    }
}
