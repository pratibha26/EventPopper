using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventPopper.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventTime = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    TotalSeats = table.Column<int>(nullable: false),
                    AvailableSeats = table.Column<int>(nullable: false),
                    HostName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: false),
                    NumberOfTickets = table.Column<int>(nullable: false),
                    TicketPrice = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Rating = table.Column<string>(nullable: true),
                    EventImageUrl = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommentBy = table.Column<string>(nullable: true),
                    CommentText = table.Column<string>(nullable: true),
                    CommentDateTime = table.Column<DateTime>(nullable: true),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CouponName = table.Column<string>(nullable: true),
                    CouponCategory = table.Column<string>(nullable: true),
                    Validity = table.Column<DateTime>(nullable: true),
                    Discount = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupon_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_EventId",
                table: "Comment",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_EventId",
                table: "Coupon",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
