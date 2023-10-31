using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sonaelizebeth");

            migrationBuilder.CreateTable(
                name: "Departmentwasm",
                schema: "sonaelizebeth",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        ,
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmentwasm", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Studentwasm",
                schema: "sonaelizebeth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        ,
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstMark = table.Column<int>(type: "int", nullable: false),
                    SecondMark = table.Column<int>(type: "int", nullable: false),
                    TotalMark = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studentwasm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studentwasm_Departmentwasm_DeptId",
                        column: x => x.DeptId,
                        principalSchema: "sonaelizebeth",
                        principalTable: "Departmentwasm",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "sonaelizebeth",
                table: "Departmentwasm",
                columns: new[] { "DeptId", "DeptName" },
                values: new object[,]
                {
                    { 401, "Artificial Intelligence" },
                    { 402, "Computer Science" }
                });

            migrationBuilder.InsertData(
                schema: "sonaelizebeth",
                table: "Studentwasm",
                columns: new[] { "Id", "DeptId", "FirstMark", "Name", "SecondMark", "TotalMark" },
                values: new object[,]
                {
                    { 101, 401, 90, "Arjun Mahadevan", 91, 181 },
                    { 102, 402, 90, "Mathew Anil", 91, 181 }
                });

            // migrationBuilder.CreateIndex(
            //     name: "IX_Studentwasm_DeptId",
            //     schema: "sonaelizebeth",
            //     table: "Studentwasm",
            //     column: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studentwasm",
                schema: "sonaelizebeth");

            migrationBuilder.DropTable(
                name: "Departmentwasm",
                schema: "sonaelizebeth");
        }
    }
}
