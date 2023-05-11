using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    public partial class UpdatedLedgerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecordTyoe",
                table: "Ledgers",
                newName: "RecordType");

            migrationBuilder.AddColumn<double>(
                name: "Ammount",
                table: "Ledgers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ammount",
                table: "Ledgers");

            migrationBuilder.RenameColumn(
                name: "RecordType",
                table: "Ledgers",
                newName: "RecordTyoe");
        }
    }
}
