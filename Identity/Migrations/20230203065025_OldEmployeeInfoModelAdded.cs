using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    public partial class OldEmployeeInfoModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OldEmployeesInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BasicSalary = table.Column<double>(type: "float", nullable: false),
                    Leaves = table.Column<int>(type: "int", nullable: false),
                    Presents = table.Column<int>(type: "int", nullable: false),
                    PerDaySalary = table.Column<double>(type: "float", nullable: false),
                    Advances = table.Column<double>(type: "float", nullable: false),
                    OverTimeHours = table.Column<int>(type: "int", nullable: false),
                    OverTimeAmmount = table.Column<double>(type: "float", nullable: false),
                    FinalSalary = table.Column<double>(type: "float", nullable: false),
                    SalaryPaid = table.Column<double>(type: "float", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    NotesText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OldEmployeesInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OldEmployeesInfo");
        }
    }
}
