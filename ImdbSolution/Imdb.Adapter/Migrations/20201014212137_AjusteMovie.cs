using Microsoft.EntityFrameworkCore.Migrations;

namespace Imdb.Adapter.Migrations
{
    public partial class AjusteMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfVotes",
                table: "Movie",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfVotes",
                table: "Movie");
        }
    }
}
