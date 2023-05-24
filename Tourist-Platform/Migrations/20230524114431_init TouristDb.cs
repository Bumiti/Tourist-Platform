using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourist_Platform.Migrations
{
    public partial class initTouristDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminLogin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminUsername = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLogin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Operator",
                columns: table => new
                {
                    OperatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OperatorName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FromOperator = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ToOperator = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Decription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator", x => x.OperatorId);
                });

            migrationBuilder.CreateTable(
                name: "ThayHuan",
                columns: table => new
                {
                    ThayHuanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThayHuanName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThayHuan", x => x.ThayHuanId);
                });

            migrationBuilder.CreateTable(
                name: "Transportaion",
                columns: table => new
                {
                    TransId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportaion", x => x.TransId);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    NIC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OperatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    From = table.Column<string>(type: "nvarchar", nullable: false),
                    To = table.Column<string>(type: "nvarchar", nullable: false),
                    TimeStart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    TransTicket = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TicketSeat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Operator_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operator",
                        principalColumn: "OperatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Transportaion_TransTicket",
                        column: x => x.TransTicket,
                        principalTable: "Transportaion",
                        principalColumn: "TransId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookingUserName = table.Column<string>(type: "nvarchar", nullable: false),
                    BookingPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingTicketId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Booking_Ticket_BookingTicketId",
                        column: x => x.BookingTicketId,
                        principalTable: "Ticket",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_UserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "UserAccount",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BookingTicketId",
                table: "Booking",
                column: "BookingTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OperatorId",
                table: "Ticket",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TransTicket",
                table: "Ticket",
                column: "TransTicket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminLogin");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "ThayHuan");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "Operator");

            migrationBuilder.DropTable(
                name: "Transportaion");
        }
    }
}
