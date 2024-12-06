using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetcManager.API.Migrations
{
    /// <inheritdoc />
    public partial class ModifyUserModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelUserModel_Projects_TasksId",
                table: "ProjectModelUserModel");

            migrationBuilder.RenameColumn(
                name: "TasksId",
                table: "ProjectModelUserModel",
                newName: "ProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelUserModel_Projects_ProjectsId",
                table: "ProjectModelUserModel",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelUserModel_Projects_ProjectsId",
                table: "ProjectModelUserModel");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "ProjectModelUserModel",
                newName: "TasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelUserModel_Projects_TasksId",
                table: "ProjectModelUserModel",
                column: "TasksId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
