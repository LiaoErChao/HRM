using Microsoft.EntityFrameworkCore.Migrations;

namespace EFEntity.Migrations
{
    public partial class inti14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "config_file_third_kind",
                columns: table => new
                {
                    ftk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_kind_id = table.Column<string>(maxLength: 2, nullable: true),
                    first_kind_name = table.Column<string>(maxLength: 60, nullable: true),
                    second_kind_id = table.Column<string>(maxLength: 2, nullable: true),
                    second_kind_name = table.Column<string>(maxLength: 60, nullable: true),
                    third_kind_id = table.Column<string>(maxLength: 2, nullable: true),
                    third_kind_name = table.Column<string>(maxLength: 60, nullable: true),
                    third_kind_sale_id = table.Column<string>(nullable: true),
                    third_kind_is_retail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_file_third_kind", x => x.ftk_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "config_file_third_kind");
        }
    }
}
