using Microsoft.EntityFrameworkCore.Migrations;

namespace Savex.Migrations
{
    public partial class AddedPropInExpensesTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Expense",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Expense");
        }
    }
}
