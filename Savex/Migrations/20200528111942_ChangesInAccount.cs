using Microsoft.EntityFrameworkCore.Migrations;

namespace Savex.Migrations
{
    public partial class ChangesInAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRole_Account_AccountId1",
                table: "AccountRole");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRole_Role_RoleId",
                table: "AccountRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_AccountRole_AccountId1",
                table: "AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_AccountRole_RoleId",
                table: "AccountRole");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AccountRole");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "AccountRole");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AccountRole");

            migrationBuilder.AddColumn<string>(
                name: "AccountRoleName",
                table: "AccountRole",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Account",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Account",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Account",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Account",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Account",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountRoleId",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityQuestion",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityQuestionAnswer",
                table: "Account",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountRoleId",
                table: "Account",
                column: "AccountRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AccountRole_AccountRoleId",
                table: "Account",
                column: "AccountRoleId",
                principalTable: "AccountRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AccountRole_AccountRoleId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_AccountRoleId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "AccountRoleName",
                table: "AccountRole");

            migrationBuilder.DropColumn(
                name: "AccountRoleId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "SecurityQuestion",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "SecurityQuestionAnswer",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "AccountRole",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId1",
                table: "AccountRole",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "AccountRole",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRole_AccountId1",
                table: "AccountRole",
                column: "AccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRole_RoleId",
                table: "AccountRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRole_Account_AccountId1",
                table: "AccountRole",
                column: "AccountId1",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRole_Role_RoleId",
                table: "AccountRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
