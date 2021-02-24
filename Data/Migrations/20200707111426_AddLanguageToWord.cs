using Microsoft.EntityFrameworkCore.Migrations;

namespace Vocabulary.Migrations
{
    public partial class AddLanguageToWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Words",
                nullable: false,
                defaultValue: "en");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Words");
        }
    }
}
