using Microsoft.EntityFrameworkCore.Migrations;

namespace EFEntity.Migrations
{
    public partial class inti41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "major_name",
                table: "config_major",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "major_kind_name",
                table: "config_major",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "major_kind_id",
                table: "config_major",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "major_id",
                table: "config_major",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "major_name",
                table: "config_major",
                type: "int",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "major_kind_name",
                table: "config_major",
                type: "int",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "major_kind_id",
                table: "config_major",
                type: "int",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "major_id",
                table: "config_major",
                type: "int",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);
        }
    }
}
