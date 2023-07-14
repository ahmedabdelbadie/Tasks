using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.PersonAddress.DAL.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    Zip = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Persons_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name", "Password", "Surname", "Username" },
                values: new object[] { 1, "Ahmed", "123", "Badea", "ahmed" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "City", "State", "Street", "Zip" },
                values: new object[] { 1, "cairo", "12345", "cc", "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
