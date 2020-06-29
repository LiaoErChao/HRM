using Microsoft.EntityFrameworkCore.Migrations;

namespace EFEntity.Migrations
{
    public partial class inti1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "config_file_first_kind",
                columns: table => new
                {
                    ffk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_kind_id = table.Column<string>(maxLength: 2, nullable: true),
                    first_kind_name = table.Column<string>(maxLength: 60, nullable: true),
                    first_kind_salary_id = table.Column<string>(nullable: true),
                    first_kind_sale_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_file_first_kind", x => x.ffk_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "config_file_first_kind");
        }
    }
}
