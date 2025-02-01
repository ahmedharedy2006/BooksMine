using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksMine.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addColumnsToUsersAndAddOrderDetailsAndOrderHeadersTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "postalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "streetAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "orderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    orderTotal = table.Column<double>(type: "float", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paymentDueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    paymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    streetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderHeaders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderHeaderId = table.Column<int>(type: "int", nullable: false),
                    bookId = table.Column<int>(type: "int", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderDetails_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderDetails_orderHeaders_orderHeaderId",
                        column: x => x.orderHeaderId,
                        principalTable: "orderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_bookId",
                table: "orderDetails",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_orderHeaderId",
                table: "orderDetails",
                column: "orderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderHeaders_AppUserId",
                table: "orderHeaders",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderDetails");

            migrationBuilder.DropTable(
                name: "orderHeaders");

            migrationBuilder.DropColumn(
                name: "city",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "postalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "state",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "streetAddress",
                table: "AspNetUsers");
        }
    }
}
