using Microsoft.EntityFrameworkCore.Migrations;

namespace Savex.Migrations
{
    public partial class AddAccountInIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Income",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Income_AccountId",
                table: "Income",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Account_AccountId",
                table: "Income",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Income_Account_AccountId",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Income_AccountId",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Income");
        }
    }
}
