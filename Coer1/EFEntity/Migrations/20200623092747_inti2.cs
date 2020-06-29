using Microsoft.EntityFrameworkCore.Migrations;

namespace EFEntity.Migrations
{
    public partial class inti2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "config_public_char",
                columns: table => new
                {
                    pbc_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attribute_kind = table.Column<string>(maxLength: 60, nullable: true),
                    attribute_name = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_public_char", x => x.pbc_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "config_public_char");
        }
    }
}
