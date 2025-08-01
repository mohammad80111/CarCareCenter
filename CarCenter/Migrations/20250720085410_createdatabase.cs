using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCenter.Migrations
{
    public partial class createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carSizes",
                columns: table => new
                {
                    CarSizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarSizeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carSizes", x => x.CarSizeID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "rolls",
                columns: table => new
                {
                    RollID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RollName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolls", x => x.RollID);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    RollID = table.Column<int>(type: "int", nullable: false),
                    CarSizeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookings_carSizes_CarSizeID",
                        column: x => x.CarSizeID,
                        principalTable: "carSizes",
                        principalColumn: "CarSizeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_rolls_RollID",
                        column: x => x.RollID,
                        principalTable: "rolls",
                        principalColumn: "RollID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeID", "EmployeeName" },
                values: new object[,]
                {
                    { 1, "Mohammad Sawalha" },
                    { 2, "Ayham Sawalha" },
                    { 3, "Ahmed Sawalha" }
                });

            migrationBuilder.InsertData(
                table: "carSizes",
                columns: new[] { "CarSizeID", "CarSizeName" },
                values: new object[,]
                {
                    { 1, "Sedan-Car" },
                    { 2, "Mid-Car" },
                    { 3, "Big-Car" }
                });

            migrationBuilder.InsertData(
                table: "rolls",
                columns: new[] { "RollID", "RollName" },
                values: new object[,]
                {
                    { 1, "Dry Clean" },
                    { 2, "Polishing" },
                    { 3, "Car Wash" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_CarSizeID",
                table: "bookings",
                column: "CarSizeID");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_EmployeeID",
                table: "bookings",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_RollID",
                table: "bookings",
                column: "RollID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "carSizes");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "rolls");
        }
    }
}
