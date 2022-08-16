using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace my_books2.Migrations
{
    public partial class PublisherAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "publisherId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_publisherId",
                table: "books",
                column: "publisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_Publisher_publisherId",
                table: "books",
                column: "publisherId",
                principalTable: "Publisher",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_Publisher_publisherId",
                table: "books");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_books_publisherId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "publisherId",
                table: "books");
        }
    }
}
