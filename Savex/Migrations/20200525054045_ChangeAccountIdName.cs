using Microsoft.EntityFrameworkCore.Migrations;

namespace Savex.Migrations
{
    public partial class ChangeAccountIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Account_AccountId",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "AccountrId",
                table: "Expense");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Expense",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Account_AccountId",
                table: "Expense",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Account_AccountId",
                table: "Expense");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Expense",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AccountrId",
                table: "Expense",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Account_AccountId",
                table: "Expense",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
