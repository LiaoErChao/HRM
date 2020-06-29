using Microsoft.EntityFrameworkCore.Migrations;

namespace EFEntity.Migrations
{
    public partial class inti11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "config_file_second_kind",
                columns: table => new
                {
                    fsk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_kind_id = table.Column<string>(nullable: true),
                    first_kind_name = table.Column<string>(nullable: true),
                    second_kind_id = table.Column<string>(nullable: true),
                    second_kind_name = table.Column<string>(nullable: true),
                    second_salary_id = table.Column<string>(nullable: true),
                    second_sale_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_file_second_kind", x => x.fsk_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "config_file_second_kind");
        }
    }
}
