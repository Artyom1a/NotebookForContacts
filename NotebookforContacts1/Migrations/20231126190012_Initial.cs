using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotebookforContacts1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notebooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notebooks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notebooks");
        }
    }
}
