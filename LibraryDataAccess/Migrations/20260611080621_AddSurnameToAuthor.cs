using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSurnameToAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Authors");
        }
    }
}
