using Microsoft.EntityFrameworkCore.Migrations;

namespace Savex.Migrations
{
    public partial class AddIdInAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRole_Account_AccountId",
                table: "AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_AccountRole_AccountId",
                table: "AccountRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "AccountRole",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId1",
                table: "AccountRole",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Account",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Account",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRole_AccountId1",
                table: "AccountRole",
                column: "AccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRole_Account_AccountId1",
                table: "AccountRole",
                column: "AccountId1",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRole_Account_AccountId1",
                table: "AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_AccountRole_AccountId1",
                table: "AccountRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "AccountRole");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Account");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "AccountRole",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Account",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRole_AccountId",
                table: "AccountRole",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRole_Account_AccountId",
                table: "AccountRole",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
