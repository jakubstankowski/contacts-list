using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts_List.Infrastructure.Persistance.Migrations
{
    public partial class FixeddAddIdentityUserToContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_IdentityUserId1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_IdentityUserId1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_IdentityUserId",
                table: "Contacts",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_IdentityUserId",
                table: "Contacts",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_IdentityUserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_IdentityUserId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityUserId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_IdentityUserId1",
                table: "Contacts",
                column: "IdentityUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_IdentityUserId1",
                table: "Contacts",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
