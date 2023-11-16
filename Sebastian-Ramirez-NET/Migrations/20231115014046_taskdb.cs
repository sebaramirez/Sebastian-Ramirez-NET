using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sebastian_Ramirez_NET.Migrations
{
    public partial class taskdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    task_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    task_Title = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    task_Description = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    task_IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.task_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
