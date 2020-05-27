using Microsoft.EntityFrameworkCore.Migrations;

namespace Savex.Migrations
{
    public partial class AddedPropInExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PriorityLevel",
                table: "Expense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoonToBuy",
                table: "Expense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Expense",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriorityLevel",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "SoonToBuy",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Expense");
        }
    }
}
