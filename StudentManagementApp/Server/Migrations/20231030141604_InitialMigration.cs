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
                name: "SonaDepartmentwasmTask2",
                schema: "sonaelizebeth",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                       ,
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SonaDepartmentwasmTask2", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "SonaStudentwasmTask2",
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
                    table.PrimaryKey("PK_SonaStudentwasmTask2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SonaStudentwasmTask2_SonaDepartmentwasmTask2_DeptId",
                        column: x => x.DeptId,
                        principalSchema: "sonaelizebeth",
                        principalTable: "SonaDepartmentwasmTask2",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "sonaelizebeth",
                table: "SonaDepartmentwasmTask2",
                columns: new[] { "DeptId", "DeptName" },
                values: new object[,]
                {
                    { 401, "Artificial Intelligence" },
                    { 402, "Computer Science" }
                });

            migrationBuilder.InsertData(
                schema: "sonaelizebeth",
                table: "SonaStudentwasmTask2",
                columns: new[] { "Id", "DeptId", "FirstMark", "Name", "SecondMark", "TotalMark" },
                values: new object[,]
                {
                    { 101, 401, 90, "Arjun Mahadevan", 91, 181 },
                    { 102, 402, 90, "Mathew Anil", 91, 181 }
                });

            // migrationBuilder.CreateIndex(
            //     name: "IX_SonaStudentwasmTask2_DeptId",
            //     schema: "sonaelizebeth",
            //     table: "SonaStudentwasmTask2",
            //     column: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SonaStudentwasmTask2",
                schema: "sonaelizebeth");

            migrationBuilder.DropTable(
                name: "SonaDepartmentwasmTask2",
                schema: "sonaelizebeth");
        }
    }
}
