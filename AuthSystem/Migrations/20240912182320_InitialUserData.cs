using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuthSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLists", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserLists",
                columns: new[] { "Id", "Address", "City", "Email", "FirstName", "LastName", "MiddleName", "Password", "PhoneNumber", "Pincode", "State", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, "WhiteField", "Bengaluru", "ajay@gmail.com", "Ajay", "Kumar N", "", "Ajay@6527", 8767674523L, 560067, "Karnataka", "Active", "ajayn" },
                    { 2, "Halasuru", "Bengaluru", "Ashish@gmail.com", "Ashish", "Sherugar", "", "Ashish@6527", 9767674523L, 560001, "Karnataka", "Active", "ashish" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLists");
        }
    }
}
