using Microsoft.EntityFrameworkCore.Migrations;

namespace EFEntity.Migrations
{
    public partial class inti3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "config_major",
                columns: table => new
                {
                    mak_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    major_kind_id = table.Column<int>(maxLength: 2, nullable: false),
                    major_kind_name = table.Column<int>(maxLength: 60, nullable: false),
                    major_id = table.Column<int>(maxLength: 2, nullable: false),
                    major_name = table.Column<int>(maxLength: 60, nullable: false),
                    test_amount = table.Column<int>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_major", x => x.mak_id);
                });

            migrationBuilder.CreateTable(
                name: "config_major_kind",
                columns: table => new
                {
                    mfk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    major_kind_id = table.Column<string>(maxLength: 2, nullable: true),
                    major_kind_name = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_major_kind", x => x.mfk_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "config_major");

            migrationBuilder.DropTable(
                name: "config_major_kind");
        }
    }
}
