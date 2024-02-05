using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolTrackingSystem.DataAccessLayer.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classroom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolNumber = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherNumber = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    FatherNumber = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students",
                schema: "dbo");
        }
    }
}
