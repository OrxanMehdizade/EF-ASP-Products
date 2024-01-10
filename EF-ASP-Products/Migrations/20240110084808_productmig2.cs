using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_ASP_Products.Migrations
{
    /// <inheritdoc />
    public partial class productmig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Categorys",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Categorys");
        }
    }
}
