using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksMine.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addSessionIdToOrderHeadersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sessionId",
                table: "orderHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sessionId",
                table: "orderHeaders");
        }
    }
}
